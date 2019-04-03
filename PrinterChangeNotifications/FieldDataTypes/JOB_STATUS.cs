using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    [Flags]
    public enum JOB_STATUS {
        PAUSED = 1,
        ERROR = 2,
        DELETING = 4,
        SPOOLING = 8,
        PRINTING = 16,
        OFFLINE = 32,
        PAPEROUT = 0x40,
        PRINTED = 0x80,
        DELETED = 0x100,
        BLOCKED_DEVQ = 0x200,
        USER_INTERVENTION = 0x400,
    }
}
