using System;
using System.Runtime.InteropServices;

namespace Infinity_TestMod.Util
{
    public static class NativeCursor
    {
        [DllImport("user32.dll")]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("user32.dll")]
        private static extern IntPtr SetCursor(IntPtr hCursor);

        // Standard Win32 cursor IDs
        private const int IDC_SIZENWSE = 32642; // ↘↖
        private const int IDC_SIZENESW = 32643; // ↗↙
        private const int IDC_SIZEWE   = 32644; // ↔
        private const int IDC_SIZENS   = 32645; // ↕
        private const int IDC_ARROW    = 32512;

        public static void SetNWSE()       => SetCursor(LoadCursor(IntPtr.Zero, IDC_SIZENWSE));
        public static void SetNESW()       => SetCursor(LoadCursor(IntPtr.Zero, IDC_SIZENESW));
        public static void SetHorizontal() => SetCursor(LoadCursor(IntPtr.Zero, IDC_SIZEWE));
        public static void SetVertical()   => SetCursor(LoadCursor(IntPtr.Zero, IDC_SIZENS));
        public static void SetArrow()      => SetCursor(LoadCursor(IntPtr.Zero, IDC_ARROW));
    }
}
