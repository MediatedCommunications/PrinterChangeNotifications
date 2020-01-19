using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    public static partial class Extensions {
        public static IntPtr Convert(this List<Printer_Notify_Options_Type> This, List<IntPtr> Allocated) {
            var ElementSize = Marshal.SizeOf<NotifyOptions1>();
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
            var NodeToWrite = new NotifyOptions1() {
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
