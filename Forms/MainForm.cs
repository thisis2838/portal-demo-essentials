using portal_demo_essentials.Globals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static portal_demo_essentials.Program;


namespace portal_demo_essentials.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Name = this.Text = $"Portal Demo Essentials v{Defaults.Version}";

            Load += MainForm_Load;

            Settings.Subscribe(
                "main_tab_index",
                s => { if (!string.IsNullOrWhiteSpace(s)) tabControl1.SelectedIndex = int.Parse(s); },
                () => tabControl1.SelectedIndex.ToString());

            Settings.Subscribe(
                "sub_tab_index",
                s => { if (!string.IsNullOrWhiteSpace(s)) tabControl2.SelectedIndex = int.Parse(s); },
                () => tabControl2.SelectedIndex.ToString());

            FormClosing += MainForm_FormClosing;
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Settings.WriteSettings();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.tabPage1.Controls.Add(FormsCurDemo);
            this.tabPage4.Controls.Add(FormsAnalyze);
            this.tabPage2.Controls.Add(FormsCurRun);
            this.tabPage5.Controls.Add(FormsSettingsAbout);
            this.tabPage7.Controls.Add(FormPrintToConsole);
            //this.tabPage8.Controls.Add(FormDisplayOnPortalGun);
        }

        private void butOpenCompact_Click(object sender, EventArgs e)
        {
            Program.FormsCompact.Show();
        }
    }
}
