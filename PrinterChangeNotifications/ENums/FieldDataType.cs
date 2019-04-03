using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    public enum FieldDataType {
        None,
        String,
        StringCommaList,
        PrinterStatus,
        PrinterAttributes,
        JobStatus,
        SecurityDescriptor,
        Number,
        DateTime,
        Time,
        Duration,
        

        //DevMode,
        NotImplemented,
    }
}
