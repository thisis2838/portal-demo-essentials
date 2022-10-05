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
using static portal_demo_essentials.Program;

namespace portal_demo_essentials.Forms
{
    public partial class SettingAboutForm : UserControl
    {
        public string MapOrderFile => boxMapOrderFile.Path;
        public bool ZerothTick => chkZerothTick.Checked;

        public SettingAboutForm()
        {
            InitializeComponent();

            labVer.Text = $"Version : {Defaults.Version}";

            Settings.Subscribe(
                "map_order_file",
                s => boxMapOrderFile.Path = s,
                () => boxMapOrderFile.Path);

            Settings.Subscribe(
                "zeroth_tick",
                s => { if (bool.TryParse(s, out bool e)) chkZerothTick.Checked = e; },
                () => chkZerothTick.Checked.ToString());
        }

        private void SettingAboutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
