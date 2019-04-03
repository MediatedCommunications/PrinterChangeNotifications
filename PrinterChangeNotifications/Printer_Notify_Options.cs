using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications {
    public class Printer_Notify_Options {
        public Printer_Notify_Options_Flags Flags { get; set; }
        public List<Printer_Notify_Options_Type> Children { get; private set; } = new List<Printer_Notify_Options_Type>();

        public PRINTER_NOTIFY_OPTIONS Convert(out List<IntPtr> Allocated) {
            Allocated = new List<IntPtr>();

            return Convert(Allocated);
        }

        public PRINTER_NOTIFY_OPTIONS Convert(List<IntPtr> Allocated) {
            var ret = new PRINTER_NOTIFY_OPTIONS() {
                F1_Version = 2,
                F2_Flags = (uint)Flags,
                F3_Count = (uint)Children.Count,
                F4_Children = Children.Convert(Allocated)
            };

            return ret;
        }
    }

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
