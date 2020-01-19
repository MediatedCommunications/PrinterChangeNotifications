using System;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO_DATA_VALUE_POINTER {
        public uint Size;
        public IntPtr Address;

    }


}
