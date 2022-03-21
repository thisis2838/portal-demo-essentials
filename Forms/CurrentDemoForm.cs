using portal_demo_essentials.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static portal_demo_essentials.Events;
using static portal_demo_essentials.Utils;
using portal_demo_essentials.Forms.Components;


namespace portal_demo_essentials.Forms
{
    public partial class CurrentDemoForm : Form
    {
        public DemoDisplayForm DispCurrentDemo = new DemoDisplayForm();
        public DemoDisplayForm DispPrevDemo = new DemoDisplayForm();
        public CurrentDemoForm()
        {
            InitializeComponent();
            TopLevel = false;
            Visible = true;
            Location = new Point(0, 0);

            gCurDemo.Controls.Add(DispCurrentDemo);
            gPrevDemo.Controls.Add(DispPrevDemo);

            CenterLabel(labDeny, panDeny);
            SetControls(false);

            FoundGameProcess += (s, e) =>
            {
                ThreadAction(this, () => 
                { 
                    SetControls(true);
                });
            };

            LostGameProcess += (s, e) =>
            {
                ThreadAction(this, () =>
                {
                    SetControls(false);
                });
            };

            CurrentDemoTime += (object s, CommonEventArgs e) =>
            {
                ThreadAction(this, () =>
                {
                    DispCurrentDemo.SetTime((int)e.Data["time"]);
                });
            };

            BeginDemoRecording += (object s, CommonEventArgs e) =>
            {
                ThreadAction(this, () =>
                {
                    DispCurrentDemo.SetName((string)e.Data["name"]);
                });
            };

            FinishDemoRecording += (object s, CommonEventArgs e) =>
            {
                ThreadAction(this, () =>
                {
                    DispCurrentDemo.SetTime(-1);
                    DispPrevDemo.SetName((string)e.Data["name"]);
                    DispPrevDemo.FinalTime(((DemoFile)e.Data["demo"]).AdjustedTicks);
                });
            };
        }

        private void SetControls(bool enabled)
        {
            gCurDemo.Enabled = enabled;
            panDeny.Enabled = panDeny.Visible = !enabled;
        }
    }
}
