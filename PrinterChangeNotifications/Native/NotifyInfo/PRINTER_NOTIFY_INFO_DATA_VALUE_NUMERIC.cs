﻿using System.Runtime.InteropServices;

namespace PrinterChangeNotifications {
    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO_DATA_VALUE_NUMERIC {
        public uint Value1;
        public uint Value2;
    }


}
