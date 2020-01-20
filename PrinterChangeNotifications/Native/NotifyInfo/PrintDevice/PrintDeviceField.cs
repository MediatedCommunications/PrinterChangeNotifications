using System;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    public enum PrintDeviceField : ushort {
        Server_Name = 0,
        Printer_Name = 1,
        Share_Name = 2,
        Port_Name = 3,
        Driver_Name = 4,
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
