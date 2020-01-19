using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {

    public class Field<TName, TValue> : IFieldName<TName>, IFieldValue<TValue> {
        public TName Name { get; private set; }
        public TValue Value { get; private set; }
        
        public Field(TName Name, TValue Value) {
            this.Name = Name;
            this.Value = Value;
        }
        
    }

    public static class Field {
        public static Field<TName, TValue> Create<TName, TValue>(TName Name, TValue Value) {
            return new Field<TName, TValue>(Name, Value);
        }
    }

}
