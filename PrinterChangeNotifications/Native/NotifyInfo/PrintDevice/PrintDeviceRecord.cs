using PrinterChangeNotifications.Native.NotifyInfo;

namespace PrinterChangeNotifications.Native.NotifyInfo {

    public abstract class PrintDeviceRecord : IRecord, IRecordID<uint>, IRecordReserved<uint>, IRecordName<PrintDeviceField> {

        uint IRecordID<uint>.ID => DeviceID;
        public uint DeviceID { get; private set; }
        public uint Reserved { get; private set; }
        public PrintDeviceField Name { get; private set; }
        public object Value => GetValue();

        object IRecordName<object>.Name => Name;
        object IRecordValue<object>.Value => GetValue();

        protected abstract object GetValue();

        public PrintDeviceRecord(uint DeviceID, uint Reserved, PrintDeviceField Name) {
            this.DeviceID = DeviceID;
            this.Reserved = Reserved;
            this.Name = Name;
        }

        public static PrintDeviceRecord<TValue> Create<TValue>(uint DeviceID, uint Reserved, PrintDeviceField Name, TValue Value) {
            return new PrintDeviceRecord<TValue>(DeviceID, Reserved, Name, Value);
        }
    }

    public class PrintDeviceRecord<TValue> : PrintDeviceRecord, IRecordValue<TValue> {
        new public TValue Value { get; private set; }
        protected override object GetValue() {
            return Value;
        }

        public PrintDeviceRecord(uint DeviceID, uint Reserved, PrintDeviceField Name, TValue Value) : base(DeviceID, Reserved, Name) {
            this.Value = Value;
        }
    }

}
