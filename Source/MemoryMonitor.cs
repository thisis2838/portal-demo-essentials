using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using portal_demo_essentials.Demo;
using portal_demo_essentials.Globals;
using static portal_demo_essentials.Globals.Events;
using static portal_demo_essentials.Globals.Defaults;
using System.ComponentModel;
using portal_demo_essentials.Utils;

namespace portal_demo_essentials.Source
{
    class MemoryMonitor
    {
        public Process Game;
        private MemoryWatcherList _list = new MemoryWatcherList();

        private SigScanTarget _gameDirTarget;
        private SigScanTarget _demoRecorderTarget;
        private int _startTickOffset = -1;
        private string _gameDir;

        private MemoryWatcher<bool> _demoIsRecording;
        private MemoryWatcher<int> _demoIndex;
        private MemoryWatcher<int> _demoFrame;

        private string _demoName;
        private IntPtr _demoNamePtr = IntPtr.Zero;

        private MemoryWatcher<int> _hostTick;
        private MemoryWatcher<int> _startTick;

        public MemoryMonitor()
        {
            _gameDirTarget = new SigScanTarget(0, "25732F736176652F25732E736176"); // "%s/save/%s.sav"
            _gameDirTarget.OnFound = (proc, scanner, ptr) =>
            {
                byte[] b = BitConverter.GetBytes(ptr.ToInt32());
                var target = new SigScanTarget(-4, $"68 {b[0]:X02} {b[1]:X02} {b[2]:X02} {b[3]:X02}");
                return proc.ReadPointer(scanner.Scan(target));
            };

            _demoRecorderTarget = new SigScanTarget(0, "416c7265616479207265636f7264696e672e");
            _demoRecorderTarget.OnFound = (proc, scanner, ptr) =>
            {
                byte[] b = BitConverter.GetBytes(ptr.ToInt32());
                var target = new SigScanTarget(-95, $"68 {b[0]:X02} {b[1]:X02} {b[2]:X02} {b[3]:X02}");

                IntPtr byteArrayPtr = scanner.Scan(target);
                if (byteArrayPtr == IntPtr.Zero)
                    return IntPtr.Zero;

                byte[] bytes = new byte[100];
                proc.ReadBytes(scanner.Scan(target), 100).CopyTo(bytes, 0);
                for (int i = 98; i >= 0; i--)
                {
                    if (bytes[i] == 0x8B && bytes[i + 1] == 0x0D)
                        return proc.ReadPointer(proc.ReadPointer(byteArrayPtr + i + 2));
                }

                return IntPtr.Zero;
            };
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    retry:
                    Game = Process.GetProcesses()
                        .FirstOrDefault(x => GameProcessNames.Contains(x.ProcessName.ToLower()));

                    while (!Scan())
                    {
                        Thread.Sleep(750);
                        goto retry;
                    }
                }
                catch (Exception ex) when (ex is InvalidOperationException || ex is Win32Exception)
                {
                    Trace.WriteLine(ex.ToString());
                    Thread.Sleep(1000);
                }
            }
        }

        private bool Scan()
        {
            if (Game == null || Game.HasExited)
                return false;

            ProcessModuleWow64Safe engine = Game.ModulesWow64Safe().FirstOrDefault(x => x.ModuleName.ToLower() == "engine.dll");
            if (engine == null)
                return false;

            SignatureScanner scanner = new SignatureScanner(Game, engine.BaseAddress, engine.ModuleMemorySize);

            IntPtr demoRecorderPtr, gameDirPtr, hostTickPtr = IntPtr.Zero;

            #region GAME DIR
            gameDirPtr = scanner.Scan(_gameDirTarget);
            if (gameDirPtr == IntPtr.Zero)
                return false;
            else
                _gameDir = Game.ReadString(gameDirPtr, 260);

            if (string.IsNullOrWhiteSpace(_gameDir) || !Directory.Exists(_gameDir))
                return false;
            #endregion

            #region DEMO RECORDER
            demoRecorderPtr = scanner.Scan(_demoRecorderTarget);
            if (demoRecorderPtr == IntPtr.Zero)
                throw new Exception();
            #endregion

            #region HOST TICK & START TICK
            for (int i = 0; i < 10; i++)
            {
                SignatureScanner tmpScanner = new SignatureScanner(Game, Game.ReadPointer(Game.ReadPointer(demoRecorderPtr) + i * 4), 0x100);
                SigScanTarget startTickAccess = new SigScanTarget(2, $"2B ?? ?? ?? 00 00");
                SigScanTarget hostTickAccess = new SigScanTarget(1, "A1");
                hostTickAccess.OnFound = (f_proc, f_scanner, f_ptr) => f_proc.ReadPointer(f_ptr);
                startTickAccess.OnFound = (f_proc, f_scanner, f_ptr) =>
                {
                    IntPtr hostTickOffPtr = f_scanner.Scan(hostTickAccess);
                    if (hostTickOffPtr != IntPtr.Zero)
                    {
                        _startTickOffset = f_proc.ReadValue<int>(f_ptr);
                        return hostTickOffPtr;
                    }
                    return IntPtr.Zero;
                };

                IntPtr ptr = tmpScanner.Scan(startTickAccess);
                if (ptr == IntPtr.Zero)
                    continue;
                else
                {
                    hostTickPtr = ptr;
                    break;
                }
            }
            #endregion

            _demoIsRecording = new MemoryWatcher<bool>(demoRecorderPtr + _startTickOffset + 4 + 260 + 1 + 1);
            _demoIndex = new MemoryWatcher<int>(demoRecorderPtr + _startTickOffset + 4 + 260 + 1 + 1 + 2);
            _demoNamePtr = demoRecorderPtr + 0x4;
            _hostTick = new MemoryWatcher<int>(hostTickPtr);
            _startTick = new MemoryWatcher<int>(demoRecorderPtr + _startTickOffset);

            IntPtr isRecPtr = demoRecorderPtr + _startTickOffset + 4 + 260 + 2;
            IntPtr framePtr = isRecPtr + 2 + 4;
            if (Game.ReadValue<bool>(isRecPtr) == false && Game.ReadValue<int>(framePtr) == 0)
                Game.WriteValue(framePtr, 1);
            _demoFrame = new MemoryWatcher<int>(framePtr);

            _list = new MemoryWatcherList()
            {
                _demoIsRecording,
                _demoIndex,
                _hostTick,
                _startTick,
                _demoFrame
            };

            Monitor();

            return true;
        }

        private void Monitor()
        {
            FoundGameProcess?.Invoke(null, null);

            while (true)
            {
                if (Game == null || Game.HasExited)
                    break;

                _list.UpdateAll(Game);

                var diff = _hostTick.Current - _startTick.Current;
                diff = diff < 0 ? 0 : diff;
                if (Program.FormsSettingsAbout.ZerothTick)
                    diff++;

                if (_demoIsRecording.Current)
                    CurrentDemoTime.Invoke(null, new CommonEventArgs(("time", diff)));

                string name;
                if ((name = Game.ReadString(_demoNamePtr, 260)) != "demoheader.tmp")
                    _demoName = name;

                if (_demoIsRecording.Current && (_demoFrame.Current < _demoFrame.Old))
                {
                    BeginDemoRecording?.Invoke(null, new CommonEventArgs(
                        ("name", Path.GetFileNameWithoutExtension(_demoName)),
                        ("path", Path.GetFullPath(Path.Combine(_gameDir, _demoName)))
                        ));
                }

                bool switched = _demoIsRecording.Current && _demoIndex.Current - _demoIndex.Old == 1 && _demoIndex.Current > 1;
                if ((!_demoIsRecording.Current && _demoIsRecording.Old) || switched)
                {
                    string path = Path.Combine(_gameDir, _demoName);

                    if (File.Exists(path))
                        FinishDemoRecording?.Invoke(null, new CommonEventArgs(
                            ("demo", new DemoFile(path)),
                            ("name", Path.GetFileNameWithoutExtension(_demoName))));
                }

                if (_demoIsRecording.Current)
                    CurrentDemoTime.Invoke(null, new CommonEventArgs(("time", diff)));

                Thread.Sleep(10);
            }

            LostGameProcess?.Invoke(null, null);
        }
    }
}
