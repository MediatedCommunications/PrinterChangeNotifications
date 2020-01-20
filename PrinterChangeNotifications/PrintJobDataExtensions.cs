using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.NotifyInfo;
using PrinterChangeNotifications.Native.Security;
using System;
using System.Collections.Generic;

namespace PrinterChangeNotifications {
    public static class PrintJobDataExtensions {

        public static PrintJobRecord<T> TryGetRecord<T>(this PrintJobData This, PrintJobField Field) {
            This.TryGetRecord<T>(Field, out var ret);
            return ret;
        }

        public static bool TryGetRecord<T>(this PrintJobData This, PrintJobField Field, out PrintJobRecord<T> ret) {
            var success = This.PrintJob_Records.TryGetValue(Field, out var tret);

            ret = tret as PrintJobRecord<T>;

            return success;
        }

        public static PrintJobRecord<string> TryGetStringRecord(this PrintJobData This, PrintJobField Field) => This.TryGetRecord<string>(Field);
        public static PrintJobRecord<IReadOnlyCollection<string>> TryGetStringListRecord(this PrintJobData This, PrintJobField Field) => This.TryGetRecord<IReadOnlyCollection<string>>(Field);
        public static PrintJobRecord<uint> TryGetNumberRecord(this PrintJobData This, PrintJobField Field) => This.TryGetRecord<uint>(Field);
        public static PrintJobRecord<DateTime> TryGetDateRecord(this PrintJobData This, PrintJobField Field) => This.TryGetRecord<DateTime>(Field);
        public static PrintJobRecord<TimeSpan> TryGetDurationRecord(this PrintJobData This, PrintJobField Field) => This.TryGetRecord<TimeSpan>(Field);


        public static PrintJobRecord<string> PrintJob_PrinterName(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.PrinterName);
        public static PrintJobRecord<string> PrintJob_MachineName(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.MachineName);
        public static PrintJobRecord<string> PrintJob_UserName(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.UserName);
        public static PrintJobRecord<string> PrintJob_NotifyName(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.NotifyName);
        public static PrintJobRecord<string> PrintJob_DataType(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.DataType);
        public static PrintJobRecord<string> PrintJob_PrintProcessor(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.PrintProcessor);
        public static PrintJobRecord<string> PrintJob_Parameters(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.Parameters);
        public static PrintJobRecord<string> PrintJob_DriverName(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.DriverName);
        public static PrintJobRecord<string> PrintJob_StatusString(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.StatusString);
        public static PrintJobRecord<string> PrintJob_Document(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.Document);

        public static PrintJobRecord<IReadOnlyCollection<string>> PrintJob_PortName(this PrintJobData This) => This.TryGetStringListRecord(PrintJobField.PortName);

        public static PrintJobRecord<PrintJobStatus> PrintJob_Status(this PrintJobData This) => This.TryGetRecord<PrintJobStatus>(PrintJobField.Status);

        public static PrintJobRecord<uint> PrintJob_Priority(this PrintJobData This) => This.TryGetNumberRecord(PrintJobField.Priority);
        public static PrintJobRecord<uint> PrintJob_Position(this PrintJobData This) => This.TryGetNumberRecord(PrintJobField.Position);
        public static PrintJobRecord<uint> PrintJob_PagesTotal(this PrintJobData This) => This.TryGetNumberRecord(PrintJobField.PagesTotal);
        public static PrintJobRecord<uint> PrintJob_PagesPrinted(this PrintJobData This) => This.TryGetNumberRecord(PrintJobField.PagesPrinted);
        public static PrintJobRecord<uint> PrintJob_BytesTotal(this PrintJobData This) => This.TryGetNumberRecord(PrintJobField.BytesTotal);
        public static PrintJobRecord<uint> PrintJob_BytesPrinted(this PrintJobData This) => This.TryGetNumberRecord(PrintJobField.BytesPrinted);

        public static PrintJobRecord<DateTime> PrintJob_Submitted(this PrintJobData This) => This.TryGetDateRecord(PrintJobField.Submitted);
        
        public static PrintJobRecord<DateTime> PrintJob_StartTime(this PrintJobData This) => This.TryGetDateRecord(PrintJobField.StartTime);
        public static PrintJobRecord<DateTime> PrintJob_UntilTime(this PrintJobData This) => This.TryGetDateRecord(PrintJobField.UntilTime);
        
        public static PrintJobRecord<TimeSpan> PrintJob_Time(this PrintJobData This) => This.TryGetDurationRecord(PrintJobField.Time);

        public static PrintJobRecord<string> PrintJob_SecurityDescriptor(this PrintJobData This) => This.TryGetStringRecord(PrintJobField.SecurityDescriptor);

        public static PrintJobRecord<DevModeA> PrintJob_DevMode(this PrintJobData This) => This.TryGetRecord<DevModeA>(PrintJobField.DevMode);

    }


}
