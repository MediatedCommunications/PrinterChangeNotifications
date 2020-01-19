using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    public static partial class JobFieldDataType {

        public static FieldDataType DataType(this JobField This) {
            var ret = This switch {
                JobField.PrinterName => FieldDataType.String,
                JobField.MachineName => FieldDataType.String,
                JobField.UserName => FieldDataType.String,
                JobField.NotifyName => FieldDataType.String,
                JobField.DataType => FieldDataType.String,
                JobField.PrintProcessor => FieldDataType.String,
                JobField.Parameters => FieldDataType.String,
                JobField.DriverName => FieldDataType.String,
                JobField.StatusString => FieldDataType.String,
                JobField.Document => FieldDataType.String,

                JobField.PortName => FieldDataType.StringCommaList,

                JobField.Status => FieldDataType.JobStatus,

                JobField.Priority => FieldDataType.Number,
                JobField.Position => FieldDataType.Number,
                JobField.PagesTotal => FieldDataType.Number,
                JobField.PagesPrinted => FieldDataType.Number,
                JobField.BytesTotal => FieldDataType.Number,
                JobField.BytesPrinted => FieldDataType.Number,

                JobField.Submitted => FieldDataType.DateTime,

                JobField.StartTime => FieldDataType.Time,
                JobField.UntilTime => FieldDataType.Time,

                JobField.Time => FieldDataType.Duration,

                //Yes, the seucirty descriptor is not supported for jobs per https://docs.microsoft.com/en-us/windows/desktop/printdocs/printer-notify-info-data
                JobField.SecurityDescriptor => FieldDataType.NotSupported,

                JobField.DevMode => FieldDataType.DevMode,

                _ => FieldDataType.NotImplemented,
            };


            return ret;
        }

    }
}
