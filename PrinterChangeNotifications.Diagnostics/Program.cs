using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.NotifyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PrinterChangeNotifications.Diagnostics {
    class Program {
        static void Main(string[] args) {

            var Watcher = PrintWatcher.Start(new PrintWatcherStartArgs() {
                GetAllFieldsOnChange = true,
                PrintDeviceHardwareType = PrintDeviceHardwareType.All,

                PrintDeviceEvents = { 
                    //PrintDeviceEvents.Job,
                    PrintDeviceEvents.Job_Delete,
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
            var Runner = Task.Run(() => ShowEvents(Watcher.Events));

            Console.WriteLine("Press any key to stop the watcher");
            Console.ReadLine();

            Watcher.Dispose();

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


        private static async Task ShowEvents(ChannelReader<PrintWatcherEventArgs> Events) { 

            while(await Events.WaitToReadAsync()) {
                while (Events.TryRead(out var Item)) {
                    ShowEvents(Item);
                }
            }

        
        }

        private static void ShowEvents(PrintWatcherEventArgs e) {
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
