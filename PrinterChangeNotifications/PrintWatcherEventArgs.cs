using PrinterChangeNotifications.Native.NotifyInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PrinterChangeNotifications {
    [DebuggerDisplay(Debugger2.DebuggerDisplay)]
    public class PrintWatcherEventArgs {
        public PrintDeviceEvents Cause { get; set; }
        public bool Discarded { get; set; }

        public IDictionary<uint, PrintDeviceData> PrintDevices { get; private set; } = new Dictionary<uint, PrintDeviceData>();
        public IDictionary<uint, PrintJobData> PrintJobs { get; private set; } = new Dictionary<uint, PrintJobData>();

        protected virtual string DebuggerDisplay {
            get {
                return $@"{Cause} (Discarded: {Discarded})";
            }
        }

    }
    

}
