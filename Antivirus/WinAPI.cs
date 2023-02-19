using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
 This class was blindly copied from previous HW. For all intents and purposes
 it should be treated as a homebrew external library.
 */


namespace Antivirus
{
    internal class WinAPI
    {
        public static int SendQuitMessage(int hWnd)
        {
            return SendMessage(hWnd, 0x0010, 0, 0);
        }

        public static int FindWindowByWindowName(string windowName)
        {
            return FindWindow(null, windowName).ToInt32();
        }

        public static int FindWindowByClassName(string className)
        {
            return FindWindow(className, null).ToInt32();
        }

        public static string GetWindowClassName(int hWnd)
        {
            StringBuilder windowClassName = new StringBuilder(256);

            GetClassName((IntPtr)hWnd, windowClassName, windowClassName.Capacity);

            return windowClassName.ToString();
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string? lpClassName, string? lpWindowName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, String lpString);
    }
}
