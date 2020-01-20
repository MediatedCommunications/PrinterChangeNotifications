using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.NotifyInfo;
using PrinterChangeNotifications.Native.Security;
using System;
using System.Collections.Generic;

namespace PrinterChangeNotifications {
    public static class PrintDeviceDataExtensions {

        public static PrintDeviceRecord<T> TryGetRecord<T>(this PrintDeviceData This, PrintDeviceField Field) {
            This.TryGetRecord<T>(Field, out var ret);
            return ret;
        }

        public static bool TryGetRecord<T>(this PrintDeviceData This, PrintDeviceField Field, out PrintDeviceRecord<T> ret) {
            var success = This.PrintDevice_Records.TryGetValue(Field, out var tret);

            ret = tret as PrintDeviceRecord<T>;

            return success;
        }

        public static PrintDeviceRecord<string> TryGetStringRecord(this PrintDeviceData This, PrintDeviceField Field) => This.TryGetRecord<string>(Field);
        public static PrintDeviceRecord<IReadOnlyCollection<string>> TryGetStringListRecord(this PrintDeviceData This, PrintDeviceField Field) => This.TryGetRecord<IReadOnlyCollection<string>>(Field);
        public static PrintDeviceRecord<uint> TryGetNumberRecord(this PrintDeviceData This, PrintDeviceField Field) => This.TryGetRecord<uint>(Field);
        public static PrintDeviceRecord<DateTime> TryGetDateRecord(this PrintDeviceData This, PrintDeviceField Field) => This.TryGetRecord<DateTime>(Field);


        public static PrintDeviceRecord<string> PrintDevice_PrinterName(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Printer_Name);
        public static PrintDeviceRecord<string> PrintDevice_ShareName(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Share_Name);
        public static PrintDeviceRecord<string> PrintDevice_DriverName(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Driver_Name);
        public static PrintDeviceRecord<string> PrintDevice_Comment(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Comment);
        public static PrintDeviceRecord<string> PrintDevice_Location(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Location);
        public static PrintDeviceRecord<string> PrintDevice_SeparatorFile(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.SeparatorFile);
        public static PrintDeviceRecord<string> PrintDevice_PrintProcessor(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.PrintProcessor);
        public static PrintDeviceRecord<string> PrintDevice_Parameters(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Parameters);
        public static PrintDeviceRecord<string> PrintDevice_DataType(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.DataType);
        
        public static PrintDeviceRecord<IReadOnlyCollection<string>> PrintDevice_PortName(this PrintDeviceData This) => This.TryGetStringListRecord(PrintDeviceField.Port_Name);

        public static PrintDeviceRecord<SecurityDescriptor> PrintDevice_SecurityDescriptor(this PrintDeviceData This) => This.TryGetRecord<SecurityDescriptor>(PrintDeviceField.SecurityDescriptor);

        public static PrintDeviceRecord<string> PrintDevice_ServerName(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Server_Name);
        public static PrintDeviceRecord<string> PrintDevice_Pages_Total(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Pages_Total);
        public static PrintDeviceRecord<string> PrintDevice_Pages_Printed(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Pages_Printed);
        public static PrintDeviceRecord<string> PrintDevice_Bytes_Total(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Bytes_Total);
        public static PrintDeviceRecord<string> PrintDevice_Bytes_Printed(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.Bytes_Printed);
        public static PrintDeviceRecord<string> PrintDevice_StatusString(this PrintDeviceData This) => This.TryGetStringRecord(PrintDeviceField.StatusString);

        public static PrintDeviceRecord<uint> PrintDevice_Priority(this PrintDeviceData This) => This.TryGetNumberRecord(PrintDeviceField.Priority);
        public static PrintDeviceRecord<uint> PrintDevice_Priority_Default(this PrintDeviceData This) => This.TryGetNumberRecord(PrintDeviceField.PriorityDefault);
        public static PrintDeviceRecord<uint> PrintDevice_JobsQueued(this PrintDeviceData This) => This.TryGetNumberRecord(PrintDeviceField.JobsQueued);
        public static PrintDeviceRecord<uint> PrintDevice_Pages_AveragePerMinute(this PrintDeviceData This) => This.TryGetNumberRecord(PrintDeviceField.Pages_AveragePerMinute);

        public static PrintDeviceRecord<DateTime> PrintDevice_StartTime(this PrintDeviceData This) => This.TryGetDateRecord(PrintDeviceField.StartTime);
        public static PrintDeviceRecord<DateTime> PrintDevice_UntilTime(this PrintDeviceData This) => This.TryGetDateRecord(PrintDeviceField.UntilTime);


        public static PrintDeviceRecord<PrintDeviceAttribute> PrintDevice_Attributes(this PrintDeviceData This) => This.TryGetRecord<PrintDeviceAttribute>(PrintDeviceField.Attributes);
        public static PrintDeviceRecord<PrintDeviceStatus> PrintDevice_Status(this PrintDeviceData This) => This.TryGetRecord<PrintDeviceStatus>(PrintDeviceField.Status);
        public static PrintDeviceRecord<DevModeA> PrintDevice_DevMode(this PrintDeviceData This) => This.TryGetRecord<DevModeA>(PrintDeviceField.DevMode);

    }


}
