using System;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications {
    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO {
        public uint F1_Version;
        public uint F2_Flags;
        public uint F3_Count;
        public PRINTER_NOTIFY_INFO_DATA[] F4_Types;

        public static PRINTER_NOTIFY_INFO From(IntPtr Handle) {
            var Parsed = Marshal.PtrToStructure<PRINTER_NOTIFY_INFO_BASE>(Handle);

            var ret = new PRINTER_NOTIFY_INFO() {
                F1_Version = Parsed.F1_Version,
                F2_Flags = Parsed.F2_Flags,
                F3_Count = Parsed.F3_Count,
            };

            ret.F4_Types = new PRINTER_NOTIFY_INFO_DATA[ret.F3_Count];

            var TypePointer = Handle + (int) Marshal.OffsetOf<PRINTER_NOTIFY_INFO>(nameof(PRINTER_NOTIFY_INFO.F4_Types));

            ret.F4_Types = Marshal2.PtrToArray<PRINTER_NOTIFY_INFO_DATA>(TypePointer, ret.F3_Count);

            return ret;
        }
    }

    

}
