using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Text.Encoding;
using static System.Math;
using static System.BitConverter;
using static System.Globalization.CultureInfo;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using portal_demo_essentials.Globals;

namespace portal_demo_essentials.Demo
{
    public class DemoFile
    {
        public string Name = "";
        public string MapName = "";
        public string PlayerName = "";
        public string GameName = "";
        public int Index = 0;
        public long TotalTicks = Defaults.InitTick;
        public long AdjustedTicks = Defaults.InitTick;
        public string FilePath = "";

        private bool _hasZeroTick = false;
        public void Refresh()
        {
            if (Program.FormsSettingsAbout.ZerothTick != _hasZeroTick)
            {
                _hasZeroTick = Program.FormsSettingsAbout.ZerothTick;
                TotalTicks += _hasZeroTick ? 1 : -1;
            }

            AdjustedTicks = TotalTicks;

            if (StartTick != Defaults.InitTick)
                AdjustedTicks = TotalTicks - StartTick;
            if (EndTick != Defaults.InitTick)
                AdjustedTicks -= TotalTicks - EndTick;
        }

        public int StartTick { get; private set; } = Defaults.InitTick;
        public int EndTick { get; private set; } = Defaults.InitTick;

        public DemoFile(string filePath)
        {
            filePath = Path.GetFullPath(filePath);
            if (!File.Exists(filePath))
                return;

            FilePath = filePath;
            Name = Path.GetFileNameWithoutExtension(filePath);

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs))
            {
                br.BaseStream.Seek(8 + 4 + 4 + 260, SeekOrigin.Current);
                PlayerName = ASCII.GetString(br.ReadBytes(260)).TrimEnd('\0');
                MapName = ASCII.GetString(br.ReadBytes(260)).TrimEnd('\0');
                GameName = ASCII.GetString(br.ReadBytes(260)).TrimEnd('\0');

                br.BaseStream.Seek(4 * 3, SeekOrigin.Current);
                var signOnLen = br.ReadInt32();

                try
                {
                    byte command = 0x0;
                    while (command != 0x07)
                    {
                        command = br.ReadByte();

                        if (command == 0x07) // dem_stop
                            break;

                        var tick = br.ReadInt32();
                        if (tick >= 0)
                            TotalTicks = tick;

                        switch (command)
                        {
                            case 0x01:
                                br.BaseStream.Seek(signOnLen, SeekOrigin.Current);
                                break;
                            case 0x02:
                                {
                                    br.BaseStream.Seek(4, SeekOrigin.Current);
                                    if (MapName.ToLower() == "testchmb_a_00")
                                    {
                                        float x = br.ReadSingle();
                                        float y = br.ReadSingle();
                                        float z = br.ReadSingle();
                                        if (StartTick == Defaults.InitTick &&
                                            x == -544f &&
                                            y == -368.75f &&
                                            z == 160f)
                                            StartTick = tick + 1;
                                    }
                                    else
                                    {
                                        br.BaseStream.Seek(4 * 3, SeekOrigin.Current);
                                    }
                                    br.BaseStream.Seek(68L, SeekOrigin.Current);
                                    var packetLen = br.ReadInt32();
                                    br.BaseStream.Seek(packetLen, SeekOrigin.Current);
                                }
                                break;
                            case 0x04: // console commands
                                {
                                    var concmdLen = br.ReadInt32();

                                    if (MapName.ToLower() == "escape_02")
                                    {
                                        string cmd = ASCII.GetString(br.ReadBytes(concmdLen - 1)).Trim(new char[1]);
                                        if (cmd.Trim() == "startneurotoxins 99999")
                                            EndTick = tick + 1 + 1;
                                        br.BaseStream.Seek(1, SeekOrigin.Current); // skip null terminator
                                    }
                                    else { br.BaseStream.Seek(concmdLen, SeekOrigin.Current); }
                                }
                                break;
                            case 0x05: // user commands
                                {
                                    br.BaseStream.Seek(4, SeekOrigin.Current); // skip sequence
                                    var userCmdLen = br.ReadInt32();
                                    br.BaseStream.Seek(userCmdLen, SeekOrigin.Current);
                                }
                                break;
                            case 0x08:
                                {
                                    var stringTableLen = br.ReadInt32();
                                    br.BaseStream.Seek(stringTableLen, SeekOrigin.Current);
                                }
                                break;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show($"Problem while parsing {Path.GetFileName(filePath)}, file may be corrupted!", "Demo Parsing", MessageBoxButtons.OK);
                }
            }

            Refresh();

            string name = Path.GetFileNameWithoutExtension(filePath);
            var match = Regex.Match(name, $@"^(?:{MapName}_)([0-9]+)$", RegexOptions.IgnoreCase);
            if (match.Success)
                int.TryParse(match.Groups[1].Value, out Index);
        }

        public static bool FromFilepath(string filePath, out DemoFile demo)
        {
            demo = null;

            if (!File.Exists(filePath))
                return false;

            try { demo = new DemoFile(filePath); return true; }
            catch { return false; }
        }

        public override string ToString()
        {
            return $"{Name} [{AdjustedTicks} ticks]";
        }
    }
}
