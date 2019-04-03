using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {

    public class PrintWatcherEventArgs {
        public PrinterEventType Cause { get; set; }
        public Printer_Notify_Info_Flags Flags { get; set; }
        public List<Printer_Notify_Info_Data> Data { get; set; }
    }

    public class PrinterEventWatcher : IDisposable {

        private IntPtr PrinterHandle;
        private IntPtr EventHandle;
        private Printer_Notify_Options Options;

        private PrinterEventWatcher() {

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


        ~PrinterEventWatcher() {
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

            var Event = new ManualResetEvent(false);
            Event.SafeWaitHandle = WaitHandle;

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

                    var Success = Win32.FindNextPrinterChangeNotification(EventHandle, Options, out var Cause, out var Data);
                    if (!Success) {
                        this.Dispose();
                        throw new UnableToLoadNextPrinterEventsEventsException();
                    } else {
                        var Args = new PrintWatcherEventArgs() {
                            Cause = Cause,
                            Data = Data.Data,
                            Flags = Data.Flags,
                        };

                        EventTriggered?.Invoke(this, Args);
                    }

                }

            }

            
        }


        public static PrinterEventWatcher Start(string PrinterName, PrinterEventType EventFilter, PrinterHardwareType HardwareFilter, IEnumerable<PrinterField> PrinterFields, IEnumerable<JobField> JobFields, bool GetAllFieldsOnChange) {
            var Opened = Win32.OpenPrinter(PrinterName, out var PrinterHandle);
            if (!Opened) {
                throw new UnableToOpenPrinterException(PrinterName);
            }

            var FirstOptions = new Printer_Notify_Options() {
                Children = {
                    new Printer_Notify_Options_Type_Printer(PrinterFields),
                    new Printer_Notify_Options_Type_Job(JobFields),
                }
            };

            var EventHandle = Win32.FindFirstPrinterChangeNotification(PrinterHandle, EventFilter, HardwareFilter, FirstOptions);
            if(EventHandle == IntPtr.Zero || EventHandle == Win32.Invalid_Handle) {
                Win32.ClosePrinter(PrinterHandle);
                throw new UnableToMonitorPrinterEventsException(PrinterName);
            }

            var SecondOptions = new Printer_Notify_Options() {
                Flags = GetAllFieldsOnChange ? Printer_Notify_Options_Flags.Refresh : Printer_Notify_Options_Flags.None,
                Children = {
                    new Printer_Notify_Options_Type_Printer(PrinterFields),
                    new Printer_Notify_Options_Type_Job(JobFields),
                }
            };

            var ret = new PrinterEventWatcher() {
                PrinterHandle = PrinterHandle,
                EventHandle = EventHandle,
                Options = SecondOptions,
            };
            ret.Start();

            return ret;
        }


    }

    public class PrintWatcherException : System.Exception {
        public PrintWatcherException(string Message) : base(Message) {
        }
    }

    public class UnableToOpenPrinterException : PrintWatcherException {
        public UnableToOpenPrinterException(string PrinterName) : base($@"Unable to open the printer named '{PrinterName}'") {
        }
    }

    public class UnableToMonitorPrinterEventsException : PrintWatcherException {
        public UnableToMonitorPrinterEventsException(string PrinterName) : base($@"Unable to monitor printer events for '{PrinterName}' (call to FindFirstPrinterChangeNotification failed)") {
        }
    }

    public class UnableToLoadNextPrinterEventsEventsException : PrintWatcherException {
        public UnableToLoadNextPrinterEventsEventsException() : base($@"Unable to load additional printer events (call to FindNextPrinterChangeNotification failed)") {
        }
    }

}
