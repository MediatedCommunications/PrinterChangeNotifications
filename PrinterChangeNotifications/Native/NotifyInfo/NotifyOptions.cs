using System;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(LayoutKind.Sequential)]
    public class NotifyOptions {
        public uint Version;
        public NotifyOptionsFlags Flags;
        public uint Count;
        public IntPtr Children;

        public NotifyOptions() {
            Version = 2;
            Flags = 0;
            Count = 0;
            Children = IntPtr.Zero;
        }
    }

}
