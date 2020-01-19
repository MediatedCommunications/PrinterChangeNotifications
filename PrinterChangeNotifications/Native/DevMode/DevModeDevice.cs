using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.DevMode {
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
    public struct DevModeDevice {
        [FieldOffset(0)]
        public Printer.Device Printer;

        [FieldOffset(0)]
        public POINTL Position;

        [FieldOffset(0)]
        public Display.Device Display;
    }

}
