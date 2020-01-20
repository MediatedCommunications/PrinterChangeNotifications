using PrinterChangeNotifications.Native;
using PrinterChangeNotifications.Native.DevMode;
using System.Collections.Generic;

namespace PrinterChangeNotifications {
    public class DevModeData {
        public IDictionary<DevModeField, DevModeRecord> DevMode_Records { get; private set; } = new Dictionary<DevModeField, DevModeRecord>();

        public virtual IEnumerable<IRecord> AllRecords() {
            foreach (var item in DevMode_Records.Values) {
                yield return item;
            }
        }

        public DevModeRecord this[DevModeField Index] {
            get {
                DevMode_Records.TryGetValue(Index, out var ret);

                return ret;
            }
        }
    }
    

}
