using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    public static partial class JobFieldDataParser {

        private static Dictionary<JobField, FieldDataType> DataTypeCache = new Dictionary<JobField, FieldDataType>() {
            [JobField.PRINTER_NAME] = FieldDataType.String,
            [JobField.MACHINE_NAME] = FieldDataType.String,
            [JobField.USER_NAME] = FieldDataType.String,
            [JobField.NOTIFY_NAME] = FieldDataType.String,
            [JobField.DATATYPE] = FieldDataType.String,
            [JobField.PRINT_PROCESSOR] = FieldDataType.String,
            [JobField.PARAMETERS] = FieldDataType.String,
            [JobField.DRIVER_NAME] = FieldDataType.String,
            [JobField.STATUS_STRING] = FieldDataType.String,
            [JobField.DOCUMENT] = FieldDataType.String,

            [JobField.PORT_NAME] = FieldDataType.StringCommaList,

            [JobField.STATUS] = FieldDataType.JobStatus,



            [JobField.PRIORITY] = FieldDataType.Number,
            [JobField.POSITION] = FieldDataType.Number,
            [JobField.PAGES_TOTAL] = FieldDataType.Number,
            [JobField.PAGES_PRINTED] = FieldDataType.Number,
            [JobField.BYTES_TOTAL] = FieldDataType.Number,
            [JobField.BYTES_PRINTED] = FieldDataType.Number,

            [JobField.SUBMITTED] = FieldDataType.DateTime,

            [JobField.START_TIME] = FieldDataType.Time,
            [JobField.UNTIL_TIME] = FieldDataType.Time,

            [JobField.TIME] = FieldDataType.Duration,

            //Yes, the seucirty descriptor is not supported for jobs per https://docs.microsoft.com/en-us/windows/desktop/printdocs/printer-notify-info-data
            [JobField.SECURITY_DESCRIPTOR] = FieldDataType.NotImplemented,

            [JobField.DEVMODE] = FieldDataType.NotImplemented,

        };

        public static FieldDataType DataType(this JobField This) {
            if (!DataTypeCache.TryGetValue(This, out var ret)) {
                ret = FieldDataType.NotImplemented;
            }

            return ret;
        }

    }
}
