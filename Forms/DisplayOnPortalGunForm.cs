using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static portal_demo_essentials.Utils;
using static portal_demo_essentials.Program;
using static portal_demo_essentials.Events;
using System.Windows.Forms;
using portal_demo_essentials.Source;
using portal_demo_essentials.Demo;

namespace portal_demo_essentials.Forms
{
    public partial class DisplayOnPortalGunForm : UserControl
    {
        private Texture _tex;
        public DisplayOnPortalGunForm()
        {
            InitializeComponent();

            Settings.Subscribe(
                "pgun_console_enable",
                s => { if (bool.TryParse(s, out bool e)) chkEnabled.Checked = e; },
                () => chkEnabled.Checked.ToString());

            Settings.Subscribe(
                "pgun_tex_path",
                s => boxPath.Path = s,
                () => boxPath.Path);

            Settings.Subscribe(
                "pgun_pos",
                s =>
                {
                    if (s.Split(' ') is var d && d.Length == 2)
                        if (int.TryParse(d[0], out int x) && int.TryParse(d[1], out int y))
                            boxWhere.Location = new Point(x, y);
                },
                () => $"{boxWhere.Location.X} {boxWhere.Location.Y}");

            Settings.Subscribe(
                "pgun_font",
                s =>
                {
                    if (s.Split('|') is var d && d.Length == 2)
                    {
                        if (!float.TryParse(d[1], out float x))
                            return;

                        boxFormat.Font = new Font(d[0], x);
                    }
                },
                () => $"{boxFormat.Font.Name}|{boxFormat.Font.Size}");

            Settings.Subscribe(
                "pgun_color",
                s =>
                {
                    if (s.Split(' ') is var d && d.Length == 3)
                        if (int.TryParse(d[0], out var r) &&
                            int.TryParse(d[1], out var g) &&
                            int.TryParse(d[2], out var b))
                            boxFormat.ForeColor = Color.FromArgb(r, g, b);
                },
                () => $"{boxFormat.ForeColor.R} {boxFormat.ForeColor.G} {boxFormat.ForeColor.B}");

            Settings.Subscribe(
                "pgun_format",
                s => boxFormat.Text = s,
                () => boxFormat.Text);

            Settings.Subscribe(
                "pgun_rot",
                s => nudRot.Value = decimal.TryParse(s, out var e) ? e : nudRot.Value,
                () => nudRot.Value.ToString());

            picText.MouseDown += (s, e) =>
            {
                boxWhere.Location = e.Location.Subtract(new Point(boxWhere.Width / 2, boxWhere.Height / 2));
            };
            boxWhere.MouseDown += (s, e) =>
            {
                boxWhere.Location = e.Location.Add(boxWhere.Location).Subtract(new Point(boxWhere.Width / 2, boxWhere.Height / 2)); ;
            };

            boxPath.BoxPath.TextChanged += (s, e) =>
            {
                var text = boxPath.Path;
                try
                {
                    Bitmap a = new Bitmap(text);
                    picText.Image = a;

                    _tex = new Texture(text);
                }
                catch { }
            };

            FinishDemoRecording += (object s, CommonEventArgs e) => 
            {
                this.ThreadAction(() =>
                {
                    if (!chkEnabled.Checked || _tex == null)
                        return;

                    var demo = (DemoFile)e.Data["demo"];
                    var ratio = (float)picText.Width / 1024f;
                    var loc = boxWhere.Location.Subtract(new Point(boxWhere.Width / 2, boxWhere.Height / 2));

                    _tex.DrawText(boxFormat.Text
                            .Replace("{time}", (demo.AdjustedTicks * 0.015f).ToString("0.000"))
                            .Replace("{ticks}", demo.AdjustedTicks.ToString())
                            .Replace("{name}", demo.Name)
                            ,
                        boxFormat.Font,
                        boxFormat.ForeColor,
                        (float)nudRot.Value,
                        (int)(loc.X / ratio),
                        (int)(loc.Y / ratio));

                    _tex.SaveToFile(@"T:\Speedrunning\Half-Life 2\Files\Source Unpack\portal\materials\models\weapons\v_models\v_portalgun\v_portalgun.vtf");

                    WinAPI.SendMessage(Program.Monitor.Game, @"mat_reloadmaterial v_portalgun");
                });                
            };
        }

        private void butFont_Click(object sender, EventArgs e)
        {
            FontDialog diag = new FontDialog();
            diag.Font = boxFormat.Font;

            if (diag.ShowDialog() == DialogResult.OK)
                boxFormat.Font = diag.Font;
        }

        private void butColor_Click(object sender, EventArgs e)
        {
            ColorDialog diag = new ColorDialog();
            diag.Color = boxFormat.ForeColor;
            diag.AnyColor = true;

            if (diag.ShowDialog() == DialogResult.OK)
                boxFormat.ForeColor = diag.Color;
        }
    }
}
