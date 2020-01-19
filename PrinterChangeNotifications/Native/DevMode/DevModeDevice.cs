using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.DevMode {
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
    public struct DevModeDevice {
        [FieldOffset(0)]
        public PrinterDevice Printer;

        [FieldOffset(0)]
        public POINTL Position;

        [FieldOffset(0)]
        public DisplayDevice Display;
    }

}
