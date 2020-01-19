using System;
using System.Collections.Generic;
using System.Linq;

namespace PrinterChangeNotifications.Native.DevMode {
    public static class DEVMODEEXTENSIONS {

        private static DevModeRecord GetField(this DevModeA This, DevModeField Name) {
            var ret = Name switch
            {

                DevModeField.Panning_Height                => DevModeRecord.Create(Name, This.Panning_Height),
                DevModeField.Panning_Width                 => DevModeRecord.Create(Name, This.Panning_Width),
                
                DevModeField.Dither                        => DevModeRecord.Create(Name, This.Dither),

                DevModeField.Display_BitsPerPixel          => DevModeRecord.Create(Name, This.Display_BitsPerPixel),
                DevModeField.Display_PixelsPerLogicalInch  => DevModeRecord.Create(Name, This.Display_PixelsPerLogicalInch),
                DevModeField.Display_PixelsH               => DevModeRecord.Create(Name, This.Display_PixelsH),
                DevModeField.Display_PixelsW               => DevModeRecord.Create(Name, This.Display_PixelsW),
                DevModeField.Display_Position              => DevModeRecord.Create(Name, This.Device.Display.Position),
                DevModeField.Display_FixedOutput           => DevModeRecord.Create(Name, This.Device.Display.DisplayFixedOutput),
                DevModeField.Display_Flags                 => DevModeRecord.Create(Name, This.DeviceFlags.Display_Flags),
                DevModeField.Display_Frequency             => DevModeRecord.Create(Name, This.Display_Frequency),
                DevModeField.Display_Orientation           => DevModeRecord.Create(Name, This.Device.Display.Orientation),

                DevModeField.Printer_Collate               => DevModeRecord.Create(Name, This.Printer_Collate),
                DevModeField.Printer_Color                 => DevModeRecord.Create(Name, This.Printer_Color),
                DevModeField.Printer_Copies                => DevModeRecord.Create(Name, This.Device.Printer.Copies),
                DevModeField.Printer_DefaultSource         => DevModeRecord.Create(Name, This.Device.Printer.DefaultSource),
                DevModeField.Printer_Duplex                => DevModeRecord.Create(Name, This.Printer_Duplex),
                DevModeField.Printer_FormName              => DevModeRecord.Create(Name, This.Printer_FormName),
                DevModeField.Printer_ICM_Intent            => DevModeRecord.Create(Name, This.Printer_ICM_Intent),
                DevModeField.Printer_ICM_Method            => DevModeRecord.Create(Name, This.Printer_ICM_Method),
                DevModeField.Printer_MediaType             => DevModeRecord.Create(Name, This.Printer_MediaType),
                DevModeField.Printer_Orientation           => DevModeRecord.Create(Name, This.Device.Printer.Orientation),
                DevModeField.Printer_PageLayout            => DevModeRecord.Create(Name, This.DeviceFlags.Printer_PageLayout),
                DevModeField.Printer_Paper_Length          => DevModeRecord.Create(Name, This.Device.Printer.Paper_Length),
                DevModeField.Printer_Paper_Size            => DevModeRecord.Create(Name, This.Device.Printer.Paper_Size),
                DevModeField.Printer_Paper_Width           => DevModeRecord.Create(Name, This.Device.Printer.Paper_Width),
                DevModeField.Printer_PrintQuality_X        => DevModeRecord.Create(Name, This.Device.Printer.PrintQuality_X),
                DevModeField.Printer_PrintQuality_Y        => DevModeRecord.Create(Name, This.Printer_PrintQuality_Y),
                DevModeField.Printer_Scale                 => DevModeRecord.Create(Name, This.Device.Printer.Scale),
                DevModeField.Printer_TrueTypeFontOptions   => DevModeRecord.Create(Name, This.Printer_TrueTypeFontOptions),

                _ => default(DevModeRecord)
            };
            
            return ret;
        }

        public static List<DevModeRecord> ToList(this DevModeA This) {
            var ret = (
                from x in Enum.GetValues(typeof(DevModeField)).OfType<DevModeField>()
                where This.Fields.HasFlag(x)
                let v = GetField(This, x)
                where v is { }
                select v
                ).ToList();

            return ret;
        }

        public static IDictionary<DevModeField, DevModeRecord> ToDictionary(this DevModeA This) {
            var ret = This.ToList().ToDictionary(x => x.Name, x => x);
            return ret;
        }
    }

}
