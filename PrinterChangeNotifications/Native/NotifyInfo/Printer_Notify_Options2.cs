using System;
using System.Collections.Generic;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    public class Printer_Notify_Options2 {
        public NotifyOptionsFlags Flags { get; set; }
        public List<NotifyOptions2> Children { get; private set; } = new List<NotifyOptions2>();

        public NotifyOptions Convert(out List<IntPtr> Allocated) {
            Allocated = new List<IntPtr>();

            return Convert(Allocated);
        }

        public NotifyOptions Convert(List<IntPtr> Allocated) {
            var ret = new NotifyOptions() {
                Version = 2,
                Flags = Flags,
                Count = (uint)Children.Count,
                Children = Children.ToPointerArray(Allocated)
            };

            return ret;
        }
    }

}
