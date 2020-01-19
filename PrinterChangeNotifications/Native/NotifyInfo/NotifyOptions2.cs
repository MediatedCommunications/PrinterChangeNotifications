using System;
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
    }

}
