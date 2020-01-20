using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace PrinterChangeNotifications.Native.Security {
    [StructLayout(layoutKind: Defaults.LayoutKindDefault, CharSet = Defaults.CharSetDefault)]
    public struct SecurityDescriptor {
        public byte revision;
        public byte size;
        public short control;
        public IntPtr owner;
        public IntPtr group;
        public IntPtr sacl;
        public IntPtr dacl;
    }
}
