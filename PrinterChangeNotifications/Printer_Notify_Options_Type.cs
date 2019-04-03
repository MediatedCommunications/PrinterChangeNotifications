using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications {
    public abstract class Printer_Notify_Options_Type {
        public abstract PRINTER_NOTIFY_OPTIONS_TYPE2 Convert();
    }

    public class Printer_Notify_Options_Type_Printer : Printer_Notify_Options_Type {
        public Printer_Notify_Options_Type_Printer() {

        }

        public Printer_Notify_Options_Type_Printer(IEnumerable<PrinterField> Fields) {
            if(Fields != null) {
                this.Fields.AddRange(Fields);
            }
        }


        public List<PrinterField> Fields { get; private set; } = new List<PrinterField>();

        public override PRINTER_NOTIFY_OPTIONS_TYPE2 Convert() {
            var ret = new PRINTER_NOTIFY_OPTIONS_TYPE2() {
                F1_Type = (ushort)FieldType.Printer,
                F2_Reserved0 = 0,
                F3_Reserved1 = 0,
                F4_Reserved2 = 0,
                F5_Count = (uint)Fields.Count,
                F6_Children = Fields.Select(x => (ushort)x).ToArray(),
            };

            return ret;
        }
    }

    public class Printer_Notify_Options_Type_Job : Printer_Notify_Options_Type {

        public Printer_Notify_Options_Type_Job() {

        }

        public Printer_Notify_Options_Type_Job(IEnumerable<JobField> Fields) {
            if (Fields != null) {
                this.Fields.AddRange(Fields);
            }
        }

        public List<JobField> Fields { get; private set; } = new List<JobField>();

        public override PRINTER_NOTIFY_OPTIONS_TYPE2 Convert() {
            var ret = new PRINTER_NOTIFY_OPTIONS_TYPE2() {
                F1_Type = (ushort)FieldType.Job,
                F2_Reserved0 = 0,
                F3_Reserved1 = 0,
                F4_Reserved2 = 0,
                F5_Count = (uint)Fields.Count,
                F6_Children = Fields.Select(x => (ushort)x).ToArray(),
            };

            return ret;
        }
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_OPTIONS_TYPE {
        public UInt16 F1_Type;
        public UInt16 F2_Reserved0;
        public UInt32 F3_Reserved1;
        public UInt32 F4_Reserved2;
        public UInt32 F5_Count;
        public IntPtr F6_Children;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_OPTIONS_TYPE2 {
        public UInt16 F1_Type;
        public UInt16 F2_Reserved0;
        public UInt32 F3_Reserved1;
        public UInt32 F4_Reserved2;
        public UInt32 F5_Count;
        public ushort[] F6_Children;
    }

    public static partial class Extensions {
        public static IntPtr Convert(this List<Printer_Notify_Options_Type> This, List<IntPtr> Allocated) {
            var ElementSize = Marshal.SizeOf<PRINTER_NOTIFY_OPTIONS_TYPE>();
            var SpaceNeeded = This.Count * ElementSize;
            var SpaceUsed = Marshal.AllocHGlobal(SpaceNeeded);
            Allocated.Add(SpaceUsed);
            var ret = SpaceUsed;

            var Start = SpaceUsed;
            for (int i = 0; i < This.Count; i++) {
                This[i].Convert(Start, Allocated);
                Start += ElementSize;
            }

            return ret;
        }

        public static IntPtr Convert(this Printer_Notify_Options_Type This, IntPtr Pointer, List<IntPtr> Allocated) {
            var ret = Pointer;


            var Pass1 = This.Convert();

            //Create our manin entry.
            var NodeToWrite = new PRINTER_NOTIFY_OPTIONS_TYPE() {
                F1_Type = Pass1.F1_Type,
                F2_Reserved0 = Pass1.F2_Reserved0,
                F3_Reserved1 = Pass1.F3_Reserved1,
                F4_Reserved2 = Pass1.F4_Reserved2,
                F5_Count = Pass1.F5_Count,
            };

            //Allocate the space for the child children
            var ChildElementSize = Marshal.SizeOf(Pass1.F6_Children.GetType().GetElementType());
            var ChildSpaceNeeded = (int)Pass1.F5_Count * ChildElementSize;
            var ChildSpaceUsed = Marshal.AllocHGlobal(ChildSpaceNeeded);
            Allocated.Add(ChildSpaceUsed);

            //Copy the children to the Space pointer.
            Marshal2.ArrayToPtr(Pass1.F6_Children, ChildSpaceUsed);

            //Set the children in our node to write.
            NodeToWrite.F6_Children = ChildSpaceUsed;

            //Copy our node to write to the pointer. 
            Marshal.StructureToPtr(NodeToWrite, Pointer, false);


            return ret;
        }

    }

}
