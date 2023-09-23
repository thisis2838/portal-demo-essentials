using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static portal_demo_essentials.Utils.Helpers;
using static portal_demo_essentials.Program;
using static portal_demo_essentials.Globals.Events;
using portal_demo_essentials.Demo;
using System.IO;
using System.Diagnostics;
using portal_demo_essentials.Globals;
using portal_demo_essentials.Utils;

namespace portal_demo_essentials.Forms
{
    public partial class PrintToConsoleForm : UserControl
    {
        public PrintToConsoleForm()
        {
            InitializeComponent();

            cmbDemoParser.FillComboBoxWithEnumDesc<DemoParserType>();

            FinishDemoRecording += (object s, CommonEventArgs e) =>
            {
                var demo = (DemoFile)e.Data["demo"];
                this.ThreadAction(() => PrintDemoInfo(demo));
            };

            Settings.Subscribe(
                "print_console_enable",
                s => { if (bool.TryParse(s, out bool e)) chkEnabled.Checked = e; },
                () => chkEnabled.Checked.ToString());

            Settings.Subscribe(
                "print_ext_parser_path",
                s => boxPath.Path = s,
                () => boxPath.Path);

            Settings.Subscribe(
                "print_parser_type",
                s => cmbDemoParser.Text = EnumParse<DemoParserType>(s).GetDescription(),
                () => EnumValueFromDescription<DemoParserType>(cmbDemoParser.Text).ToString());
        }

        public void PrintDemoInfo(DemoFile file)
        {
            if (!chkEnabled.Checked)
                return;

            void sendMsg(string msg)
            {
                List<string> msgs = new List<string>();

                msgs.Add(" ");
                msgs.Add($"Info for: {file.Name}.dem");
                msgs.Add(" ");

                msg = msg.Replace("\r\n", "\n").Trim(' ', '\n');
                msg.Split('\n').ToList().ForEach(x => msgs.Add(x));

                msgs.Add(" ");

                WinAPI.SendMessage(Monitor.Game, "echo \"" + String.Join("\";echo \"", msgs) + " \"");
            }

            file.Refresh();

            if (EnumValueFromDescription<DemoParserType>(cmbDemoParser.Text) == DemoParserType.Internal ||
                (string.IsNullOrWhiteSpace(boxPath.Path) || !File.Exists(boxPath.Path)))
            {
                sendMsg($@"
Path:       {file.FilePath}
Index:      {file.Index}
Map:        {file.MapName}
Player:     {file.PlayerName}
Game:       {file.GameName}

Total:      {file.TotalTicks}
Measured:   {file.AdjustedTicks}
 ");
                return;
            }
            else
            {
                Process listdemo = new Process();
                listdemo.StartInfo.FileName = "cmd.exe";
                listdemo.StartInfo.Arguments =
                    $"/C " +
                    $"{Path.GetPathRoot(boxPath.Path).Replace("\\", "")} " +
                    $"&\"{boxPath.Path}\" " +
                    $"\"{file.FilePath}\"" +
                    $"& exit";
                listdemo.StartInfo.UseShellExecute = false;
                listdemo.StartInfo.CreateNoWindow = true;
                listdemo.StartInfo.RedirectStandardOutput = true;
                string output = "";
                listdemo.OutputDataReceived += (s, e) =>
                {
                    output += e.Data + "\n";
                };
                listdemo.Start();
                listdemo.BeginOutputReadLine();
                listdemo.WaitForExit();

                sendMsg(output);
            }

        }

        private void cmbDemoParser_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxPath.Visible = cmbDemoParser.SelectedIndex == 1;
        }
    }

    public enum DemoParserType
    {
        [Description("Internal Demo Parser")]
        Internal,
        [Description("External Demo Parser")]
        External
    }
}
