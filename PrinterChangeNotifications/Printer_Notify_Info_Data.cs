using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO_DATA {
        public ushort F1_Type;
        public ushort F2_Field;
        public uint F3_Reserved;
        public uint F4_Id;
        public PRINTER_NOTIFY_INFO_DATA_UNION F5_NotifyData;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct PRINTER_NOTIFY_INFO_DATA_UNION {
        [FieldOffset(0)]
        public PRINTER_NOTIFY_INFO_DATA_NUMERIC NumericData;

        [FieldOffset(0)]
        public PRINTER_NOTIFY_INFO_DATA_STRING StringData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO_DATA_NUMERIC {
        public UInt32 adwData0;
        public UInt32 adwData1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_NOTIFY_INFO_DATA_STRING {
        public UInt32 BufferSize;
        public IntPtr BufferAddress;

    }

    [DebuggerDisplay(Debugger2.DebuggerDisplay)]
    public abstract class Printer_Notify_Info_Data {
        public FieldType Type { get; private set; }
        public FieldDataType DataType { get; private set; }
        public uint ID { get; set; }
        public uint Reserved { get; private set; }

        public Printer_Notify_Info_Data(FieldType Type, FieldDataType DataType, uint ID, uint Reserved) {
            this.Type = Type;
            this.DataType = DataType;
            this.ID = ID;
            this.Reserved = Reserved;
        }


        protected virtual string DebuggerDisplay => this.GetType().Name;

        public static Printer_Notify_Info_Data<TFieldEnum> Create<TFieldEnum>(FieldType Type, FieldDataType DataType, TFieldEnum Name, uint ID, uint Reserved) {
            return new Printer_Notify_Info_Data<TFieldEnum>(Type, DataType, Name, ID, Reserved);
        }

        public static Printer_Notify_Info_Data<TFieldEnum> Create<TFieldEnum, TValue>(FieldType Type, FieldDataType DataType, TFieldEnum Name, TValue Value, uint ID, uint Reserved) {
            return new Printer_Notify_Info_Data<TFieldEnum, TValue>(Type, DataType, Name, Value, ID, Reserved);
        }

        public override string ToString() {
            return DebuggerDisplay;
        }

    }

    public class Printer_Notify_Info_Data<TFieldEnum> : Printer_Notify_Info_Data {
        public TFieldEnum Name { get; private set; }

        public Printer_Notify_Info_Data(FieldType Type, FieldDataType DataType, TFieldEnum Name, uint ID, uint Reserved) : base(Type, DataType, ID, Reserved) {
            this.Name = Name;
        }

        protected override string DebuggerDisplay {
            get {
                return $@"[{ID}] {Type}.{Name}";
            }
        }
    }

    public class Printer_Notify_Info_Data<TFieldEnum, TValue> : Printer_Notify_Info_Data<TFieldEnum> {
        public TValue Value { get; private set; }

        public Printer_Notify_Info_Data(FieldType Type, FieldDataType DataType, TFieldEnum Name, TValue Value, uint ID, uint Reserved) : base(Type, DataType, Name, ID, Reserved) {
            this.Value = Value;
        }

        protected override string DebuggerDisplay {
            get {
                var V = Value.ToString();
                if(Value is IEnumerable IE && !(Value is string)) {
                    V = String.Join(", ", (from x in IE.OfType<Object>() select x.ToString()));
                }

                return $@"{base.DebuggerDisplay} = {V} ({typeof(TValue).Name})";
            }
        }
    }


}
