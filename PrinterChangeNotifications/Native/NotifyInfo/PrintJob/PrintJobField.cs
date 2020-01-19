using System;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    public enum PrintJobField : ushort {
        PrinterName = 0,
        MachineName = 1,
        PortName = 2,
        UserName = 3,
        NotifyName = 4,
        DataType = 5,
        PrintProcessor = 6,
        Parameters = 7,
        DriverName = 8,
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
