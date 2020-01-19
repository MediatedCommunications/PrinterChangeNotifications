using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.NotifyInfo;
using System.Collections.Generic;

namespace PrinterChangeNotifications {

    public class PrintEventWatcherStartArgs {
        public bool GetAllFieldsOnChange { get; set; }

        public string PrintDeviceName { get; set; }

        public List<PrintDeviceEvents> PrintDeviceEvents { get; private set; } = new List<PrintDeviceEvents>();
        public PrintDeviceHardwareType PrintDeviceHardwareType { get; set; }
        public List<PrintDeviceField> PrintDeviceFields { get; private set; } = new List<PrintDeviceField>();


        public List<PrintJobField> PrintJobFields { get; private set; } = new List<PrintJobField>();


    }

}
