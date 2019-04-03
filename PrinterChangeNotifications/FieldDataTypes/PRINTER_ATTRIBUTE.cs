using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    [Flags]
    public enum PRINTER_ATTRIBUTE {
        Queued = 1,
        Direct = 2,
        Default = 4,
        Shared = 8,
    }
}
