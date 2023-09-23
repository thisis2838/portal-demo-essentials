using portal_demo_essentials.Globals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace portal_demo_essentials.Utils
{
    public static class Helpers
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

        public static void ThreadAction(this Control form, Action action)
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

        public static T EnumValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            return default(T);
        }

        public static void FillComboBoxWithEnumDesc<T>(this ComboBox box) where T : Enum
        {
            box.Items.Clear();
            foreach (T member in Enum.GetValues(typeof(T)))
                box.Items.Add(member.GetDescription());
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static T EnumParse<T>(string s) where T : Enum
        {
            try { return (T)Enum.Parse(typeof(T), s); }
            catch { return default(T); }
        }

        public static Point AbsolutePosition(this Control ctrl)
        {
            var control = ctrl;
            Point p = control.Location;

            while (control.Parent != null)
            {
                p = Add(control.Parent.Location, p);
                control = control.Parent; 
            }
            return p;
        }

        public static Point Add(this Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
        public static Point Subtract(this Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y);

        public static (Point A, Point B, Point C, Point D) RotatedOriginAnchoredRect(Size size, float angle)
        {
            double angR = angle / 360f * 2 * Math.PI;

            Point rot(Point __p, double ang) => new Point(
                (int)(__p.X * Math.Cos(ang) - __p.Y * Math.Sin(ang)),
                (int)(__p.X * Math.Sin(ang) + __p.Y * Math.Cos(ang)));

            /*
            a-----------b
            |           |
            |           |
            d-----------c    
            
            a is origin
            ab is Ox
            da is Oy
            */

            Point a = new Point(0, 0);
            Point b = new Point(size.Width, 0);
            Point c = new Point(size.Width, -size.Height);
            Point d = new Point(0, -size.Height);

            Point _b = rot(b, angR);
            Point _c = rot(c, angR);
            Point _d = rot(d, angR);

            return (a, _b, _c, _d);

        }

        public static Size RotatedSize(Size size, float angle)
        {
            var rect = RotatedOriginAnchoredRect(size, angle);
            var points = new List<Point>() { rect.A, rect.B, rect.C, rect.D };

            int newWidth = Math.Abs(points.Max(x => x.X) - points.Min(x => x.X));
            int newHeight = Math.Abs(points.Max(x => x.Y) - points.Min(x => x.Y));

            return new Size(newWidth, newHeight);
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
                    _control.BackColor = Helpers.BiasedAverageColor(orig, color, (int)(sw.ElapsedMilliseconds / (float)time * 100));
                    Thread.Sleep(10);
                }

            }));

            _thread.Start();
        }
    }
}
