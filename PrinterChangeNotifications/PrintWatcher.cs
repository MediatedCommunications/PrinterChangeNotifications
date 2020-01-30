using PrinterChangeNotifications.Exceptions;
using PrinterChangeNotifications.Native;
using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.NotifyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


        private readonly CancellationTokenSource TokenSource = new CancellationTokenSource();
        public void Stop() {
            TokenSource.Cancel();
        }



        public event EventHandler<PrintWatcherEventArgs> EventTriggered;
        private void Start() {

            var _mrEvent = new ManualResetEvent(false) {
                SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(EventHandle, true)
            };

            var _waitHandle = RegisterEvent(_mrEvent);
        }

        private RegisteredWaitHandle RegisterEvent(ManualResetEvent _mrEvent) {
            var _waitHandle = ThreadPool.RegisterWaitForSingleObject(_mrEvent, (_, TimedOut) => ThreadPoolCallback(TimedOut, _mrEvent), null, -1, true);
            return _waitHandle;
        }


        private void ThreadPoolCallback(bool TimedOut, ManualResetEvent _mrEvent) {
            if (!TimedOut) {
                if (Win32.FindNextPrinterChangeNotification(EventHandle, Options, out var Args)) {
                    EventTriggered?.Invoke(this, Args);
                    RegisterEvent(_mrEvent);
                }
                else {
                    this.Dispose();
                    throw new UnableToLoadNextPrinterEventsEventsException();
                }
            }
        }

        

        public static PrintWatcher Start(PrintWatcherStartArgs StartInfo) {
            if(StartInfo == default) {
                throw new ArgumentNullException(nameof(StartInfo));
            }

            //Check to see if we asked for DevMode fields.
            //If we did, make sure that DevMode is a field we're retrieving
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
