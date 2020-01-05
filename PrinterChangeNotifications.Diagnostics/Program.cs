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
            
            var EventFilter = PrinterEventType.Job;
            var HardwareFilter = PrinterHardwareType.All;

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

            var Watcher = PrinterEventWatcher.Start(null, EventFilter, HardwareFilter, null, JobFields, true);

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


    }

    
}
