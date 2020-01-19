using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO_DATA {
        public NotifyInfoFieldType F1_Type;
        public ushort F2_Field;
        public uint F3_Reserved;
        public uint F4_Id;
        public PRINTER_NOTIFY_INFO_DATA_VALUE F5_NotifyData;
    }


}
