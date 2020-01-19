using PrinterChangeNotifications.Native.DevMode;
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
                JobField.PrinterName,
                //JobField.MACHINE_NAME,
                //JobField.PORT_NAME,
                //JobField.USER_NAME,
                //JobField.NOTIFY_NAME,
                //JobField.PRINT_PROCESSOR,
                //JobField.DRIVER_NAME,
                //JobField.DOCUMENT,
                //JobField.PAGES_TOTAL,
                //JobField.PARAMETERS,
                //JobField.DATATYPE,
                //JobField.DEVMODE,
            };

            var PrinterFields = new[] {
                //PrinterField.ATTRIBUTES,
                //PrinterField.DATATYPE,
                //PrinterField.PARAMETERS,
                //PrinterField.DEVMODE,

                PrinterField.ServerName,
                PrinterField.Pages_Total,
                PrinterField.Pages_Printed,
                PrinterField.Bytes_Total,
                PrinterField.Bytes_Printed,
                PrinterField.StatusString
            };


            var Watcher = PrinterEventWatcher.Start(null, EventFilter, HardwareFilter, PrinterFields, JobFields, true);

            Watcher.EventTriggered += Watcher_EventTriggered;

            Console.WriteLine("Press any key to stop the watcher");
            Console.ReadLine();
            Watcher.Stop();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void Watcher_EventTriggered(object sender, PrintWatcherEventArgs e) {
            Console.WriteLine($@"TRIGGERED: {e.Cause} ({e.Flags})");

            foreach (var item in e.Data) {
                Console.WriteLine($@"  {item}");
                if(item is IFieldValue<DevModeA> V1) {
                    var Elements = V1.Value.ToDictionary().Values;

                    foreach (var E in Elements) {
                        Console.WriteLine($@"    {E}");
                    }

                }
                


            }

            Console.WriteLine();
        }


    }

    
}
