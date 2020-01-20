using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.SystemTime;
using PrinterChangeNotifications.Native.NotifyInfo;
using PrinterChangeNotifications.Native.Security;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    public static partial class FieldDataParser {

        public static IEnumerable<IRecord> ToRecords(this IEnumerable<NotifyInfoData> This) {
            foreach (var item in This) {
                yield return item.ToRecord();
            }
        }

        public static IRecord ToRecord(this NotifyInfoData This) {
            var Type = This.F1_Type;

            IRecord ret = Type switch
            {
                NotifyInfoFieldType.Printer   =>  ParsePrintDevice(This),
                NotifyInfoFieldType.Job       =>  ParsePrintJob(This),
                _                   =>  default
            };

            return ret;
        }

        private static PrintDeviceRecord ParsePrintDevice(NotifyInfoData Item) {
            var Field = (PrintDeviceField)Item.F2_Field;
            var DataType = Field.DataType();
            var ID = Item.F4_Id;
            var Reserved = Item.F3_Reserved;

            var Value = Item.ParseValue(DataType);

            PrintDeviceRecord ret = Value switch
            {
                string                                  V1  => PrintDeviceRecord.Create(ID, Reserved, Field, V1),
                IReadOnlyCollection<string>             V1  => PrintDeviceRecord.Create(ID, Reserved, Field, V1),
                uint                                    V1  => PrintDeviceRecord.Create(ID, Reserved, Field, V1),
                PrintDeviceStatus                       V1  => PrintDeviceRecord.Create(ID, Reserved, Field, V1),
                PrintDeviceAttribute                    V1  => PrintDeviceRecord.Create(ID, Reserved, Field, V1),
                SecurityDescriptor                      V1  => PrintDeviceRecord.Create(ID, Reserved, Field, V1),
                DateTime                                V1  => PrintDeviceRecord.Create(ID, Reserved, Field, V1),
                TimeSpan                                V1  => PrintDeviceRecord.Create(ID, Reserved, Field, V1),
                DevModeA                                V1  => PrintDeviceRecord.Create(ID, Reserved, Field, V1),
                _                                           => default
            };

            return ret;
        }

        private static PrintJobRecord ParsePrintJob(NotifyInfoData Item) {
            var Field = (PrintJobField)Item.F2_Field;
            var DataType = Field.DataType();
            var ID = Item.F4_Id;
            var Reserved = Item.F3_Reserved;

            var Value = Item.ParseValue(DataType);

            PrintJobRecord ret = Value switch
            {
                string                                  V1  => PrintJobRecord.Create(ID, Reserved, Field, V1),
                IReadOnlyCollection<string>             V1  => PrintJobRecord.Create(ID, Reserved, Field, V1),
                uint                                    V1  => PrintJobRecord.Create(ID, Reserved, Field, V1),
                PrintJobStatus                          V1  => PrintJobRecord.Create(ID, Reserved, Field, V1),
                SecurityDescriptor                      V1  => PrintJobRecord.Create(ID, Reserved, Field, V1),
                DateTime                                V1  => PrintJobRecord.Create(ID, Reserved, Field, V1),
                TimeSpan                                V1  => PrintJobRecord.Create(ID, Reserved, Field, V1),
                DevModeA                                V1  => PrintJobRecord.Create(ID, Reserved, Field, V1),
                _                                           => default
            };

            return ret;
        }

        

        public static object ParseValue(this NotifyInfoData This, NotifyInfoDataType DataType) {

            object ret = DataType switch {
                NotifyInfoDataType.None => $@"This field has no data type",
                NotifyInfoDataType.NotSupported => $@"Windows does not support retreiving the value of this field",

                NotifyInfoDataType.String => This.ParseString(),
                NotifyInfoDataType.StringCommaList => This.ParseStringCommaList(),
                NotifyInfoDataType.JobStatus => This.ParseEnum<PrintJobStatus>(),
                NotifyInfoDataType.PrinterStatus => This.ParseEnum<PrintDeviceStatus>(),
                NotifyInfoDataType.PrinterAttributes => This.ParseEnum<PrintDeviceAttribute>(),
                NotifyInfoDataType.SecurityDescriptor => This.ParseSecurityDescriptor(),
                NotifyInfoDataType.Number => This.ParseNumber(),
                NotifyInfoDataType.DateTime => This.ParseDateTime(),
                NotifyInfoDataType.Time => This.ParseTime(),
                NotifyInfoDataType.Duration => This.ParseDuration(),
                NotifyInfoDataType.DevMode => This.ParseDevMode(),

                _ => $@"{DataType} has not been implemented"
            };

            return ret;
        }

        private static string ParseString(this NotifyInfoData This) {
            var ret = "";
            if (This.F5_NotifyData.PointerData.Address != IntPtr.Zero) {
                ret = Marshal.PtrToStringAnsi(This.F5_NotifyData.PointerData.Address);
            }
            return ret;
        }

        private static IReadOnlyCollection<string> ParseStringCommaList(this NotifyInfoData This) {
            return new System.Collections.ObjectModel.ReadOnlyCollection<string>(This.ParseString().Split(','));
        }

        private static SecurityDescriptor ParseSecurityDescriptor(this NotifyInfoData This) {
            var ret = default(SecurityDescriptor);
            if (This.F5_NotifyData.PointerData.Address != IntPtr.Zero) {
                ret = Marshal.PtrToStructure<SecurityDescriptor>(This.F5_NotifyData.PointerData.Address);
            }
            return ret;
        }

        private static T ParseEnum<T>(this NotifyInfoData This) where T : struct {
            var ret = default(T);

            ret = (T)Enum.ToObject(typeof(T), This.F5_NotifyData.NumericData.Value1);

            return ret;
        }

        private static uint ParseNumber(this NotifyInfoData This) {

            var ret = This.F5_NotifyData.NumericData.Value1;

            return ret;
        }

        private static DateTime ParseDateTime(this NotifyInfoData This) {
            var ret = default(DateTime);
            if(This.F5_NotifyData.PointerData.Address != IntPtr.Zero) {
                var tret = Marshal.PtrToStructure<SystemTime.SystemTime>(This.F5_NotifyData.PointerData.Address);
                ret = new DateTime(tret.Year, tret.Month, tret.Day, tret.Hour, tret.Minute, tret.Second, tret.Milliseconds);
            }

            return ret;
        }

        private static DateTime ParseTime(this NotifyInfoData This) {
            var ret = default(DateTime).AddMinutes(This.F5_NotifyData.NumericData.Value1);

            return ret;
        }

        private static TimeSpan ParseDuration(this NotifyInfoData This) {
            var ret = TimeSpan.FromSeconds(This.F5_NotifyData.NumericData.Value1);

            return ret;
        }

        private static DevModeA ParseDevMode(this NotifyInfoData This) {
            var ret = default(DevModeA);
            if (This.F5_NotifyData.PointerData.Address != IntPtr.Zero) {
                ret = Marshal.PtrToStructure<DevModeA>(This.F5_NotifyData.PointerData.Address);
            }

            return ret;
        }

    }
}
