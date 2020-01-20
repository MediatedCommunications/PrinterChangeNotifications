using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(layoutKind: Defaults.LayoutKindDefault, CharSet = Defaults.CharSetDefault)]
    public struct NotifyInfoData {
        public NotifyInfoFieldType F1_Type;
        public ushort F2_Field;
        public uint F3_Reserved;
        public uint F4_Id;
        public NotifyInfoValue F5_NotifyData;
    }


}
