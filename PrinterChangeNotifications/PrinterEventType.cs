using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    [Flags]
    public enum PrinterEventType : UInt32 {
        None = 0,

        Printer_Add = 1,
        Printer_Set = 2,
        Printer_Delete = 4,
        Printer_FailedConnection = 8,
        Printer = 0xFF,

        Job_Add = 0x100,
        Job_Set = 0x200,
        Job_Delete = 0x400,
        Job_Write = 0x800,
        Job = 0xFF00,

        Form_Add = 0x1_0000,
        Form_Set = 0x2_0000,
        Form_Delete = 0x4_0000,
        Form = 0x7_0000,

        Port_Add = 0x10_0000,
        Port_Configure = 0x20_0000,
        Port_Delete = 0x40_0000,
        Port = 0x70_0000,

        PrintProcessor_Add = 0x100_0000,
        PrintProcessor_Set = 0x200_0000,
        PrintProcessor_Delete = 0x400_0000,
        PrintProcessor = 0x700_0000,

        //Not included in 'All'
        PrintServer = 0x800_0000,

        Driver_Add = 0x1000_0000,
        Driver_Set = 0x2000_0000,
        Driver_Delete = 0x4000_0000,
        Driver = 0x7000_0000,

        TimeOut = 0x8000_0000,

        All = 0x7777_FFFF,
    }
}
