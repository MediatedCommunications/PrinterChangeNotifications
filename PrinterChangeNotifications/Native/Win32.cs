using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.NotifyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications.Native {
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
            [In(), MarshalAs(UnmanagedType.LPStruct)] NotifyOptions pPrinterNotifyOptions
            );

        [DllImport("winspool.drv", EntryPoint = "FindFirstPrinterChangeNotification", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr FindFirstPrinterChangeNotification(
            [In()] IntPtr hPrinter,
            [In()] UInt32 fwFlags,
            [In()] UInt32 fwOptions,
            [In()] IntPtr pPrinterNotifyOptions
            );


        public static IntPtr FindFirstPrinterChangeNotification(IntPtr hPrinter, PrintDeviceEvents EventFilter, PrintDeviceHardwareType HardwareFilter, Printer_Notify_Options2 Options) {
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
            [In(), MarshalAs(UnmanagedType.LPStruct)] NotifyOptions pPrinterNotifyOptions,
            [Out()] out IntPtr lppPrinterNotifyInfo
            );

        public static bool FindNextPrinterChangeNotification(IntPtr hChangeObject, Printer_Notify_Options2 Options, out PrintWatcherEventArgs Args) {
            var Arg1 = hChangeObject;
            var Arg3 = Options.Convert(out var Allocated);
            var ret = FindNextPrinterChangeNotification(Arg1, out var ICause, Arg3, out var NotifyPointer);
            Allocated.Free();

            var Cause = (PrintDeviceEvents)ICause;
            var Discarded = false;

            var PrintDevices = new Dictionary<uint, PrintDeviceData>();
            var PrintJobs = new Dictionary<uint, PrintJobData>();

            if (NotifyPointer != IntPtr.Zero) {
                var Parsed = NotifyInfo.NotifyInfo.From(NotifyPointer);

                Discarded = Parsed.Header.Flags.HasFlag(NotifyInfoFlags.Discarded);
                //We must call ToList because that forces enumeration.
                var AllRecords = Parsed.Data.ToRecords().ToList();
                FreePrinterNotifyInfo(NotifyPointer);




                foreach (var Record in AllRecords) {
                    if(Record is PrintDeviceRecord V1) {
                        if (!PrintDevices.TryGetValue(V1.DeviceID, out var Container)) {
                            Container = new PrintDeviceData();
                            PrintDevices[V1.DeviceID] = Container;
                        }

                        Container.PrintDevice_Records[V1.Name] = V1;

                        if (V1 is IRecordValue<DevMode.DevModeA> DM) { 
                            foreach(var item in DM.Value.AllRecords()) {
                                Container.DevMode_Records[item.Name] = item;
                            }
                        }


                    } else if (Record is PrintJobRecord V2) {
                        if (!PrintJobs.TryGetValue(V2.JobID, out var Container)) {
                            Container = new PrintJobData();
                            PrintJobs[V2.JobID] = Container;
                        }

                        Container.PrintJob_Records[V2.Name] = V2;

                        if (V2 is IRecordValue<DevMode.DevModeA> DM) {
                            foreach (var item in DM.Value.AllRecords()) {
                                Container.DevMode_Records[item.Name] = item;
                            }
                        }

                    }
                }


                

            }

            Args = new PrintWatcherEventArgs(Cause, Discarded, PrintDevices, PrintJobs);

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
