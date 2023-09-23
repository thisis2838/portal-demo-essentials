using portal_demo_essentials.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static portal_demo_essentials.Globals.Events;
using static portal_demo_essentials.Utils.Helpers;
using portal_demo_essentials.Forms.Components;
using portal_demo_essentials.Globals;

namespace portal_demo_essentials.Forms
{
    public partial class CurrentRunForm : UserControl
    {
        public RunListForm Run = new RunListForm(true);
        private TimesForm _timer = new TimesForm();

        public CurrentRunForm()
        {
            InitializeComponent();

            Run.Size = panRuns.Size;
            _timer.Size = panTimer.Size;
            panRuns.Controls.Add(Run);
            panTimer.Controls.Add(_timer);

            FinishDemoRecording += (object s, CommonEventArgs e) =>
            {
                Run.ThreadAction(() =>
                {
                    Run.Init(((DemoFile)e.Data["demo"]).FilePath, false);
                });

                _timer.ThreadAction(() =>
                {
                    _timer.SetTime(Run.TotalTicks);
                    _timer.Flash();
                });
            };

            BeginDemoRecording += (object s, CommonEventArgs e) =>
            {
                Run.ThreadAction(() =>
                {
                if (Path.GetDirectoryName((string)e.Data["path"]) != Run.FilePath)
                    Run.Reset();
                });
            };

            CurrentDemoTime += (object s, CommonEventArgs e) =>
            {
                _timer.ThreadAction(() =>
                {
                    _timer.SetTime(Run.TotalTicks + (int)e.Data["time"]);
                });
            };
        }
    }
}
