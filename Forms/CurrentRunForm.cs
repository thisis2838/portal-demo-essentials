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
using static portal_demo_essentials.Events;
using static portal_demo_essentials.Utils;
using portal_demo_essentials.Forms.Components;


namespace portal_demo_essentials.Forms
{
    public partial class CurrentRunForm : Form
    {
        private RunListForm _run = new RunListForm(true);
        private TimesForm _timer = new TimesForm();
        public CurrentRunForm()
        {
            InitializeComponent();
            TopLevel = false;
            Visible = true;
            Location = new Point(0, 0);

            _run.Size = panRuns.Size;
            _timer.Size = panTimer.Size;
            panRuns.Controls.Add(_run);
            panTimer.Controls.Add(_timer);

            FinishDemoRecording += (object s, CommonEventArgs e) =>
            {
                ThreadAction(this, () =>
                {
                    _run.Init(((DemoFile)e.Data["demo"]).FilePath);
                    _timer.SetTime(_run.TotalTicks);
                    _timer.Flash();
                });
            };

            BeginDemoRecording += (object s, CommonEventArgs e) =>
            {
                ThreadAction(this, () =>
                {
                    if (Path.GetDirectoryName((string)e.Data["path"]) != _run.FilePath)
                        _run.Reset();
                });
            };

            CurrentDemoTime += (object s, CommonEventArgs e) =>
            {
                ThreadAction(this, () =>
                {
                    _timer.SetTime(_run.TotalTicks + (int)e.Data["time"]);
                });
            };
        }
    }
}
