using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using portal_demo_essentials.Forms.Components;
using static portal_demo_essentials.Globals.Events;
using static portal_demo_essentials.Globals.Defaults;
using static portal_demo_essentials.Utils.Helpers;
using portal_demo_essentials.Demo;
using System.IO;
using portal_demo_essentials.Globals;

namespace portal_demo_essentials.Forms
{
    public partial class CompactView : Form
    {
        private MinimalTimesForm _curDem = new MinimalTimesForm();
        private MinimalTimesForm _prevDem = new MinimalTimesForm();
        private MinimalTimesForm _timer = new MinimalTimesForm();

        public CompactView()
        {
            InitializeComponent();

            this.TopMost = true;

            _curDem.Dock = _prevDem.Dock = _timer.Dock = DockStyle.Fill;
            this.labDemoName.Text = this.labIndex.Text = "";

            this.tableLayoutPanel1.Controls.Add(_curDem, 2, 0);
            this.tableLayoutPanel1.Controls.Add(_prevDem, 2, 1);
            this.tableLayoutPanel1.Controls.Add(_timer, 2, 2);
            this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            this.FormClosing += CompactView_FormClosing;

            _curDem.ScaleChanged += (s, e) =>
            {
                label2.Text = e.Minified ? "Cur." : "Cur\nDemo";
            };
            _prevDem.ScaleChanged += (s, e) =>
            {
                label1.Text = e.Minified ? "Prev." : "Prev\nDemo";
            };

            FinishDemoRecording += (s, e) =>
            {
                _curDem.ThreadAction(() => { _curDem.SetTime(InitTick); });
                _prevDem.ThreadAction(() => { _prevDem.FinalTime(((DemoFile)e.Data["demo"]).AdjustedTicks); });
                _timer.ThreadAction(() =>
                {
                    _timer.SetTime(Program.FormsCurRun.Run.TotalTicks);
                    _timer.Flash();
                });
                this.ThreadAction(() =>
                {
                    labDemoName.Text = "";
                    labIndex.Text = $"{Program.FormsCurRun.Run.DemoCount}";
                });
            };

            CurrentDemoTime += (s, e) =>
            {
                _timer.ThreadAction(() =>
                {
                    _timer.SetTime(Program.FormsCurRun.Run.TotalTicks + (int)e.Data["time"]);
                });
                _curDem.ThreadAction(() =>
                {
                    _curDem.SetTime((int)e.Data["time"]);
                });
            };

            BeginDemoRecording += (object s, CommonEventArgs e) =>
            {
                this.ThreadAction(() =>
                {
                    labDemoName.Text = Path.GetFileName($"{((string)e.Data["name"])}");
                    labIndex.Text = $"{Program.FormsCurRun.Run.DemoCount + 1}";
                });
            };

            Program.Settings.Subscribe(
                "window_size",
                (s) =>
                {
                    try
                    {
                        var res = s.Split('x');
                        if (res.Length < 2)
                            return;

                        if (int.TryParse(res[0], out int width) && int.TryParse(res[1], out int height))
                        {
                            Width = width;
                            Height = height;
                        }
                    }
                    catch { return; }
                },
                () => $"{Width}x{Height}");
        }

        private void CompactView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
