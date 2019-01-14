using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Latekick.BOL;
using FileHelpers;

namespace Latekick.BOL.Brisnet
{
    [DelimitedRecord(",")]
    public class Bris_Stats
    {
        [FieldQuoted()]
        public string Track_This_Day;

        [FieldQuoted()]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime RaceDate_This_Day;

        public int RaceNumber_This_Day;

        public int Draw_This_Day;

        [FieldNullValue(-999.99)]
        public double PrimePowerRating;

        [FieldQuoted()]
        public string DirtPedigreeRating;

        [FieldQuoted()]
        public string MudPedigreeRating;

        [FieldQuoted()]
        public string TurfPedigreeRating;

        [FieldQuoted()]
        public string DistPedigreeRating;

        [FieldNullValue(-999)]
        public int BestBRIS_Lifetime;

        [FieldNullValue(-999)]
        public int BestBRIS_RecentYear;

        [FieldNullValue(-999)]
        public int BestBRIS_RecentYear_2;

        [FieldNullValue(-999)]
        public int BestBRIS_Track;

        [FieldNullValue(-999)]
        public int FastDirtStarts;

        [FieldNullValue(-999)]
        public int FastDirtWin;

        [FieldNullValue(-999)]
        public int FastDirtPlace;

        [FieldNullValue(-999)]
        public int FastDirtShow;

        [FieldNullValue(-999)]
        public int FastDirtEarnings;

        #region Stat categories and numbers

        [FieldQuoted()]
        public string StatCategory_1;

        [FieldNullValue(-999)]
        public int StatCategory_1_Starts;

        [FieldNullValue(-999.99)]
        public double StatCategory_1_WinPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_1_ItmPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_1_ROI;

        [FieldQuoted()]
        public string StatCategory_2;

        [FieldNullValue(-999)]
        public int StatCategory_2_Starts;

        [FieldNullValue(-999.99)]
        public double StatCategory_2_WinPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_2_ItmPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_2_ROI;

        [FieldQuoted()]
        public string StatCategory_3;

        [FieldNullValue(-999)]
        public int StatCategory_3_Starts;

        [FieldNullValue(-999.99)]
        public double StatCategory_3_WinPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_3_ItmPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_3_ROI;

        [FieldQuoted()]
        public string StatCategory_4;

        [FieldNullValue(-999)]
        public int StatCategory_4_Starts;

        [FieldNullValue(-999.99)]
        public double StatCategory_4_WinPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_4_ItmPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_4_ROI;

        [FieldQuoted()]
        public string StatCategory_5;

        [FieldNullValue(-999)]
        public int StatCategory_5_Starts;

        [FieldNullValue(-999.99)]
        public double StatCategory_5_WinPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_5_ItmPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_5_ROI;

        [FieldQuoted()]
        public string StatCategory_6;

        [FieldNullValue(-999)]
        public int StatCategory_6_Starts;

        [FieldNullValue(-999.99)]
        public double StatCategory_6_WinPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_6_ItmPct;

        [FieldNullValue(-999.99)]
        public double StatCategory_6_ROI;


        
        #endregion

        [FieldQuoted()]
        public string Reserved;

        [FieldQuoted()]
        public string JockDistance_Turf_Label;

        [FieldNullValue(-999)]
        public int JockDistance_Turf_Starts;

        [FieldNullValue(-999)]
        public int JockDistance_Turf_Win;

        [FieldNullValue(-999)]
        public int JockDistance_Turf_Place;

        [FieldNullValue(-999)]
        public int JockDistance_Turf_Show;

        [FieldNullValue(-999.99)]
        public double JockDistance_Turf_ROI;

        [FieldNullValue(-999.99)]
        public double JockDistance_Turf_Earnings;


        [FieldQuoted()]
        public string Reserved2;
    }
}
