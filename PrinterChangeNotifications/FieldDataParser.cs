using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.SecurityDescriptor;
using PrinterChangeNotifications.Native.SystemTime;

namespace PrinterChangeNotifications {
    public static partial class FieldDataParser {

        public static Printer_Notify_Info_Data Parse(PRINTER_NOTIFY_INFO_DATA Item) {
            var Type = (FieldType)Item.F1_Type;

            var ret = Type switch
            {
                FieldType.Printer   =>  Parse<PrinterField>     (Item, Type, x => x.DataType()),
                FieldType.Job       =>  Parse<JobField>         (Item, Type, x => x.DataType()),
                _                   =>  default
            };

            return ret;
        }

        private static Printer_Notify_Info_Data Parse<TFieldType>(PRINTER_NOTIFY_INFO_DATA Item, FieldType Type, Func<TFieldType, FieldDataType> GetDataType) {
            var Field = (TFieldType)Enum.ToObject(typeof(TFieldType), Item.F2_Field);
            var DataType = GetDataType(Field);
            var ID = Item.F4_Id;
            var Reserved = Item.F3_Reserved;


            Printer_Notify_Info_Data ret;
            switch (DataType) {
                case FieldDataType.None: {
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, ID, Reserved);
                        break;
                    }

                case FieldDataType.String: {
                        var Value = Item.ParseString();
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }

                case FieldDataType.StringCommaList: {
                        var Value = (IReadOnlyCollection<String>)Item.ParseString().Split(',');
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }

                case FieldDataType.JobStatus: {
                        var Value = Item.ParseEnum<JOB_STATUS>();
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }

                case FieldDataType.PrinterStatus: {
                        var Value = Item.ParseEnum<PRINTER_STATUS>();
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }

                case FieldDataType.PrinterAttributes: {
                        var Value = Item.ParseEnum<PRINTER_ATTRIBUTE>();
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }


                case FieldDataType.SecurityDescriptor: {
                        var Value = Item.ParseSecurityDescriptor();
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }

                case FieldDataType.Number: {
                        var Value = Item.ParseNumber();
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }

                case FieldDataType.DateTime: {
                        var Value = Item.ParseDateTime();
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }


                case FieldDataType.Time: {
                        var Value = Item.ParseTime();
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }

                case FieldDataType.Duration: {
                        var Value = Item.ParseDuration();
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }

                case FieldDataType.DevMode: {
                        var Value = Item.ParseDevMode();
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, Value, ID, Reserved);
                        break;
                    }

                default: {
                        ret = Printer_Notify_Info_Data.Create(Type, DataType, Field, ID, Reserved);
                        break;
                    }
            }

            return ret;
        }

        public static string ParseString(this PRINTER_NOTIFY_INFO_DATA This) {
            var ret = "";
            if (This.F5_NotifyData.PointerData.Address != IntPtr.Zero) {
                ret = Marshal.PtrToStringAnsi(This.F5_NotifyData.PointerData.Address);
            }
            return ret;
        }

        public static SecurityDescriptor ParseSecurityDescriptor(this PRINTER_NOTIFY_INFO_DATA This) {
            var ret = default(SecurityDescriptor);
            if (This.F5_NotifyData.PointerData.Address != IntPtr.Zero) {
                ret = Marshal.PtrToStructure<SecurityDescriptor>(This.F5_NotifyData.PointerData.Address);
            }
            return ret;
        }

        public static T ParseEnum<T>(this PRINTER_NOTIFY_INFO_DATA This) where T : struct {
            var ret = default(T);

            ret = (T)Enum.ToObject(typeof(T), This.F5_NotifyData.NumericData.Value1);

            return ret;
        }

        public static uint ParseNumber(this PRINTER_NOTIFY_INFO_DATA This) {

            var ret = This.F5_NotifyData.NumericData.Value1;

            return ret;
        }

        public static DateTime ParseDateTime(this PRINTER_NOTIFY_INFO_DATA This) {
            var ret = default(DateTime);
            if(This.F5_NotifyData.PointerData.Address != IntPtr.Zero) {
                var tret = Marshal.PtrToStructure<SystemTime>(This.F5_NotifyData.PointerData.Address);
                ret = new DateTime(tret.Year, tret.Month, tret.Day, tret.Hour, tret.Minute, tret.Second, tret.Milliseconds);
            }

            return ret;
        }

        public static DateTime ParseTime(this PRINTER_NOTIFY_INFO_DATA This) {
            var ret = default(DateTime).AddMinutes(This.F5_NotifyData.NumericData.Value1);

            return ret;
        }

        public static TimeSpan ParseDuration(this PRINTER_NOTIFY_INFO_DATA This) {
            var ret = TimeSpan.FromSeconds(This.F5_NotifyData.NumericData.Value1);

            return ret;
        }

        public static DevModeA ParseDevMode(this PRINTER_NOTIFY_INFO_DATA This) {
            var ret = default(DevModeA);
            if (This.F5_NotifyData.PointerData.Address != IntPtr.Zero) {
                ret = Marshal.PtrToStructure<DevModeA>(This.F5_NotifyData.PointerData.Address);
            }

            return ret;
        }

    }
}
