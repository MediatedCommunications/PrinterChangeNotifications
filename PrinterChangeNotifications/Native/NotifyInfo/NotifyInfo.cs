using System;
using System.Runtime.InteropServices;

namespace PrinterChangeNotifications.Native.NotifyInfo {
    [StructLayout(LayoutKind.Sequential)]
    public struct NotifyInfoHeader {
        public uint Version;
        public NotifyInfoFlags Flags;
        public uint Count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NotifyInfo {
        public NotifyInfoHeader Header;

        public NotifyInfoData[] Data;

        public static NotifyInfo From(IntPtr Handle) {
            var Parsed = Marshal.PtrToStructure<NotifyInfoHeader>(Handle);

            var ret = new NotifyInfo() {
                Header = Parsed,
            };

            var TypePointer = Handle + (int) Marshal.OffsetOf<NotifyInfo>(nameof(Data));

            ret.Data = Marshal2.PtrToArray<NotifyInfoData>(TypePointer, ret.Header.Count);

            return ret;
        }
    }

    

}
