using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BingWallpaper
{
    public class Wallpaper
    {

        public static void SetWallPaper(string filename)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, filename,SPIF_UPDATEINIFILE);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, String pvParam, UInt32 fWinIni);
        private static UInt32 SPI_SETDESKWALLPAPER = 20;
        private static UInt32 SPIF_UPDATEINIFILE = 0x1;

    }

}
