using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_demo_essentials
{
    static class Events
    {

        public static EventHandler<CommonEventArgs> FoundGameProcess;
        public static EventHandler<CommonEventArgs> LostGameProcess;
        public static EventHandler<CommonEventArgs> FinishDemoRecording;
        public static EventHandler<CommonEventArgs> BeginDemoRecording;
        public static EventHandler<CommonEventArgs> CurrentDemoTime;
    }

    public class CommonEventArgs : EventArgs
    {
        public Dictionary<string, object> Data = new Dictionary<string, object>();

        public CommonEventArgs(params (string, object)[] pairs)
        {
            pairs.ToList().ForEach(x => Data.Add(x.Item1, x.Item2));
        }
    }
}
