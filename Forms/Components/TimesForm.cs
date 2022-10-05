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
    public partial class TimesForm : UserControl
    {
        private ControlFlasher _tickFlasher;
        private ControlFlasher _humanFlasher;
        private List<(Label, Control)> _centerList = new List<(Label, Control)>();

        public TimesForm()
        {
            InitializeComponent();

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
        }

        public void FinalTime(long ticks)
        {
            SetTime(ticks);

            Flash();
        }

        public void Flash()
        {
            _tickFlasher.FlashBackColor(Defaults.FlashDuration, Color.Green);
            _humanFlasher.FlashBackColor(Defaults.FlashDuration, Color.Green);
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
