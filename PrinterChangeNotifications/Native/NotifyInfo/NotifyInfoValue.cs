using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(layoutKind: LayoutKind.Explicit, CharSet = Defaults.CharSetDefault)]
    public struct NotifyInfoValue {
        [FieldOffset(0)]
        public NotifyInfoValueNumeric NumericData;

        [FieldOffset(0)]
        public NotifyInfoValuePointer PointerData;
    }


}
