using System.Collections.Generic;
using System.Linq;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    public class Printer_Notify_Options_Type_Job : Printer_Notify_Options_Type {

        public Printer_Notify_Options_Type_Job() {

        }

        public Printer_Notify_Options_Type_Job(IEnumerable<PrintJobField> Fields) {
            if (Fields != null) {
                this.Fields.AddRange(Fields);
            }
        }

        public List<PrintJobField> Fields { get; private set; } = new List<PrintJobField>();

        public override NotifyOptions2 Convert() {
            var ret = new NotifyOptions2() {
                F1_Type = (ushort)NotifyInfoFieldType.Job,
                F2_Reserved0 = 0,
                F3_Reserved1 = 0,
                F4_Reserved2 = 0,
                F5_Count = (uint)Fields.Count,
                F6_Children = Fields.Select(x => (ushort)x).ToArray(),
            };

            return ret;
        }
    }

}
