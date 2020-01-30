using PrinterChangeNotifications.Exceptions;
using PrinterChangeNotifications.Native;
using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.NotifyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {

    public partial class PrintWatcher : IDisposable {

        private IntPtr PrinterHandle;
        private IntPtr EventHandle;
        private Printer_Notify_Options2 Options;

        private PrintWatcher() {

        }

        private bool Disposed;
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool Disposing) {
            if (Disposed) {
                return;
            }
                

            if (Disposing) {
                // Free any other managed objects here.
                //
            }

            Stop();
            Win32.ClosePrinter(PrinterHandle);
            Win32.FindClosePrinterChangeNotification(EventHandle);
            Disposed = true;
        }


        ~PrintWatcher() {
            Dispose(false);
        }


        private System.Threading.CancellationTokenSource TokenSource = new CancellationTokenSource();
        public void Stop() {
            TokenSource.Cancel();
        }



        public event EventHandler<PrintWatcherEventArgs> EventTriggered;
        private System.Threading.Thread Thread;
        private void Start() {
            Thread = new Thread(ThreadLoop);
            Thread.Start();
        }

        private void ThreadLoop() {
            var WaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(EventHandle, false);

            var Event = new ManualResetEvent(false) {
                SafeWaitHandle = WaitHandle
            };

            while (true) {
                var Handles = new WaitHandle[] {
                    Event,
                    TokenSource.Token.WaitHandle
                };

                var Index = System.Threading.WaitHandle.WaitAny(Handles);

                if(Handles[Index] == TokenSource.Token.WaitHandle) {
                    this.Dispose();
                    return;
                } else {

                    if(Win32.FindNextPrinterChangeNotification(EventHandle, Options, out var Args)) { 
                        EventTriggered?.Invoke(this, Args);
                    } else {
                        this.Dispose();
                        throw new UnableToLoadNextPrinterEventsEventsException();
                    }

                }

            }

            
        }


        public static PrintWatcher Start(PrintWatcherStartArgs StartInfo) {
            if(StartInfo == default) {
                throw new ArgumentNullException(nameof(StartInfo));
            }

            //Check to see if we asked for DevMode fields.
            //If we did, make sure that DevMode is a field we're retreiving
            var PrintDeviceFields = new List<PrintDeviceField>(StartInfo.PrintDeviceFields);
            
            var PrintJobFields = new List<PrintJobField>(StartInfo.PrintJobFields);
            

            //Determine our Event Filter
            var PrintDeviceEvent = StartInfo.PrintDeviceEvents.Aggregate(PrintDeviceEvents.None, (x, y) => x | y);

            //Open the Printer
            var Opened = Win32.OpenPrinter(StartInfo.PrintDeviceName, out var PrinterHandle);
            if (!Opened) {
                throw new UnableToOpenPrinterException(StartInfo.PrintDeviceName);
            }

            var FirstOptions = new Printer_Notify_Options2() {
                Children = {
                    NotifyOptions2.From(PrintDeviceFields),
                    NotifyOptions2.From(PrintJobFields),
                }
            };

            var EventHandle = Win32.FindFirstPrinterChangeNotification(PrinterHandle, PrintDeviceEvent, StartInfo.PrintDeviceHardwareType, FirstOptions);
            if(EventHandle == IntPtr.Zero || EventHandle == Win32.Invalid_Handle) {
                Win32.ClosePrinter(PrinterHandle);
                throw new UnableToMonitorPrinterEventsException(StartInfo.PrintDeviceName);
            }

            var SecondOptions = new Printer_Notify_Options2() {
                Flags = StartInfo.GetAllFieldsOnChange ? NotifyOptionsFlags.Refresh : NotifyOptionsFlags.None,
                Children = {
                    NotifyOptions2.From(PrintDeviceFields),
                    NotifyOptions2.From(PrintJobFields),
                }
            };

            var ret = new PrintWatcher() {
                PrinterHandle = PrinterHandle,
                EventHandle = EventHandle,
                Options = SecondOptions,
            };
            ret.Start();

            return ret;
        }


    }

}
