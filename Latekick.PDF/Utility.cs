using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Latekick.PDF
{
    public static class Utility
    {

        public static System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("en-GB", false).TextInfo;


        public static System.Globalization.NumberFormatInfo GetNFI()
        {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
            nfi.CurrencySymbol = "£";
            return nfi;
        }

        public static string FormatNumber(int num)
        {
            //if (num >= 100000)
            //    return FormatNumber(num / 1000) + "K";
            if (num >= 1000)
            {
                return (num / 1000D).ToString("0.#") + "K";
            }
            return num.ToString("#,0");
        }

        public static string FormatNumber(double num)
        {
            //if (num >= 100000)
            //    return FormatNumber(num / 1000) + "K";
            if (num >= 1000)
            {
                return (num / 1000D).ToString("0.#") + "K";
            }
            return num.ToString("#,0");
        }
    }
}
