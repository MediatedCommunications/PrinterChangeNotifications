using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(layoutKind: Defaults.LayoutKindDefault, CharSet = Defaults.CharSetDefault)]
    public struct NotifyOptions2 {
        public ushort F1_Type;
        public ushort F2_Reserved0;
        public uint F3_Reserved1;
        public uint F4_Reserved2;
        public uint F5_Count;
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
