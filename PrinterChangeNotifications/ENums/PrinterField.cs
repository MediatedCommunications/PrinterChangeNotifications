using System;

namespace PrinterChangeNotifications {
    public enum PrinterField : UInt16 {
        SERVER_NAME = 0,
        PRINTER_NAME = 1,
        SHARE_NAME = 2,
        PORT_NAME = 3,
        DRIVER_NAME = 4,
        COMMENT = 5,
        LOCATION = 6,
        DEVMODE = 7,
        SEPARATOR_FILE = 8,
        PRINT_PROCESSOR = 9,
        PARAMETERS = 10,
        DATATYPE = 11,
        SECURITY_DESCRIPTOR = 12,
        ATTRIBUTES = 13,
        PRIORITY = 14,
        PRIORITY_DEFAULT = 15,
        START_TIME = 16,
        UNTIL_TIME = 17,
        STATUS = 18,
        STATUS_STRING = 19,
        JOBS_QUEUED = 20,
        PAGES_AVERAGE_PER_MINUTE = 21,
        PAGES_TOTAL = 22,
        PAGES_PRINTED = 23,
        BYTES_TOTAL = 24,
        BYTES_PRINTED = 25,
    }


}
