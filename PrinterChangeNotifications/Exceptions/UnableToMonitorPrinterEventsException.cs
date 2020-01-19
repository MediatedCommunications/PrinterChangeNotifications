namespace PrinterChangeNotifications {
    public class UnableToMonitorPrinterEventsException : PrintWatcherException {
        public UnableToMonitorPrinterEventsException(string PrinterName) : base($@"Unable to monitor printer events for '{PrinterName}' (call to FindFirstPrinterChangeNotification failed)") {
        }
    }

}
