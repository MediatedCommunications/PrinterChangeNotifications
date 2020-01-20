using System;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    public enum PrintJobField : ushort {
        Printer_Name = 0,
        Machine_Name = 1,
        Port_Name = 2,
        User_Name = 3,
        Notify_Name = 4,
        DataType = 5,
        PrintProcessor = 6,
        Parameters = 7,
        Driver_Name = 8,
        DevMode = 9,
        Status = 10,
        StatusString = 11,
        SecurityDescriptor = 12,
        Document = 13,
        Priority = 14,
        Position = 15,
        Submitted = 16,
        StartTime = 17,
        UntilTime = 18,
        Time = 19,
        PagesTotal = 20,
        PagesPrinted = 21,
        BytesTotal = 22,
        BytesPrinted = 23,
    }


}
