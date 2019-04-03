﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    [Flags]
    public enum PRINTER_STATUS {

        PAUSED = 1,
        ERROR = 2,
        PENDING_DELETION = 4,
        PAPER_JAM = 8,
        PAPER_OUT = 0x10,
        MANUAL_FEED = 0x20,
        PAPER_PROBLEM = 0x40,
        OFFLINE = 0x80,
        IO_ACTIVE = 0x100,
        BUSY = 0x200,
        PRINTING = 0x400,
        OUTPUT_BIN_FULL = 0x800,
        NOT_AVAILABLE = 0x1000,
        WAITING = 0x2000,
        PROCESSING = 0x4000,
        INITIALIZING = 0x8000,
        WARMING_UP = 0x10000,
        TONER_LOW = 0x20000,
        NO_TONER = 0x40000,
        PAGE_PUNT = 0x80000,
        USER_INTERVENTION = 0x100000,
        OUT_OF_MEMORY = 0x200000,
        DOOR_OPEN = 0x400000,
        SERVER_UNKNOWN = 0x800000,
        POWER_SAVE = 0x1000000,

    }
}
