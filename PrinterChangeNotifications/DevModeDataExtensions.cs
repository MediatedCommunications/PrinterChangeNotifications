using PrinterChangeNotifications.Native.DevMode;

namespace PrinterChangeNotifications {
    public static class DevModeDataExtensions {

        public static DevModeRecord<T> TryGetRecord<T>(this DevModeData This, DevModeField Field) {
            This.TryGetRecord<T>(Field, out var ret);
            return ret;
        }

        public static bool TryGetRecord<T>(this DevModeData This, DevModeField Field, out DevModeRecord<T> ret) {
            var success = This.DevMode_Records.TryGetValue(Field, out var tret);

            ret = tret as DevModeRecord<T>;

            return success;
        }

        public static DevModeRecord<uint>                       DevMode_Panning_Width                   (this DevModeData This) => This.TryGetRecord<uint>(DevModeField.Panning_Width);
        public static DevModeRecord<uint>                       DevMode_Panning_Height                  (this DevModeData This) => This.TryGetRecord<uint>(DevModeField.Panning_Height);
                                                                
        public static DevModeRecord<DevMode_Dither>             DevMode_Dither                          (this DevModeData This) => This.TryGetRecord<DevMode_Dither>(DevModeField.Dither);
                                                                
        public static DevModeRecord<uint>                       DevMode_Display_BitsPerPixel            (this DevModeData This) => This.TryGetRecord<uint>(DevModeField.Display_BitsPerPixel);
        public static DevModeRecord<ushort>                     DevMode_Display_PixelsPerLogicalInch    (this DevModeData This) => This.TryGetRecord<ushort>(DevModeField.Display_PixelsPerLogicalInch);
        public static DevModeRecord<uint>                       DevMode_Display_PixelsW                 (this DevModeData This) => This.TryGetRecord<uint>(DevModeField.Display_PixelsW);
        public static DevModeRecord<uint>                       DevMode_Display_PixelsH                 (this DevModeData This) => This.TryGetRecord<uint>(DevModeField.Display_PixelsH);
        public static DevModeRecord<POINTL>                     DevMode_Display_Position                (this DevModeData This) => This.TryGetRecord<POINTL>(DevModeField.Display_Position);
        public static DevModeRecord<DisplayFixedOutput>         DevMode_Display_FixedOutput             (this DevModeData This) => This.TryGetRecord<DisplayFixedOutput>(DevModeField.Display_FixedOutput);
        public static DevModeRecord<DisplayFlags>               DevMode_Display_Flags                   (this DevModeData This) => This.TryGetRecord<DisplayFlags>(DevModeField.Display_Flags);
        public static DevModeRecord<uint>                       DevMode_Display_Frequency               (this DevModeData This) => This.TryGetRecord<uint>(DevModeField.Display_Frequency);
        public static DevModeRecord<DisplayOrientation>         DevMode_Display_Orientation             (this DevModeData This) => This.TryGetRecord<DisplayOrientation>(DevModeField.Display_Orientation);
                                                                
        public static DevModeRecord<PrinterCollate>             DevMode_Printer_Collate                 (this DevModeData This) => This.TryGetRecord<PrinterCollate>(DevModeField.Printer_Collate);
        public static DevModeRecord<short>                      DevMode_Printer_Copies                  (this DevModeData This) => This.TryGetRecord<short>(DevModeField.Printer_Copies);
        public static DevModeRecord<short>                      DevMode_Printer_DefaultSource           (this DevModeData This) => This.TryGetRecord<short>(DevModeField.Printer_DefaultSource);
        public static DevModeRecord<PrinterDuplex>              DevMode_Printer_Duplex                  (this DevModeData This) => This.TryGetRecord<PrinterDuplex>(DevModeField.Printer_Duplex);
        public static DevModeRecord<string>                     DevMode_Printer_FormName                (this DevModeData This) => This.TryGetRecord<string>(DevModeField.Printer_FormName);
        public static DevModeRecord<PrinterIcmMethod>           DevMode_Printer_ICM_Method              (this DevModeData This) => This.TryGetRecord<PrinterIcmMethod>(DevModeField.Printer_ICM_Method);
        public static DevModeRecord<PrinterIcmIntent>           DevMode_Printer_ICM_Intent              (this DevModeData This) => This.TryGetRecord<PrinterIcmIntent>(DevModeField.Printer_ICM_Intent);
        public static DevModeRecord<PrinterMediaType>           DevMode_Printer_MediaType               (this DevModeData This) => This.TryGetRecord<PrinterMediaType>(DevModeField.Printer_MediaType);
        public static DevModeRecord<PrinterOrientation>         DevMode_Printer_Orientation             (this DevModeData This) => This.TryGetRecord<PrinterOrientation>(DevModeField.Printer_Orientation);
        public static DevModeRecord<PrinterPageLayout>          DevMode_Printer_PageLayout              (this DevModeData This) => This.TryGetRecord<PrinterPageLayout>(DevModeField.Printer_PageLayout);
        public static DevModeRecord<PrinterPalette>             DevMode_Printer_Palette                 (this DevModeData This) => This.TryGetRecord<PrinterPalette>(DevModeField.Printer_Palette);
        public static DevModeRecord<short>                      DevMode_Printer_Paper_Length            (this DevModeData This) => This.TryGetRecord<short>(DevModeField.Printer_Paper_Length);
        public static DevModeRecord<PrinterPaperSize>           DevMode_Printer_Paper_Size              (this DevModeData This) => This.TryGetRecord<PrinterPaperSize>(DevModeField.Printer_Paper_Size);
        public static DevModeRecord<short>                      DevMode_Printer_Paper_Width             (this DevModeData This) => This.TryGetRecord<short>(DevModeField.Printer_Paper_Width);
        public static DevModeRecord<short>                      DevMode_Printer_PrintQuality_X          (this DevModeData This) => This.TryGetRecord<short>(DevModeField.Printer_PrintQuality_X);
        public static DevModeRecord<short>                      DevMode_Printer_PrintQuality_Y          (this DevModeData This) => This.TryGetRecord<short>(DevModeField.Printer_PrintQuality_Y);
        public static DevModeRecord<short>                      DevMode_Printer_Scale                   (this DevModeData This) => This.TryGetRecord<short>(DevModeField.Printer_Scale);
        public static DevModeRecord<PrinterTrueTypeFontOptions> DevMode_Printer_TrueTypeFontOptions     (this DevModeData This) => This.TryGetRecord<PrinterTrueTypeFontOptions>(DevModeField.Printer_TrueTypeFontOptions);


    }
    

}
