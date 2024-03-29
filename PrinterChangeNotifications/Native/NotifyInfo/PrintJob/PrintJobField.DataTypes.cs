﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    public static partial class PrintJobField_DataTypes {

        public static NotifyInfoDataType DataType(this PrintJobField This) {
            var ret = This switch {
                PrintJobField.Printer_Name => NotifyInfoDataType.String,
                PrintJobField.Machine_Name => NotifyInfoDataType.String,
                PrintJobField.User_Name => NotifyInfoDataType.String,
                PrintJobField.Notify_Name => NotifyInfoDataType.String,
                PrintJobField.DataType => NotifyInfoDataType.String,
                PrintJobField.PrintProcessor => NotifyInfoDataType.String,
                PrintJobField.Parameters => NotifyInfoDataType.String,
                PrintJobField.Driver_Name => NotifyInfoDataType.String,
                PrintJobField.StatusString => NotifyInfoDataType.String,
                PrintJobField.Document => NotifyInfoDataType.String,

                PrintJobField.Port_Name => NotifyInfoDataType.StringCommaList,

                PrintJobField.Status => NotifyInfoDataType.JobStatus,

                PrintJobField.Priority => NotifyInfoDataType.Number,
                PrintJobField.Position => NotifyInfoDataType.Number,
                PrintJobField.PagesTotal => NotifyInfoDataType.Number,
                PrintJobField.PagesPrinted => NotifyInfoDataType.Number,
                PrintJobField.BytesTotal => NotifyInfoDataType.Number,
                PrintJobField.BytesPrinted => NotifyInfoDataType.Number,

                PrintJobField.Submitted => NotifyInfoDataType.DateTime,

                PrintJobField.StartTime => NotifyInfoDataType.Time,
                PrintJobField.UntilTime => NotifyInfoDataType.Time,

                PrintJobField.Time => NotifyInfoDataType.Duration,

                //Yes, the seucirty descriptor is not supported for jobs per https://docs.microsoft.com/en-us/windows/desktop/printdocs/printer-notify-info-data
                PrintJobField.SecurityDescriptor => NotifyInfoDataType.NotSupported,

                PrintJobField.DevMode => NotifyInfoDataType.DevMode,

                _ => NotifyInfoDataType.NotImplemented,
            };


            return ret;
        }

    }
}
