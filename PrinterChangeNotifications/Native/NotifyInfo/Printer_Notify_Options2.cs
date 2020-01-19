using System;
using System.Collections.Generic;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    public class Printer_Notify_Options2 {
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

}
