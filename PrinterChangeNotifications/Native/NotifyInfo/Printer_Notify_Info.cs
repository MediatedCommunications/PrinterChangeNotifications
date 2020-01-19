using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {

    public class Printer_Notify_Info {
        public Printer_Notify_Info_Flags Flags { get; set; }
        public List<Printer_Notify_Info_Data> Data { get; private set; } = new List<Printer_Notify_Info_Data>();
    }

    

}
