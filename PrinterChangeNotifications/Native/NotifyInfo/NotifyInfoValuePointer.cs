using System;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(LayoutKind.Sequential)]
    public struct NotifyInfoValuePointer {
        public uint Size;
        public IntPtr Address;

    }


}
