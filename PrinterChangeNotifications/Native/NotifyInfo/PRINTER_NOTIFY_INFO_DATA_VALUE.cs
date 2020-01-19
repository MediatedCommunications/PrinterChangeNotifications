using System.Runtime.InteropServices;

namespace PrinterChangeNotifications {
    [StructLayout(LayoutKind.Explicit)]
    public struct PRINTER_NOTIFY_INFO_DATA_VALUE {
        [FieldOffset(0)]
        public PRINTER_NOTIFY_INFO_DATA_VALUE_NUMERIC NumericData;

        [FieldOffset(0)]
        public PRINTER_NOTIFY_INFO_DATA_VALUE_POINTER PointerData;
    }


}
