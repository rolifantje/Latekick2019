using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Latekick.BOL;
using FileHelpers;

namespace Latekick.BOL.Brisnet
{

    [DelimitedRecord(",")]    
    public class Bris_PastPerformance
    {
        #region Information about today's races

        [FieldQuoted()]
        public string Track_This_Day;

        [FieldQuoted()]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime RaceDate_This_Day;

        public int RaceNumber_This_Day;

        public int Draw_This_Day;


        [FieldQuoted()]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime RaceDate;
        #endregion


        [FieldNullValue(-999)]
        public int DaysOff;

        [FieldQuoted()]
        public string Track;

        [FieldQuoted()]
        public string Track_BRIS_Code;

        [FieldNullValue(-999)]
        public int RaceNumber;

        [FieldQuoted()]
        public string Going;

        [FieldNullValue(-999)]
        public int DistanceYards;

        [FieldQuoted()]
        public string Surface;

        [FieldQuoted()]
        public string Chute;

        [FieldNullValue(-999)]
        public int FieldSize;

        [FieldNullValue(-999)]
        public int Draw;

        [FieldQuoted()]
        public string Equipment;

        [FieldQuoted()]
        public string Reserved;

        [FieldNullValue(-999)]
        public int Medication;

        [FieldQuoted()]
        public string TripComment;

        #region WPS information

        [FieldQuoted()]
        public string WinName;

        [FieldQuoted()]
        public string PlaceName;

        [FieldQuoted()]
        public string ShowName;

        [FieldNullValue(-999)]
        public int WinWeight;

        [FieldNullValue(-999)]
        public int PlaceWeight;

        [FieldNullValue(-999)]
        public int ShowWeight;

        [FieldNullValue(-999.99)]
        public double WinMargin;

        [FieldNullValue(-999.99)]
        public double PlaceMargin;

        [FieldNullValue(-999.99)]
        public double ShowMargin;

        #endregion

        [FieldQuoted()]
        public string ExtraComment;

        [FieldNullValue(-999)]
        public int Weight;

        [FieldNullValue(-999.99)]
        public double Odds;

        [FieldQuoted()]
        public string Entry;

        [FieldQuoted()]
        public string RaceClassification;

        [FieldNullValue(-999)]
        public int ClaimingPrice;

        [FieldNullValue(-999)]
        public int Purse;

        #region Positions

        [FieldQuoted()]
        public string Pos_Start;

        [FieldQuoted()]
        public string Pos_1;

        [FieldQuoted()]
        public string Pos_2;

        [FieldQuoted()]
        public string Pos_Gate;

        [FieldQuoted()]
        public string Pos_Stretch;

        [FieldQuoted()]
        public string Pos_Finish;

        [FieldQuoted()]
        public string Pos_Money;

        #endregion

        #region Beaten lengths

        [FieldNullValue(-999.99)]
        public double BLMargin_Start;

        [FieldNullValue(-999.99)]
        public double BL_Start;

        [FieldNullValue(-999.99)]
        public double BLMargin_1;

        [FieldNullValue(-999.99)]
        public double BL_1;

        [FieldNullValue(-999.99)]
        public double BLMargin_2;

        [FieldNullValue(-999.99)]
        public double BL_2;

        [FieldQuoted()]
        public string Reserved2;

        [FieldQuoted()]
        public string Reserved3;

        [FieldNullValue(-999.99)]
        public double BLMargin_Stretch;

        [FieldNullValue(-999.99)]
        public double BL_Stretch;

        [FieldNullValue(-999.99)]
        public double BLMargin_Finish;

        [FieldNullValue(-999.99)]
        public double BL_Finish;

        #endregion

        #region BRIS numbers

        [FieldNullValue(-999.99)]
        public double RaceShape_2;

        [FieldNullValue(-999)]
        public int PaceFig_2f;

        [FieldNullValue(-999)]
        public int PaceFig_4f;

        [FieldNullValue(-999)]
        public int PaceFig_6f;

        [FieldNullValue(-999)]
        public int PaceFig_8f;

        [FieldNullValue(-999)]
        public int PaceFig_10f;

        [FieldNullValue(-999)]
        public int PaceFig_Late;

        [FieldNullValue(-999)]
        public int RaceShape_1;

        [FieldQuoted()]
        public string Reserved4;

        [FieldNullValue(-999)]
        public int SpeedFig_BRIS;

        [FieldNullValue(-999)]
        public int SpeedFig;

        #endregion

        [FieldNullValue(-999)]
        public int DTV;

        #region Fractions

        [FieldNullValue(-999.99)]
        public double Fraction_2f;

        [FieldNullValue(-999.99)]
        public double Fraction_3f;

        [FieldNullValue(-999.99)]
        public double Fraction_4f;

        [FieldNullValue(-999.99)]
        public double Fraction_5f;

        [FieldNullValue(-999.99)]
        public double Fraction_6f;

        [FieldNullValue(-999.99)]
        public double Fraction_7f;

        [FieldNullValue(-999.99)]
        public double Fraction_8f;

        [FieldNullValue(-999.99)]
        public double Fraction_10f;

        [FieldNullValue(-999.99)]
        public double Fraction_12f;

        [FieldNullValue(-999.99)]
        public double Fraction_14f;

        [FieldNullValue(-999.99)]
        public double Fraction_16f;

        [FieldNullValue(-999.99)]
        public double Fraction_1;

        [FieldNullValue(-999.99)]
        public double Fraction_2;

        [FieldNullValue(-999.99)]
        public double Fraction_3;
        
        [FieldQuoted()]
        public string Reserved4b;

        [FieldQuoted()]
        public string Reserved5;

        [FieldNullValue(-999.99)]
        public double FinalTime;
        
        #endregion

        [FieldQuoted()]
        public string Claimed;

        [FieldQuoted()]
        public string Trainer;

        [FieldQuoted()]
        public string Jockey;

        [FieldNullValue(-999)]
        public int ApprenticeWeight;

        [FieldQuoted()]
        public string RaceType;

        [FieldQuoted()]
        public string Restrictions;

        [FieldQuoted()]
        public string StateBred;

        [FieldQuoted()]
        public string RestrictedQualifier;

        [FieldNullValue(-999)]
        public int Favourite;

        [FieldNullValue(-999)]
        public int FrontBandages;

        [FieldNullValue(-999)]
        public int LastBrisSpeedFig;

        [FieldQuoted()]
        public string BarShoes;

        [FieldQuoted()]
        public string CompanyLineCodes;

        [FieldNullValue(-999)]
        public int ClaimingPrice_Low;

        [FieldNullValue(-999)]
        public int ClaimingPrice_High;

        [FieldQuoted()]
        public string Reserved6;

        [FieldQuoted()]
        public string PreviousRaceCode; /*Nasal Strip or Off the turf */

        [FieldQuoted()]
        public string Reserved7;

        [FieldQuoted()]
        public string Reserved8;

        [FieldQuoted()]
        public string Reserved9;

        [FieldQuoted()]
        public string Reserved10;

        [FieldQuoted()]
        public string Reserved11;

        [FieldQuoted()]
        public string Reserved12;

        [FieldQuoted()]
        public string StartComment;

        [FieldQuoted()]
        public string SealedTrack;

        [FieldQuoted()]
        public string PreviousAllWeather;

        [FieldQuoted()]
        public string Reserved13;

        [FieldQuoted()]
        public string Reserved14;

        [FieldQuoted()]
        public string Reserved15;

        [FieldQuoted()]
        public string Reserved16;

        [FieldQuoted()]
        public string Reserved17;

        [FieldQuoted()]
        public string Reserved18;

        [FieldQuoted()]
        public string Reserved19;

        [FieldQuoted()]
        public string Reserved20;

        [FieldQuoted()]
        public string Reserved21;

        [FieldQuoted()]
        public string Reserved22;

        [FieldQuoted()]
        public string Reserved23;

        [FieldQuoted()]
        public string Reserved24;

        [FieldQuoted()]
        public string Reserved25;

    
    }
}
