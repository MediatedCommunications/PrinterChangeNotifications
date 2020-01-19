using System;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO_DATA_HEADER {
        public uint Version;
        public Printer_Notify_Info_Flags Flags;
        public uint Count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO {
        public PRINTER_NOTIFY_INFO_DATA_HEADER Header;

        public PRINTER_NOTIFY_INFO_DATA[] Data;

        public static PRINTER_NOTIFY_INFO From(IntPtr Handle) {
            var Parsed = Marshal.PtrToStructure<PRINTER_NOTIFY_INFO_DATA_HEADER>(Handle);

            var ret = new PRINTER_NOTIFY_INFO() {
                Header = Parsed,
            };

            var TypePointer = Handle + (int) Marshal.OffsetOf<PRINTER_NOTIFY_INFO>(nameof(Data));

            ret.Data = Marshal2.PtrToArray<PRINTER_NOTIFY_INFO_DATA>(TypePointer, ret.Header.Count);

            return ret;
        }
    }

    

}
