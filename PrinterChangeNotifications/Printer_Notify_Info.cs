using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO_BASE {
        public uint F1_Version;
        public uint F2_Flags;
        public uint F3_Count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO {
        public uint F1_Version;
        public uint F2_Flags;
        public uint F3_Count;
        public PRINTER_NOTIFY_INFO_DATA[] F4_Types;

        public static PRINTER_NOTIFY_INFO From(IntPtr Handle) {
            var Parsed = Marshal.PtrToStructure<PRINTER_NOTIFY_INFO_BASE>(Handle);

            var ret = new PRINTER_NOTIFY_INFO() {
                F1_Version = Parsed.F1_Version,
                F2_Flags = Parsed.F2_Flags,
                F3_Count = Parsed.F3_Count,
            };

            ret.F4_Types = new PRINTER_NOTIFY_INFO_DATA[ret.F3_Count];

            var TypePointer = Handle + Marshal.SizeOf<PRINTER_NOTIFY_INFO_BASE>();
            ret.F4_Types = Marshal2.PtrToArray<PRINTER_NOTIFY_INFO_DATA>(TypePointer, ret.F3_Count);

            return ret;
        }
    }

    public class Printer_Notify_Info {
        public Printer_Notify_Info_Flags Flags { get; set; }
        public List<Printer_Notify_Info_Data> Data { get; private set; } = new List<Printer_Notify_Info_Data>();
    }

    public static partial class Extensions {
        public static Printer_Notify_Info Convert(this PRINTER_NOTIFY_INFO This) {
            var ret = new Printer_Notify_Info();
            ret.Flags = (Printer_Notify_Info_Flags) This.F2_Flags;
            ret.Data.AddRange(This.F4_Types.Convert());
            return ret;
        }

        public static List<Printer_Notify_Info_Data> Convert(this IEnumerable<PRINTER_NOTIFY_INFO_DATA> This) {
            var ret = new List<Printer_Notify_Info_Data>();

            foreach (var item in This) {
                var NewItem = FieldDataParser.Parse(item);
                if (NewItem != null) {
                    ret.Add(NewItem);
                }
            }

            return ret;
        }

        

    }

    

}
