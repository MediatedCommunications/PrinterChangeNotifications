using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    public static class Win32 {

        public static IntPtr Invalid_Handle { get; private set; } = new IntPtr(-1);


        [DllImport("winspool.drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter(String pPrinterName,
            out IntPtr phPrinter,
            IntPtr pDefault
            );

        public static bool OpenPrinter(string pPrinterName, out IntPtr phPrinter) {
            return OpenPrinter(pPrinterName, out phPrinter, IntPtr.Zero);
        }


        [DllImport("winspool.drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter (IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "FindFirstPrinterChangeNotification", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr FindFirstPrinterChangeNotification(
            [In()] IntPtr hPrinter,
            [In()] UInt32 fwFlags,
            [In()] UInt32 fwOptions,
            [In(), MarshalAs(UnmanagedType.LPStruct)] PRINTER_NOTIFY_OPTIONS pPrinterNotifyOptions
            );

        [DllImport("winspool.drv", EntryPoint = "FindFirstPrinterChangeNotification", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr FindFirstPrinterChangeNotification(
            [In()] IntPtr hPrinter,
            [In()] UInt32 fwFlags,
            [In()] UInt32 fwOptions,
            [In()] IntPtr pPrinterNotifyOptions
            );


        public static IntPtr FindFirstPrinterChangeNotification(IntPtr hPrinter, PrinterEventType EventFilter, PrinterHardwareType HardwareFilter, Printer_Notify_Options Options) {
            var Arg1 = hPrinter;
            var Arg2 = (UInt32)EventFilter;
            var Arg3 = (UInt32)HardwareFilter;
            var Arg4 = Options.Convert(out var Allocated);

            //var Pointer = GCHandle.Alloc(Arg4, GCHandleType.Pinned);

            var ret = FindFirstPrinterChangeNotification(Arg1, Arg2, Arg3, Arg4);

            //Pointer.Free();
            Allocated.Free();

            return ret;
        }

        [DllImport("winspool.drv", EntryPoint = "FindNextPrinterChangeNotification", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern bool FindNextPrinterChangeNotification(
            [In()] IntPtr hChangeObject,
            [Out()] out Int32 pdwChange,
            [In(), MarshalAs(UnmanagedType.LPStruct)] PRINTER_NOTIFY_OPTIONS pPrinterNotifyOptions,
            [Out()] out IntPtr lppPrinterNotifyInfo
            );

        public static bool FindNextPrinterChangeNotification(IntPtr hChangeObject, Printer_Notify_Options Options, out PrinterEventType Cause, out Printer_Notify_Info Data) {
            var Arg1 = hChangeObject;
            var Arg3 = Options.Convert(out var Allocated);
            var ret = FindNextPrinterChangeNotification(Arg1, out var ICause, Arg3, out var NotifyPointer);
            Allocated.Free();

            Cause = (PrinterEventType)ICause;
            Data = default(Printer_Notify_Info);

            if (NotifyPointer != IntPtr.Zero) {
                var Parsed = PRINTER_NOTIFY_INFO.From(NotifyPointer);
                Data = Parsed.Convert();
                FreePrinterNotifyInfo(NotifyPointer);
            }

            return ret;
        }


        [DllImport("winspool.drv", EntryPoint = "FreePrinterNotifyInfo", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool FreePrinterNotifyInfo(
            [In] IntPtr NotifyInfo
            );


        [DllImport("winspool.drv", EntryPoint = "FindClosePrinterChangeNotification", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool FindClosePrinterChangeNotification(
            [In] IntPtr NotifyInfo
            );

    }
}
