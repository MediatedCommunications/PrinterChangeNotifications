using System;
using System.Collections.Generic;
using System.Linq;

namespace PrinterChangeNotifications.Native.DevMode {
    public static class DEVMODEEXTENSIONS {

        private static IFieldName<DevModeFields> GetField(this DevModeA This, DevModeFields Name) {
            var ret = Name switch
            {

                DevModeFields.Panning_Height                => Field.Create(Name, This.Panning_Height),
                DevModeFields.Panning_Width                 => Field.Create(Name, This.Panning_Width),
                
                DevModeFields.Dither                        => Field.Create(Name, This.Dither),

                DevModeFields.Display_BitsPerPixel          => Field.Create(Name, This.Display_BitsPerPixel),
                DevModeFields.Display_PixelsPerLogicalInch  => Field.Create(Name, This.Display_PixelsPerLogicalInch),
                DevModeFields.Display_PixelsH               => Field.Create(Name, This.Display_PixelsH),
                DevModeFields.Display_PixelsW               => Field.Create(Name, This.Display_PixelsW),
                DevModeFields.Display_Position              => Field.Create(Name, This.Device.Display.Position),
                DevModeFields.Display_FixedOutput           => Field.Create(Name, This.Device.Display.DisplayFixedOutput),
                DevModeFields.Display_Flags                 => Field.Create(Name, This.DeviceFlags.Display_Flags),
                DevModeFields.Display_Frequency             => Field.Create(Name, This.Display_Frequency),
                DevModeFields.Display_Orientation           => Field.Create(Name, This.Device.Display.Orientation),

                DevModeFields.Printer_Collate               => Field.Create(Name, This.Printer_Collate),
                DevModeFields.Printer_Color                 => Field.Create(Name, This.Printer_Color),
                DevModeFields.Printer_Copies                => Field.Create(Name, This.Device.Printer.Copies),
                DevModeFields.Printer_DefaultSource         => Field.Create(Name, This.Device.Printer.DefaultSource),
                DevModeFields.Printer_Duplex                => Field.Create(Name, This.Printer_Duplex),
                DevModeFields.Printer_FormName              => Field.Create(Name, This.Printer_FormName),
                DevModeFields.Printer_ICM_Intent            => Field.Create(Name, This.Printer_ICM_Intent),
                DevModeFields.Printer_ICM_Method            => Field.Create(Name, This.Printer_ICM_Method),
                DevModeFields.Printer_MediaType             => Field.Create(Name, This.Printer_MediaType),
                DevModeFields.Printer_Orientation           => Field.Create(Name, This.Device.Printer.Orientation),
                DevModeFields.Printer_PageLayout            => Field.Create(Name, This.DeviceFlags.Printer_PageLayout),
                DevModeFields.Printer_Paper_Length          => Field.Create(Name, This.Device.Printer.Paper_Length),
                DevModeFields.Printer_Paper_Size            => Field.Create(Name, This.Device.Printer.Paper_Size),
                DevModeFields.Printer_Paper_Width           => Field.Create(Name, This.Device.Printer.Paper_Width),
                DevModeFields.Printer_PrintQuality_X        => Field.Create(Name, This.Device.Printer.PrintQuality_X),
                DevModeFields.Printer_PrintQuality_Y        => Field.Create(Name, This.Printer_PrintQuality_Y),
                DevModeFields.Printer_Scale                 => Field.Create(Name, This.Device.Printer.Scale),
                DevModeFields.Printer_TrueTypeFontOptions   => Field.Create(Name, This.Printer_TrueTypeFontOptions),

                _ => default(IFieldName<DevModeFields>)
            };
            
            return ret;
        }

        public static List<IFieldName<DevModeFields>> ToList(this DevModeA This) {
            var ret = (
                from x in Enum.GetValues(typeof(DevModeFields)).OfType<DevModeFields>()
                where This.Fields.HasFlag(x)
                select GetField(This, x)
                ).ToList();

            return ret;
        }

        public static IDictionary<DevModeFields, IFieldName<DevModeFields>> ToDictionary(this DevModeA This) {
            var ret = This.ToList().ToDictionary(x => x.Name, x => x);
            return ret;
        }
    }

}
