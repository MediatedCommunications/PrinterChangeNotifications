using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    public static partial class PrinterFieldDataParser {


        private static IDictionary<PrinterField, FieldDataType> DataTypeCache = new SortedDictionary<PrinterField, FieldDataType>() {
            [PrinterField.PRINTER_NAME] = FieldDataType.String,
            [PrinterField.SHARE_NAME] = FieldDataType.String,
            [PrinterField.DRIVER_NAME] = FieldDataType.String,
            [PrinterField.COMMENT] = FieldDataType.String,
            [PrinterField.LOCATION] = FieldDataType.String,
            [PrinterField.SEPARATOR_FILE] = FieldDataType.String,
            [PrinterField.PRINT_PROCESSOR] = FieldDataType.String,
            [PrinterField.PARAMETERS] = FieldDataType.String,
            [PrinterField.DATATYPE] = FieldDataType.String,

            [PrinterField.PORT_NAME] = FieldDataType.StringCommaList,

            [PrinterField.SERVER_NAME] = FieldDataType.None,
            [PrinterField.PAGES_TOTAL] = FieldDataType.None,
            [PrinterField.PAGES_PRINTED] = FieldDataType.None,
            [PrinterField.BYTES_TOTAL] = FieldDataType.None,
            [PrinterField.BYTES_PRINTED] = FieldDataType.None,
            [PrinterField.STATUS_STRING] = FieldDataType.None,

            [PrinterField.SECURITY_DESCRIPTOR] = FieldDataType.SecurityDescriptor,


            [PrinterField.PRIORITY] = FieldDataType.Number,
            [PrinterField.PRIORITY_DEFAULT] = FieldDataType.Number,
            [PrinterField.JOBS_QUEUED] = FieldDataType.Number,
            [PrinterField.PAGES_AVERAGE_PER_MINUTE] = FieldDataType.Number,

            [PrinterField.START_TIME] = FieldDataType.Time,
            [PrinterField.UNTIL_TIME] = FieldDataType.Time,

            [PrinterField.ATTRIBUTES] = FieldDataType.PrinterAttributes,
            [PrinterField.STATUS] = FieldDataType.PrinterStatus,

            [PrinterField.DEVMODE] = FieldDataType.NotImplemented,

        };

        public static FieldDataType DataType(this PrinterField This) {
            if(!DataTypeCache.TryGetValue(This, out var ret)) {
                ret = FieldDataType.NotImplemented;
            }

            return ret;
        }

    }
}


