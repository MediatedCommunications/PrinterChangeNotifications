using System;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(LayoutKind.Sequential)]
    public class PRINTER_NOTIFY_OPTIONS {
        public uint F1_Version;
        public uint F2_Flags;
        public uint F3_Count;
        public IntPtr F4_Children;

        public PRINTER_NOTIFY_OPTIONS() {
            F1_Version = 2;
            F2_Flags = 0;
            F3_Count = 0;
            F4_Children = IntPtr.Zero;
        }
    }

}
