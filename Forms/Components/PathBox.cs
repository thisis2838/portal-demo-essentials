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
    public partial class PathBox : Form
    {
        private string _filter = "All files(*.*)|*.*";
        public string Path
        {
            get
            {
                return boxPath?.Text ?? "";
            }
            set
            {
                if (boxPath != null)
                    boxPath.Text = value;
            } 
        }

        public PathBox(string name)
        {
            InitializeComponent();
            TopLevel = false;
            Visible = true;
            Location = new Point(0, 0);
            Dock = DockStyle.Fill;

            labName.Text = name;
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            var diag = new OpenFileDialog();
            diag.Filter = _filter;
            if (diag.ShowDialog() == DialogResult.OK)
                boxPath.Text = diag.FileName;
        }
    }
}
