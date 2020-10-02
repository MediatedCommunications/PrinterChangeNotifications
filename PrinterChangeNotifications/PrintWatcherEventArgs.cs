using PrinterChangeNotifications.Native.NotifyInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PrinterChangeNotifications {
    [DebuggerDisplay(Debugger2.DebuggerDisplay)]
    public class PrintWatcherEventArgs {

        public PrintDeviceEvents Cause { get; private set; }
        public bool Discarded { get; private set; }

        public IReadOnlyDictionary<uint, PrintDeviceData> PrintDevices { get; private set; }
        public IReadOnlyDictionary<uint, PrintJobData> PrintJobs { get; private set; }

        public PrintWatcherEventArgs(PrintDeviceEvents Cause, bool Discarded, IReadOnlyDictionary<uint, PrintDeviceData> PrintDevices, IReadOnlyDictionary<uint, PrintJobData> PrintJobs) {
            this.Cause = Cause;
            this.Discarded = Discarded;
            this.PrintDevices = PrintDevices;
            this.PrintJobs = PrintJobs;
        }

        protected virtual string GetDebuggerDisplay() {
                return $@"{Cause} (Discarded: {Discarded})";
        }

    }
    

}
