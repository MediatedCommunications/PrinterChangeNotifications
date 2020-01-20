using PrinterChangeNotifications.Native;
using PrinterChangeNotifications.Native.NotifyInfo;
using System.Collections.Generic;

namespace PrinterChangeNotifications {
    public class PrintJobData : DevModeData {
        public IDictionary<PrintJobField, PrintJobRecord> PrintJob_Records { get; private set; } = new Dictionary<PrintJobField, PrintJobRecord>();

        public override IEnumerable<IRecord> AllRecords() {
            foreach (var item in base.AllRecords()) {
                yield return item;
            }

            foreach (var item in PrintJob_Records.Values) {
                yield return item;
            }

        }

        public PrintJobRecord this[PrintJobField Index] {
            get {
                PrintJob_Records.TryGetValue(Index, out var ret);

                return ret;
            }
        }

    }
    

}
