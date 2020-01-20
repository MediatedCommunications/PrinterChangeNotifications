using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications.Native {
    public interface IRecord : IRecordName<object>, IRecordValue<object> {
    }
}
