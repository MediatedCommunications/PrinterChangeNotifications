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
                    PrintJobField.Printer_Name,
                    PrintJobField.DevMode,
                },
                PrintDeviceFields = {
                    PrintDeviceField.Comment,
                    //PrintDeviceField.StatusString,
                }

            });
               

            Watcher.EventTriggered += Watcher_EventTriggered;

            Console.WriteLine("Press any key to stop the watcher");
            Console.ReadLine();
            Watcher.Stop();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }


        private static void ShowRecords(IEnumerable<Native.IRecord> Records) {
            foreach (var item in Records) {
                Console.WriteLine($@"    {item.Name} = {item.Value}");


                if (item.Value is DevModeA DMA) {
                    foreach (var DMR in DMA.AllRecords()) {
                        Console.WriteLine($@"      {DMR.Name} = {DMR.Value}");
                    }
                }
            }
        }

        private static void Watcher_EventTriggered(object sender, PrintWatcherEventArgs e) {
            Console.WriteLine($@"TRIGGERED: {e.Cause} (Discarded: {e.Discarded})");
            foreach (var Device in e.PrintDevices) {
                Console.WriteLine($@"  Print Device #{Device.Key}");
                ShowRecords(Device.Value.PrintDevice_Records.Values);
                Console.WriteLine();
            }

            foreach (var Job in e.PrintJobs) {
                Console.WriteLine($@"  Print Job #{Job.Key}");
                ShowRecords(Job.Value.PrintJob_Records.Values);
                Console.WriteLine();
            }

            Console.WriteLine();
        }


    }

    
}
