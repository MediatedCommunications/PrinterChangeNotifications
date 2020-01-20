using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(LayoutKind.Sequential)]
    public struct NotifyOptions2 {
        public UInt16 F1_Type;
        public UInt16 F2_Reserved0;
        public UInt32 F3_Reserved1;
        public UInt32 F4_Reserved2;
        public UInt32 F5_Count;
        public ushort[] F6_Children;

        public static NotifyOptions2 From(List<PrintJobField> Fields) {
            var ret = new NotifyOptions2() {
                F1_Type = (ushort)NotifyInfoFieldType.Job,
                F2_Reserved0 = 0,
                F3_Reserved1 = 0,
                F4_Reserved2 = 0,
                F5_Count = (uint)Fields.Count,
                F6_Children = Fields.Select(x => (ushort)x).ToArray(),
            };

            return ret;
        }

        public static NotifyOptions2 From(List<PrintDeviceField> Fields) {
            var ret = new NotifyOptions2() {
                F1_Type = (ushort)NotifyInfoFieldType.Printer,
                F2_Reserved0 = 0,
                F3_Reserved1 = 0,
                F4_Reserved2 = 0,
                F5_Count = (uint)Fields.Count,
                F6_Children = Fields.Select(x => (ushort)x).ToArray(),
            };

            return ret;
        }

    }

}
