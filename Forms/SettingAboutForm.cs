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
    public partial class SettingAboutForm : Form
    {
        public string MapOrderFile => _boxMapOrderFile.Path;
        private PathBox _boxMapOrderFile = new PathBox("Map Order File");
        public SettingAboutForm()
        {
            InitializeComponent();
            TopLevel = false;
            Visible = true;
            Location = new Point(0, 0);

            labVer.Text = $"Version : {Defaults.Version}";

            tabSettings.Controls.Add(_boxMapOrderFile, 0, 0);

            gSettings.Size = new Size(gSettings.Width, (tabSettings.RowCount - 1) * 34 + 19);
            gAbout.Location = new Point(gAbout.Location.X, 12 + gSettings.Size.Height + 6);

            Settings.SubscribedSettings.Add(new SettingEntry(
                "map_order_file",
                s => _boxMapOrderFile.Path = s,
                () => _boxMapOrderFile.Path));
        }

        private void SettingAboutForm_Load(object sender, EventArgs e)
        {

        }
    }
}
