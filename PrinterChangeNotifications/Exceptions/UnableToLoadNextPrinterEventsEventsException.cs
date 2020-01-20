namespace PrinterChangeNotifications.Exceptions {
    public class UnableToLoadNextPrinterEventsEventsException : PrintWatcherException {
        public UnableToLoadNextPrinterEventsEventsException() : base($@"Unable to load additional printer events (call to FindNextPrinterChangeNotification failed)") {
        }
    }

}
