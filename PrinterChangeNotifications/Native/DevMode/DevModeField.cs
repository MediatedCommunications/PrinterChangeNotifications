using System;

namespace PrinterChangeNotifications.Native.DevMode {
    [Flags]
    public enum DevModeField : uint {
        /* field selection bits */
        None = 0,
        Printer_Orientation             = 0x00000001,
        Printer_Paper_Size              = 0x00000002,
        Printer_Paper_Length            = 0x00000004,
        Printer_Paper_Width             = 0x00000008,
        Printer_Scale                   = 0x00000010,
        Display_Position                = 0x00000020,
        Printer_PageLayout              = 0x00000040,
        Display_Orientation             = 0x00000080,
        Printer_Copies                  = 0x00000100,
        Printer_DefaultSource           = 0x00000200,
        Printer_PrintQuality_X          = 0x00000400,
        Printer_Palette                 = 0x00000800,
        Printer_Duplex                  = 0x00001000,
        Printer_PrintQuality_Y          = 0x00002000,
        Printer_TrueTypeFontOptions     = 0x00004000,
        Printer_Collate                 = 0x00008000,
        Printer_FormName                = 0x00010000,
        Display_PixelsPerLogicalInch    = 0x00020000,
        Display_BitsPerPixel            = 0x00040000,
        Display_PixelsW                 = 0x00080000,
        Display_PixelsH                 = 0x00100000,
        Display_Flags                   = 0x00200000,
        Display_Frequency               = 0x00400000,
        Printer_ICM_Method              = 0x00800000,
        Printer_ICM_Intent              = 0x01000000,
        Printer_MediaType               = 0x02000000,
        Dither                          = 0x04000000,
        Panning_Width                   = 0x08000000,
        Panning_Height                  = 0x10000000,
        Display_FixedOutput             = 0x20000000,

        All                             = 0x3FFFFFFF
    }

}
