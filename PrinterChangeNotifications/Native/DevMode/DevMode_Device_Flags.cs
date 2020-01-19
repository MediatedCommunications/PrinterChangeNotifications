using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.DevMode {
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
    public struct DevMode_Device_Flags {
        [FieldOffset(0)]
        public PrinterChangeNotifications.Native.DevMode.Display.Flags Display_Flags;

        [FieldOffset(0)]
        public PrinterChangeNotifications.Native.DevMode.Printer.PageLayout Printer_PageLayout;

    }

}
