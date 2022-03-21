using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LiveSplit.ComponentUtil;
using portal_demo_essentials.Demo;
using static portal_demo_essentials.Events;
using static portal_demo_essentials.Defaults;
using System.ComponentModel;

namespace portal_demo_essentials.Source
{
    class MemoryMonitor
    {
        private SigScanTarget _gameDirTarget;
        private SigScanTarget _demoRecorderTarget;
        private MemoryWatcher<bool> _demoIsRecording;
        private MemoryWatcher<int> _demoIndex;
        private StringWatcher _demoName;
        private int _startTickOffset = -1;
        private Process _game;
        private string _gameDir;
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
                    _game = Process.GetProcesses()
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
            if (_game == null || _game.HasExited)
                return false;

            ProcessModuleWow64Safe engine = _game.ModulesWow64Safe().FirstOrDefault(x => x.ModuleName.ToLower() == "engine.dll");
            if (engine == null)
                return false;

            SignatureScanner scanner = new SignatureScanner(_game, engine.BaseAddress, engine.ModuleMemorySize);

            IntPtr demoRecorderPtr, gameDirPtr, hostTickPtr = IntPtr.Zero;

            #region GAME DIR
            gameDirPtr = scanner.Scan(_gameDirTarget);
            if (gameDirPtr == IntPtr.Zero)
                return false;
            else
                _gameDir = _game.ReadString(gameDirPtr, 260);

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
                SignatureScanner tmpScanner = new SignatureScanner(_game, _game.ReadPointer(_game.ReadPointer(demoRecorderPtr) + i * 4), 0x100);
                SigScanTarget StartTickAccess = new SigScanTarget(2, $"2B ?? ?? ?? 00 00");
                SigScanTarget hostTickAccess = new SigScanTarget(1, "A1");
                hostTickAccess.OnFound = (f_proc, f_scanner, f_ptr) => f_proc.ReadPointer(f_ptr);
                StartTickAccess.OnFound = (f_proc, f_scanner, f_ptr) =>
                {
                    IntPtr hostTickOffPtr = f_scanner.Scan(hostTickAccess);
                    if (hostTickOffPtr != IntPtr.Zero)
                    {
                        _startTickOffset = f_proc.ReadValue<int>(f_ptr);
                        return hostTickOffPtr;
                    }
                    return IntPtr.Zero;
                };

                IntPtr ptr = tmpScanner.Scan(StartTickAccess);
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
            _demoName = new StringWatcher(demoRecorderPtr + _startTickOffset + 4, 100);
            _hostTick = new MemoryWatcher<int>(hostTickPtr);
            _startTick = new MemoryWatcher<int>(demoRecorderPtr + _startTickOffset);

            Monitor();

            return true;
        }

        private void Monitor()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            FoundGameProcess?.Invoke(null, null);
            bool first = true;

            while (true)
            {
                if (_game == null || _game.HasExited)
                    break;

                _demoIsRecording.Update(_game);
                _demoIndex.Update(_game);
                _demoName.Update(_game);
                _hostTick.Update(_game);
                _startTick.Update(_game);

                if (_demoIsRecording.Current)
                    CurrentDemoTime.Invoke(null, new CommonEventArgs(("time", _hostTick.Current - _startTick.Current)));

                bool switched = _demoIsRecording.Current && _demoIndex.Current - _demoIndex.Old == 1 && _demoIndex.Current > 1;

                if (_demoIsRecording.Changed || switched || first)
                {
                    if (first)
                        first = false;

                    if (_demoIsRecording.Current && !switched)
                    {
                        string name = _demoName.Current;
                        if (_demoIndex.Current > 1)
                            name += $"_{_demoIndex.Current}";

                        BeginDemoRecording?.Invoke(null, new CommonEventArgs(
                            ("name", name),
                            ("path", Path.GetFullPath(Path.Combine(_gameDir, $"{name}.dem")))
                            ));
                    }
                    else
                    {
                        string name = _demoName.Old;
                        if (_demoIndex.Old > 1)
                            name += $"_{_demoIndex.Old}";

                        string path = Path.Combine(_gameDir, $"{name}.dem");

                        if (File.Exists(path))
                            FinishDemoRecording?.Invoke(null, new CommonEventArgs(
                                ("demo", new DemoFile(path)),
                                ("name", name)));
                    }
                }

                if (_demoIsRecording.Current)
                    CurrentDemoTime.Invoke(null, new CommonEventArgs(("time", _hostTick.Current - _startTick.Current)));

                Thread.Sleep(10);
            }

            LostGameProcess?.Invoke(null, null);
        }
    }
}
