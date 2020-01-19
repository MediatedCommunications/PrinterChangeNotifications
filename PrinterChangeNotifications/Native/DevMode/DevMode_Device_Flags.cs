using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.DevMode {
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
    public struct DevMode_Device_Flags {
        [FieldOffset(0)]
        public DisplayFlags Display_Flags;

        [FieldOffset(0)]
        public PrinterPageLayout Printer_PageLayout;

    }

}
