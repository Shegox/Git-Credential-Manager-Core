using System;
using System.Runtime.InteropServices;

namespace Microsoft.Git.CredentialManager.Interop.Windows.Native
{
    public static class User32
    {
        private const string LibraryName = "user32.dll";

        public const int UOI_FLAGS = 1;
        public const int WSF_VISIBLE = 0x0001;

        [DllImport(LibraryName, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr GetProcessWindowStation();

        [DllImport(LibraryName, EntryPoint = "GetUserObjectInformation", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern unsafe bool GetUserObjectInformation(IntPtr hObj, int nIndex, void* pvBuffer, uint nLength, ref uint lpnLengthNeeded);

        [DllImport(LibraryName, EntryPoint="SetWindowLong", SetLastError = true)]
        private static extern IntPtr SetWindowLongPtr32(IntPtr hWnd, int nIndex, IntPtr value);

        [DllImport(LibraryName, EntryPoint="SetWindowLongPtr", SetLastError = true)]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr value);

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr value)
        {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, value);
            else
                return SetWindowLongPtr32(hWnd, nIndex, value);
        }

        [DllImport(LibraryName, SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport(LibraryName, SetLastError = true)]
        public static extern bool GetClientRect(IntPtr hwnd, out RECT lpRect);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct USEROBJECTFLAGS
    {
        public int fInherit;
        public int fReserved;
        public int dwFlags;
    }

    public enum WindowLongParam
    {
        GWL_WNDPROC = -4,
        GWL_HINSTANCE = -6,
        GWL_HWNDPARENT = -8,
        GWL_ID = -12,
        GWL_STYLE = -16,
        GWL_EXSTYLE = -20,
        GWL_USERDATA = -21
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
}
