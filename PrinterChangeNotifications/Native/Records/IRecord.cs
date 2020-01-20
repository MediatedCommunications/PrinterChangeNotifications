using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications.Native {
    public interface IRecord : IRecordName<object>, IRecordValue<object> {
    }

    public static class IRecordExtensions {
        public static string DebuggerDisplay(object Name, object Value) {
            var NameText = Name.ToString();

            var ValueText = Value switch {
                string V1 => V1,
                IEnumerable IE => string.Join(", ", IE.Cast<object>().Select(x => x.ToString())),
                _ => Value.ToString()
            }; 

            return $@"{NameText} = {ValueText}";
        }
    }

}
