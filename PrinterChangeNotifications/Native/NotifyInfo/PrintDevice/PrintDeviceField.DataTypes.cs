using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    public static partial class PrintDeviceField_DataTypes {

        public static NotifyInfoDataType DataType(this PrintDeviceField This) {
            var ret = This switch {
                PrintDeviceField.Printer_Name => NotifyInfoDataType.String,
                PrintDeviceField.Share_Name => NotifyInfoDataType.String,
                PrintDeviceField.Driver_Name => NotifyInfoDataType.String,
                PrintDeviceField.Comment => NotifyInfoDataType.String,
                PrintDeviceField.Location => NotifyInfoDataType.String,
                PrintDeviceField.SeparatorFile => NotifyInfoDataType.String,
                PrintDeviceField.PrintProcessor => NotifyInfoDataType.String,
                PrintDeviceField.Parameters => NotifyInfoDataType.String,
                PrintDeviceField.DataType => NotifyInfoDataType.String,

                PrintDeviceField.Port_Name => NotifyInfoDataType.StringCommaList,

                PrintDeviceField.Server_Name => NotifyInfoDataType.NotSupported,
                PrintDeviceField.Pages_Total => NotifyInfoDataType.NotSupported,
                PrintDeviceField.Pages_Printed => NotifyInfoDataType.NotSupported,
                PrintDeviceField.Bytes_Total => NotifyInfoDataType.NotSupported,
                PrintDeviceField.Bytes_Printed => NotifyInfoDataType.NotSupported,
                PrintDeviceField.StatusString => NotifyInfoDataType.NotSupported,

                PrintDeviceField.SecurityDescriptor => NotifyInfoDataType.SecurityDescriptor,


                PrintDeviceField.Priority => NotifyInfoDataType.Number,
                PrintDeviceField.PriorityDefault => NotifyInfoDataType.Number,
                PrintDeviceField.JobsQueued => NotifyInfoDataType.Number,
                PrintDeviceField.Pages_AveragePerMinute => NotifyInfoDataType.Number,

                PrintDeviceField.StartTime => NotifyInfoDataType.Time,
                PrintDeviceField.UntilTime => NotifyInfoDataType.Time,

                PrintDeviceField.Attributes => NotifyInfoDataType.PrinterAttributes,
                PrintDeviceField.Status => NotifyInfoDataType.PrinterStatus,

                PrintDeviceField.DevMode => NotifyInfoDataType.DevMode,

                _ => NotifyInfoDataType.NotImplemented,
            };

            return ret;
        }

    }
}


