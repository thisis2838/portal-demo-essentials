using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_demo_essentials.Globals
{
    static class Defaults
    {
        public const int FlashDuration = 350;
        public static readonly double TickRate = 0.015d;
        public static readonly string EmptyUI = "--";
        public static readonly string TimeSpanLong = @"h\:mm\:ss\.fff";
        public static readonly List<string> GameProcessNames = new List<string>() { "hl2" };
        public static readonly int InitTick = int.MinValue;
        public static string Version => typeof(Program).Assembly.GetName().Version.ToString();
    }
}
