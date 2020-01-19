using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.NotifyInfo;
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

    public class DevModeData {
        public IDictionary<DevModeField, DevModeRecord> DevModeRecords { get; private set; } = new Dictionary<DevModeField, DevModeRecord>();

        public virtual IEnumerable<IRecord> AllRecords() {
            foreach (var item in DevModeRecords.Values) {
                yield return item;
            }
        }

        public DevModeRecord this[DevModeField Index] {
            get {
                DevModeRecords.TryGetValue(Index, out var ret);

                return ret;
            }
        }



    }

    public class PrintDeviceData : DevModeData {
        public IDictionary<PrintDeviceField, PrintDeviceRecord> PrintDeviceRecords { get; private set; } = new Dictionary<PrintDeviceField, PrintDeviceRecord>();

        public override IEnumerable<IRecord> AllRecords() {
            foreach (var item in base.AllRecords()) {
                yield return item;
            }

            foreach (var item in PrintDeviceRecords.Values) {
                yield return item;
            }

        }

        public PrintDeviceRecord this[PrintDeviceField Index] {
            get {
                PrintDeviceRecords.TryGetValue(Index, out var ret);

                return ret;
            }
        }

    }

    public class PrintJobData : DevModeData {
        public IDictionary<PrintJobField, PrintJobRecord> PrintJobRecords { get; private set; } = new Dictionary<PrintJobField, PrintJobRecord>();

        public override IEnumerable<IRecord> AllRecords() {
            foreach (var item in base.AllRecords()) {
                yield return item;
            }

            foreach (var item in PrintJobRecords.Values) {
                yield return item;
            }

        }

        public PrintJobRecord this[PrintJobField Index] {
            get {
                PrintJobRecords.TryGetValue(Index, out var ret);

                return ret;
            }
        }

    }
    

}
