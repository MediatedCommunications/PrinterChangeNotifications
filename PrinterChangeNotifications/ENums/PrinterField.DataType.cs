using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    public static partial class PrinterFieldDataType {

        public static FieldDataType DataType(this PrinterField This) {
            var ret = This switch {
                PrinterField.PrinterName => FieldDataType.String,
                PrinterField.ShareName => FieldDataType.String,
                PrinterField.DriverName => FieldDataType.String,
                PrinterField.Comment => FieldDataType.String,
                PrinterField.Location => FieldDataType.String,
                PrinterField.SeparatorFile => FieldDataType.String,
                PrinterField.PrintProcessor => FieldDataType.String,
                PrinterField.Parameters => FieldDataType.String,
                PrinterField.DataType => FieldDataType.String,

                PrinterField.PortName => FieldDataType.StringCommaList,

                PrinterField.ServerName => FieldDataType.NotSupported,
                PrinterField.Pages_Total => FieldDataType.NotSupported,
                PrinterField.Pages_Printed => FieldDataType.NotSupported,
                PrinterField.Bytes_Total => FieldDataType.NotSupported,
                PrinterField.Bytes_Printed => FieldDataType.NotSupported,
                PrinterField.StatusString => FieldDataType.NotSupported,

                PrinterField.SecurityDescriptor => FieldDataType.SecurityDescriptor,


                PrinterField.Priority => FieldDataType.Number,
                PrinterField.PriorityDefault => FieldDataType.Number,
                PrinterField.JobsQueued => FieldDataType.Number,
                PrinterField.Pages_AveragePerMinute => FieldDataType.Number,

                PrinterField.StartTime => FieldDataType.Time,
                PrinterField.UntilTime => FieldDataType.Time,

                PrinterField.Attributes => FieldDataType.PrinterAttributes,
                PrinterField.Status => FieldDataType.PrinterStatus,

                PrinterField.DevMode => FieldDataType.DevMode,

                _ => FieldDataType.NotImplemented,
            };

            return ret;
        }

    }
}


