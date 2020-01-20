using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(LayoutKind.Sequential)]
    public struct NotifyInfoValueNumeric {
        public uint Value1;
        public uint Value2;
    }


}
