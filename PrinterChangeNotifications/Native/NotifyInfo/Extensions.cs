using System.Collections.Generic;

namespace PrinterChangeNotifications {
    public static partial class Extensions {
        public static Printer_Notify_Info Convert(this PRINTER_NOTIFY_INFO This) {
            var ret = new Printer_Notify_Info();
            ret.Flags = (Printer_Notify_Info_Flags) This.F2_Flags;
            ret.Data.AddRange(This.F4_Types.Convert());
            return ret;
        }

        public static List<Printer_Notify_Info_Data> Convert(this IEnumerable<PRINTER_NOTIFY_INFO_DATA> This) {
            var ret = new List<Printer_Notify_Info_Data>();

            foreach (var item in This) {
                var NewItem = FieldDataParser.Parse(item);
                if (NewItem != null) {
                    ret.Add(NewItem);
                }
            }

            return ret;
        }

        

    }

    

}
