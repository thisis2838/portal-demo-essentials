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
    public partial class MinimalTimesForm : Form
    {
        private ControlFlasher _tickFlasher;
        private ControlFlasher _humanFlasher;
        private List<(Label, Control)> _centerList = new List<(Label, Control)>();

        public MinimalTimesForm()
        {
            InitializeComponent();

            TopLevel = false;
            Visible = true;
            Location = new Point(0, 0);

            _centerList = new List<(Label, Control)>()
            {
                (labTimeTicks, panTimeTicks),
                (labTimeHuman, panTimeHuman),
            };

            _tickFlasher = new ControlFlasher(panTimeTicks);
            _humanFlasher = new ControlFlasher(panTimeHuman);

            SetTime(Defaults.InitTick);

            SizeChanged += TimesForm_SizeChanged;
        }


        private void TimesForm_SizeChanged(object sender, EventArgs e)
        {
            CenterText();

            if (tableLayoutPanel1.Size.Height <= 25 || tableLayoutPanel1.Size.Width <= 300)
            {
                labTimeHuman.Font = new System.Drawing.Font("Consolas", 10f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                labTimeTicks.Font = new System.Drawing.Font("Consolas", 10f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                labTimeHuman.Font = new System.Drawing.Font("Consolas", 20.25f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                labTimeTicks.Font = new System.Drawing.Font("Consolas", 20.25f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            }
        }

        public void FinalTime(long ticks)
        {
            SetTime(ticks);

            Flash();
        }

        public void Flash()
        {
            _tickFlasher.FlashBackColor(750, Color.Green);
            _humanFlasher.FlashBackColor(750, Color.Green);
        }

        public void SetTime(long ticks)
        {
            if (ticks == Defaults.InitTick)
            {
                labTimeHuman.Text = labTimeTicks.Text = EmptyUI;
            }
            else
            {
                labTimeTicks.Text = ticks.ToString();
                labTimeHuman.Text = Utils.GetTimeString(ticks);
            }

            CenterText();
        }

        private void CenterText()
        {
            _centerList.ForEach(x => x.Item1.Location = Utils.CenterLabel(x.Item1, x.Item2));
        }
    }
}
