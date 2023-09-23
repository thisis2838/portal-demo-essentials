using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using portal_demo_essentials.Demo;
using portal_demo_essentials.Forms;
using portal_demo_essentials.Source;
using portal_demo_essentials.Utils;

namespace portal_demo_essentials
{
    static class Program
    {
        public static CurrentDemoForm FormsCurDemo;
        public static CurrentRunForm FormsCurRun;
        public static MainForm FormsMain;
        public static AnalyzeForm FormsAnalyze;
        public static SettingAboutForm FormsSettingsAbout;
        public static SettingsHandler Settings;
        public static CompactView FormsCompact;

        public static PrintToConsoleForm FormPrintToConsole;
        //public static DisplayOnPortalGunForm FormDisplayOnPortalGun;

        public static MemoryMonitor Monitor;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new Thread(new ThreadStart(() => CheckNewVersion())).Start();

            Settings = new SettingsHandler();

            FormsMain = new MainForm();
            FormsCurDemo = new CurrentDemoForm();
            FormsAnalyze = new AnalyzeForm();
            FormsCurRun = new CurrentRunForm();
            FormsSettingsAbout = new SettingAboutForm();
            FormsCompact = new CompactView();

            FormPrintToConsole = new PrintToConsoleForm();
            //FormDisplayOnPortalGun = new DisplayOnPortalGunForm();

            Settings.LoadSettings();

            Thread worker = new Thread(new ThreadStart(() => 
            {
                Monitor = new MemoryMonitor();
                Monitor.Start();
            }));
            worker.Start();

            Application.Run(FormsMain);
            worker.Abort();
        }

        private static void CheckNewVersion()
        {
            using (var web = new WebClient())
            {
                try
                {
                    string ver = web.DownloadString(@"https://raw.githubusercontent.com/thisis2838/portal-demo-essentials/main/current_version.txt");
                    Version cur = typeof(Program).Assembly.GetName().Version;
                    if (Version.Parse(ver) > cur)
                    {
                        if (MessageBox.Show($"A new update is available (new {ver}, cur: {cur})\r\nWould you like to open the download page?", "Update Available", MessageBoxButtons.YesNo)
                            == DialogResult.Yes)
                            Process.Start(@"https://github.com/thisis2838/portal-demo-essentials/releases");
                    }
                }
                catch { }
            }
        }
    }
}
