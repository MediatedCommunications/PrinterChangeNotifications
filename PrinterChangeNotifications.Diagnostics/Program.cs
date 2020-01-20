using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.NotifyInfo;
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

            var Watcher = PrintWatcher.Start(new PrintWatcherStartArgs() {
                GetAllFieldsOnChange = true,
                PrintDeviceHardwareType = PrintDeviceHardwareType.All,

                PrintDeviceEvents = { 
                    //PrintDeviceEvents.Job,
                    PrintDeviceEvents.Printer_Set
                },
                
                PrintJobFields = { 
                    PrintJobField.PrinterName,
                    PrintJobField.DevMode,
                },
                PrintDeviceFields = {
                    PrintDeviceField.Comment,
                    PrintDeviceField.StatusString,
                }

            });
               

            Watcher.EventTriggered += Watcher_EventTriggered;

            Console.WriteLine("Press any key to stop the watcher");
            Console.ReadLine();
            Watcher.Stop();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void Watcher_EventTriggered(object sender, PrintWatcherEventArgs e) {
            Console.WriteLine($@"TRIGGERED: {e.Cause} (Discarded: {e.Discarded})");
            foreach (var Device in e.PrintDevices) {
                Console.WriteLine($@"  Print Device #{Device.Key}");

                foreach (var item in Device.Value.AllRecords()) {
                    Console.WriteLine($@"    {item.Name} = {item.Value}");
                }
                
                Console.WriteLine();
            }

            foreach (var Job in e.PrintJobs) {
                Console.WriteLine($@"  Print Job #{Job.Key}");

                foreach (var item in Job.Value.AllRecords()) {
                    Console.WriteLine($@"    {item.Name} = {item.Value}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }


    }

    
}
