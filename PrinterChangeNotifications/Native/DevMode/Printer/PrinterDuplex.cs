namespace PrinterChangeNotifications.Native.DevMode {
    /// <summary>
    /// Specifies whether collation should be used when printing multiple copies.
    /// </summary>
    public enum PrinterDuplex : short {
        /// <summary>
        /// Unknown setting.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Normal (nonduplex) printing.
        /// </summary>
        Simplex = 1,

        /// <summary>
        /// Long-edge binding, that is, the long edge of the page is vertical.
        /// </summary>
        Vertical = 2,

        /// <summary>
        /// Short-edge binding, that is, the long edge of the page is horizontal.
        /// </summary>
        Horizontal = 3,
    }

}
