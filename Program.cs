using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using portal_demo_essentials.Demo;
using portal_demo_essentials.Forms;
using portal_demo_essentials.Source;

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

        private static MemoryMonitor _monitor;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Settings = new SettingsHandler();

            FormsMain = new MainForm();
            FormsCurDemo = new CurrentDemoForm();
            FormsAnalyze = new AnalyzeForm();
            FormsCurRun = new CurrentRunForm();
            FormsSettingsAbout = new SettingAboutForm();

            Settings.LoadSettings();

            Thread worker = new Thread(new ThreadStart(() => 
            {
                _monitor = new MemoryMonitor();
                _monitor.Start();
            }));
            worker.Start();

            Application.Run(FormsMain);
            worker.Abort();
        }
    }
}
