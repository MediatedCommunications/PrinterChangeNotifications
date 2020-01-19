using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications.Native {
    public static class Marshal2 {
        public static T[] PtrToArray<T>(IntPtr Ptr, uint Count) {
            var ElementSize = Marshal.SizeOf<T>();

            var ret = new T[Count];
            var Start = Ptr;
            for (int i = 0; i < ret.Length; i++) {
                ret[i] = Marshal.PtrToStructure<T>(Start);
                Start += ElementSize;
            }
            return ret;
        }

        public static void ArrayToPtr<T>(IEnumerable<T> Items, IntPtr Ptr) {
            ArrayToPtr(Items, Ptr, false);
        }

        public static void ArrayToPtr<T>(IEnumerable<T> Items, IntPtr Ptr, bool DeleteOld) {
            var ElementSize = Marshal.SizeOf<T>();

            var Array = Items as T[];
            if(Array == null) {
                Array = Items.ToArray();
            }

            var Start = Ptr;
            for (int i = 0; i < Array.Length; i++) {
                Marshal.StructureToPtr(Array[i], Start, DeleteOld);
                Start += ElementSize;
            }

        }

        public static void Free(this IEnumerable<IntPtr> This) {
            foreach (var item in This) {
                Marshal.FreeHGlobal(item);
            }
        }

        public static void Free(this IEnumerable<GCHandle> This) {
            foreach (var item in This) {
                item.Free();
            }
        }

    }
}
