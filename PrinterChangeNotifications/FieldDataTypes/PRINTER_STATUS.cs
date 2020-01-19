using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    [Flags]
    public enum PRINTER_STATUS {

        Paused = 1,
        Error = 2,
        Pending_Deletion = 4,
        Paper_Jam = 8,
        Paper_Empty = 0x10,
        ManualFeed = 0x20,
        Paper_Problem = 0x40,
        Offline = 0x80,
        IO_Active = 0x100,
        Busy = 0x200,
        Printing = 0x400,
        OutputBinFull = 0x800,
        NotAvailable = 0x1000,
        Waiting = 0x2000,
        Processing = 0x4000,
        Initializing = 0x8000,
        WarmingUp = 0x10000,
        Toner_Low = 0x20000,
        Toner_Empty = 0x40000,
        PagePunt = 0x80000,
        UserIntervention = 0x100000,
        OutOfMemory = 0x200000,
        DoorOpen = 0x400000,
        ServerUnknown = 0x800000,
        PowerSave = 0x1000000,

    }
}
