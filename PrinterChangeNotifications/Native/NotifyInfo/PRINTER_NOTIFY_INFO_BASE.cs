using System.Runtime.InteropServices;

namespace PrinterChangeNotifications {
    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO_BASE {
        public uint F1_Version;
        public uint F2_Flags;
        public uint F3_Count;
    }

    

}
