namespace PrinterChangeNotifications.Exceptions {
    public class UnableToOpenPrinterException : PrintWatcherException {
        public UnableToOpenPrinterException(string PrinterName) : base($@"Unable to open the printer named '{PrinterName}'") {
        }
    }

}
