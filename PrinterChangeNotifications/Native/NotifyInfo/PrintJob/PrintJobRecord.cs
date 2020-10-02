using PrinterChangeNotifications.Native.NotifyInfo;
using System.Diagnostics;

namespace PrinterChangeNotifications.Native.NotifyInfo {

    [DebuggerDisplay(Debugger2.DebuggerDisplay)]
    public abstract class PrintJobRecord : IRecord, IRecordID<uint>, IRecordReserved<uint>, IRecordName<PrintJobField> {

        uint IRecordID<uint>.ID => JobID;
        public uint JobID { get; private set; }
        public uint Reserved { get; private set; }
        public PrintJobField Name { get; private set; }
        public object Value => GetValue();

        object IRecordName<object>.Name => Name;
        object IRecordValue<object>.Value => GetValue();
        
        protected abstract object GetValue();

        public PrintJobRecord(uint DeviceID, uint Reserved, PrintJobField Name) {
            this.JobID = DeviceID;
            this.Reserved = Reserved;
            this.Name = Name;
        }

        public static PrintJobRecord<TValue> Create<TValue>(uint DeviceID, uint Reserved, PrintJobField Name, TValue Value) {
            return new PrintJobRecord<TValue>(DeviceID, Reserved, Name, Value);
        }

        protected virtual string GetDebuggerDisplay() => IRecordExtensions.GetDebuggerDisplay(Name, Value);
    }

    public class PrintJobRecord<TValue> : PrintJobRecord, IRecordValue<TValue> {
        new public TValue Value { get; private set; }

        protected override object GetValue() {
            return Value;
        }

        public PrintJobRecord(uint DeviceID, uint Reserved, PrintJobField Name, TValue Value) : base(DeviceID, Reserved, Name) {
            this.Value = Value;
        }
    }

}
