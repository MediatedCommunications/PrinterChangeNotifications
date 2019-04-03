using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrinterChangeNotifications.Diagnostics {
    class Program {
        static void Main(string[] args) {

            var JobFields = new[] {
                JobField.PRINTER_NAME,
                JobField.MACHINE_NAME,
                JobField.PORT_NAME,
                JobField.USER_NAME,
                JobField.NOTIFY_NAME,
                JobField.PRINT_PROCESSOR,
                JobField.DRIVER_NAME,
                JobField.DOCUMENT,
                JobField.PAGES_TOTAL,
            };

            var Watcher = PrinterEventWatcher.Start(null, PrinterEventType.Job_Write, PrinterHardwareType.All, null, JobFields, true);
            Watcher.EventTriggered += Watcher_EventTriggered;

            Console.WriteLine("Press any key to stop the watcher");
            Console.ReadLine();
            Watcher.Stop();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void Watcher_EventTriggered(object sender, PrintWatcherEventArgs e) {
            Console.WriteLine($@"TRIGGERED: {e.Cause}");

            foreach (var item in e.Data) {
                Console.WriteLine($@"  {item}");
            }

            Console.WriteLine();
        }

        static void Main1(string[] args) {

            var Success = Win32.OpenPrinter(null, out var HPrinter);

            var Options = new Printer_Notify_Options() {
                Flags = Printer_Notify_Options_Flags.Refresh,

                Children = {
                    new Printer_Notify_Options_Type_Job() {
                        Fields = {
                            JobField.PRINTER_NAME,
                            JobField.MACHINE_NAME,
                            JobField.PORT_NAME,
                            JobField.USER_NAME,
                            JobField.NOTIFY_NAME,
                            JobField.PRINT_PROCESSOR,
                            JobField.DRIVER_NAME,
                            JobField.DOCUMENT,
                            JobField.PAGES_TOTAL,
                        }
                    }

                }

            };
            
            var EventHandle = Win32.FindFirstPrinterChangeNotification(HPrinter, PrinterEventType.Job_Write, PrinterHardwareType.All, Options);

            var WaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(EventHandle, false);

            var Event = new ManualResetEvent(false);
            Event.SafeWaitHandle = WaitHandle;
            while (true) {
                Event.WaitOne();
                Success = Win32.FindNextPrinterChangeNotification(EventHandle, Options, out var Cause, out var Data);

                Console.WriteLine($@"TRIGGERED: {Cause}");

                foreach (var item in Data.Data) {
                    Console.WriteLine($@"  {item}");
                }

                Console.WriteLine();

            }

            Success = Win32.ClosePrinter(HPrinter);
        }
    }

    
}
