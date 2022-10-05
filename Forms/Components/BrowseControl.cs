using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace portal_demo_essentials.Forms.Components
{
    public partial class BrowseControl : UserControl
    {
        [Description("Name of the Path"), Category("Data")]
        public string PathName
        {
            get => labName.Text;
            set => labName.Text = value;
        }

        [Description("Filter for the browser"), Category("Data")]
        public string Filter { get; set; }

        public string Path
        {
            get => BoxPath?.Text ?? "";
            set
            {
                if (BoxPath != null)
                    BoxPath.Text = value;
            }
        }

        public BrowseControl()
        {
            InitializeComponent();
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog()
            {
                Filter = this.Filter
            };
            if (diag.ShowDialog() == DialogResult.OK)
                Path = diag.FileName;

        }
    }
}
