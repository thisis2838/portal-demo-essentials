using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace portal_demo_essentials
{
    class Utils
    {
        public static Point CenterLabel(Label lab, Control control, bool horiz = true, bool vert = true)
        {
            int xPos = control.Width / 2 - lab.Size.Width / 2;
            int yPos = control.Height / 2 - lab.Size.Height / 2;

            return new Point(xPos, yPos);
        }

        public static Color BiasedAverageColor(Color color1, Color color2, int percent)
        {
            if (percent == 0)
                return color2;

            int r = (percent * color1.R + (100 - percent) * color2.R) / 100;
            int g = (percent * color1.G + (100 - percent) * color2.G) / 100;
            int b = (percent * color1.B + (100 - percent) * color2.B) / 100;

            return Color.FromArgb(r, g, b);
        }

        public static void ThreadAction(Form form, Action action)
        {
            if (form.InvokeRequired)
                form.Invoke(action);
            else
                action();
        }

        public static string GetTimeString(long ticks)
        {
            return (ticks < 0 ? "-" : "") + TimeSpan.FromSeconds(ticks * Defaults.TickRate).ToString(Defaults.TimeSpanLong);
        }
    }

    public class ControlFlasher
    {
        private Control _control;
        private Color _origBackColor;
        private Thread _thread;

        public ControlFlasher(Control control)
        {
            _control = control;
            _origBackColor = control.BackColor;
        }

        public void FlashBackColor(int time, Color color)
        {
            if (_thread?.IsAlive ?? false)
                _thread.Abort();

            _thread = new Thread(new ThreadStart(() => 
            {
                Stopwatch sw = new Stopwatch();
                Color orig = _origBackColor;
                sw.Start();

                while (true)
                {
                    if (sw.ElapsedMilliseconds >= time)
                    {
                        _control.BackColor = orig;
                        return;
                    }
                    _control.BackColor = Utils.BiasedAverageColor(orig, color, (int)(sw.ElapsedMilliseconds / (float)time * 100));
                    Thread.Sleep(10);
                }

            }));

            _thread.Start();
        }
    }
}
