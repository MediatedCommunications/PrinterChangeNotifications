using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterChangeNotifications.Native.DevMode {

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DevModeA {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;

        public ushort DevMode_Version;
        public ushort DriverVersion;
        public ushort DevMode_Size;
        public ushort DriverExtra;
        public DevModeField Fields;
        public DevModeDevice Device;
        public PrinterPalette Printer_Color;
        public PrinterDuplex Printer_Duplex;
        public short Printer_PrintQuality_Y;
        public PrinterTrueTypeFontOptions Printer_TrueTypeFontOptions;
        public PrinterCollate Printer_Collate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string Printer_FormName;
        public ushort Display_PixelsPerLogicalInch;
        public uint Display_BitsPerPixel;
        public uint Display_PixelsH;
        public uint Display_PixelsW;
        public DevMode_Device_Flags DeviceFlags;
        public uint Display_Frequency;
        public PrinterIcmMethod Printer_ICM_Method;
        public PrinterIcmIntent Printer_ICM_Intent;
        public PrinterMediaType Printer_MediaType;
        public DevMode_Dither Dither;
        public uint Reserved1;
        public uint Reserved2;
        public uint Panning_Width;
        public uint Panning_Height;
    }

}
