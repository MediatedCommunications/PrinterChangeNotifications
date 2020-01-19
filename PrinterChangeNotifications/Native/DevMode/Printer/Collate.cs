﻿namespace PrinterChangeNotifications.Native.DevMode.Printer {
    /// <summary>
    /// Specifies whether collation should be used when printing multiple copies.
    /// </summary>
    public enum Collate : short {
        /// <summary>
        /// Do not collate when printing multiple copies.
        /// </summary>
        False = 0,

        /// <summary>
        /// Collate when printing multiple copies.
        /// </summary>
        True = 1
    }

}
