using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace portal_demo_essentials
{
    public static class WinAPI
    {
        public const int WM_COPYDATA = 0x4a;

        [StructLayout(LayoutKind.Sequential)]
        private struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }
        [DllImport("User32")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, ref COPYDATASTRUCT lParam);
        public static void SendMessage(Process proc, string input)
        {
            if (proc == null || proc.HasExited || proc.Handle == IntPtr.Zero || input.Length == 0)
                return;

            input = input + "\0";

            var copy = new COPYDATASTRUCT()
            {
                cbData = input.Length,
                dwData = IntPtr.Zero,
                lpData = Marshal.StringToHGlobalAnsi(input)
            };
            int res = SendMessage(proc.MainWindowHandle, WM_COPYDATA, 0, ref copy);
        }
    }
}
