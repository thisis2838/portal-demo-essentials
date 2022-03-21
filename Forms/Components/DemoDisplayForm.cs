using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static portal_demo_essentials.Defaults;

namespace portal_demo_essentials.Forms.Components
{
    public partial class DemoDisplayForm : Form
    {
        private TimesForm _timer = new TimesForm();

        public DemoDisplayForm()
        {
            InitializeComponent();
            TopLevel = false;
            Visible = true;
            Dock = DockStyle.Fill;

            panTimer.Controls.Add(_timer);
            _timer.Size = panTimer.Size;
        }

        public void SetName(string path)
        {
            labDemoName.Text = path;
            if (string.IsNullOrWhiteSpace(path))
            {
                labDemoName.Text = EmptyUI;
                SetTime(Defaults.InitTick);
            }
        }

        public void FinalTime(long ticks) => _timer.FinalTime(ticks);

        public void SetTime(long ticks) => _timer.SetTime(ticks);
    }
}
