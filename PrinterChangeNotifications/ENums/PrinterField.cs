using System;

namespace PrinterChangeNotifications {
    public enum PrinterField : ushort {
        ServerName = 0,
        PrinterName = 1,
        ShareName = 2,
        PortName = 3,
        DriverName = 4,
        Comment = 5,
        Location = 6,
        DevMode = 7,
        SeparatorFile = 8,
        PrintProcessor = 9,
        Parameters = 10,
        DataType = 11,
        SecurityDescriptor = 12,
        Attributes = 13,
        Priority = 14,
        PriorityDefault = 15,
        StartTime = 16,
        UntilTime = 17,
        Status = 18,
        StatusString = 19,
        JobsQueued = 20,
        Pages_AveragePerMinute = 21,
        Pages_Total = 22,
        Pages_Printed = 23,
        Bytes_Total = 24,
        Bytes_Printed = 25,
    }


}
