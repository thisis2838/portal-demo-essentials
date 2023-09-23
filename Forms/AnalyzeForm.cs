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
using portal_demo_essentials.Globals;

namespace portal_demo_essentials.Forms
{
    public partial class AnalyzeForm : UserControl
    {
        private RunListForm _listForm = new RunListForm();
        private TimesForm _timer = new TimesForm();
        public AnalyzeForm()
        {
            InitializeComponent();

            panLists.Controls.Add(_listForm);
            panTimer.Controls.Add(_timer);
            _timer.Size = panTimer.Size;

            _listForm.SelectedCell += (object s, CommonEventArgs e) =>
            {
                labFilePath.Text = (string)e.Data["file_path"];
                labMapName.Text = (string)e.Data["map_name"];
                labPlayerName.Text = (string)e.Data["player_name"];

                long ticks = (long)e.Data["time"];

                _timer.SetTime(ticks);
            };
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Multiselect = true;
            diag.Filter = @"Demo Files (*.DEM)|*.DEM";

            if (diag.ShowDialog() == DialogResult.OK)
            {
                _listForm.Init(diag.FileNames, true);
            }
        }
    }
}
