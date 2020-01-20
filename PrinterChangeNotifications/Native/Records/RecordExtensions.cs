using PrinterChangeNotifications.Native;
using PrinterChangeNotifications.Native.DevMode;
using PrinterChangeNotifications.Native.NotifyInfo;
using PrinterChangeNotifications.Native.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications.Native {
    public static class RecordExtensions {
        public static bool TryGetValue<T>(this IRecordValue<T> This, out T Value) {
            var ret = false;
            Value = default;
            if(This is { } V1) {
                ret = true;
                Value = V1.Value;
            }

            return ret;
        }

        public static T TryGetValue<T>(this IRecordValue<T> This, T Default = default) {
            if(!This.TryGetValue<T>(out var ret)) {
                ret = Default;
            }

            return ret;
        }



        public static bool TryGetValue<T>(this IRecord This, out T Value) {
            var ret = false;
            Value = default;
            if (This is IRecordValue<T> V1 && V1.Value is { } V2) {
                ret = true;
                Value = V2;
            }

            return ret;
        }

        public static T TryGetValue<T>(this IRecord This, T Default = default) {
            if (!This.TryGetValue<T>(out var ret)) {
                ret = Default;
            }
            return ret;
        }


        //String
        public static bool TryGetString(this IRecord This, out string Value) {
            return This.TryGetValue(out Value);
        }

        public static string TryGetString(this IRecord This, string Default = default) {
            return This.TryGetValue(Default);
        }

        //String List
        public static bool TryGetStringList(this IRecord This, out IReadOnlyCollection<string> Value) {
            return This.TryGetValue(out Value);
        }

        public static IReadOnlyCollection<string> TryGetStringList(this IRecord This, IReadOnlyCollection<string> Default = default) {
            return This.TryGetValue(Default);
        }

        //PrintJobStatus
        public static bool TryGetPrintJobStatus(this IRecord This, out PrintJobStatus Value) {
            return This.TryGetValue(out Value);
        }

        public static PrintJobStatus TryGetStringList(this IRecord This, PrintJobStatus Default = default) {
            return This.TryGetValue(Default);
        }

        //PrintJobStatus
        public static bool TryGetPrintDeviceAttribute(this IRecord This, out PrintDeviceAttribute Value) {
            return This.TryGetValue(out Value);
        }

        public static PrintDeviceAttribute TryGetPrintDeviceAttribute(this IRecord This, PrintDeviceAttribute Default = default) {
            return This.TryGetValue(Default);
        }

        //SecurityDescriptor
        public static bool TryGetSecurityDescriptor(this IRecord This, out SecurityDescriptor Value) {
            return This.TryGetValue(out Value);
        }

        public static SecurityDescriptor TryGetSecurityDescriptor(this IRecord This, SecurityDescriptor Default = default) {
            return This.TryGetValue(Default);
        }

        //Number
        public static bool TryGetNumber(this IRecord This, out uint Value) {
            return This.TryGetValue(out Value);
        }

        public static uint TryGetNumber(this IRecord This, uint Default = default) {
            return This.TryGetValue(Default);
        }

        //DateTime
        public static bool TryGetDateTime(this IRecord This, out DateTime Value) {
            return This.TryGetValue(out Value);
        }

        public static DateTime TryGetDateTime(this IRecord This, DateTime Default = default) {
            return This.TryGetValue(Default);
        }

        //TimeSpan
        public static bool TryGetTimeSpan(this IRecord This, out TimeSpan Value) {
            return This.TryGetValue(out Value);
        }

        public static TimeSpan TryGetTimeSpan(this IRecord This, TimeSpan Default = default) {
            return This.TryGetValue(Default);
        }

        //DevMode
        public static bool TryGetDevMode(this IRecord This, out DevModeA Value) {
            return This.TryGetValue(out Value);
        }

        public static DevModeA TryGetDevMode(this IRecord This, DevModeA Default = default) {
            return This.TryGetValue(Default);
        }

    }
}
