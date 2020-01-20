using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(LayoutKind.Explicit)]
    public struct NotifyInfoValue {
        [FieldOffset(0)]
        public NotifyInfoValueNumeric NumericData;

        [FieldOffset(0)]
        public NotifyInfoValuePointer PointerData;
    }


}
