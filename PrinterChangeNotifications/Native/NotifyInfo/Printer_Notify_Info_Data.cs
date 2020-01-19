using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {

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

    public class Printer_Notify_Info_Data<TFieldEnum, TValue> : Printer_Notify_Info_Data<TFieldEnum>, IFieldValue<TValue> {
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
