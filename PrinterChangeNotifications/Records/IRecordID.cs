using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications {
    public interface IRecordID<T> {
        public T ID { get; }
    }

}
