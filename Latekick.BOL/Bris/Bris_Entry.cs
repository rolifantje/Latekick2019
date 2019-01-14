using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Latekick.BOL;
using FileHelpers;


namespace Latekick.BOL.Brisnet
{
    [DelimitedRecord(",")]
    public class Bris_Entry
    {
        [FieldQuoted()]
        public string Track;

        [FieldQuoted()]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime RaceDate;

        public int RaceNumber;

        public int Draw;

        [FieldQuoted()]
        public string Entry;

        [FieldNullValue(-999)]
        public int ClaimingPrice;

        [FieldQuoted()]
        public string TrainerName;

        [FieldNullValue(-999)]
        public int TrainerStarts;

        [FieldNullValue(-999)]
        public int TrainerWin;

        [FieldNullValue(-999)]
        public int TrainerPlace;

        [FieldNullValue(-999)]
        public int TrainerShow;

        [FieldQuoted()]
        public string JockeyName;

        [FieldNullValue(-999)]
        public int ApprenticeAllowance;

        [FieldNullValue(-999)]
        public int JockeyStarts;

        [FieldNullValue(-999)]
        public int JockeyWin;

        [FieldNullValue(-999)]
        public int JockeyPlace;

        [FieldNullValue(-999)]
        public int JockeyShow;

        [FieldQuoted()]
        public string OwnerName;

        [FieldQuoted()]
        public string Trainer_ThisYear;

        [FieldQuoted()]
        public string Trainer_LastYear;

        [FieldQuoted()]
        public string Jockey_ThisYear;

        [FieldQuoted()]
        public string Jockey_LastYear;

        [FieldQuoted()]
        public string Owner_Silks;

        [FieldQuoted()]
        public string HorseName;

        [FieldNullValue(-999)]
        public int YearOfBirth;

        [FieldNullValue(-999)]
        public int MonthOfBirth;

        [FieldQuoted()]
        public string Reserved;

        [FieldQuoted()]
        public string Gender;

        [FieldQuoted()]
        public string HorseColour;

        [FieldNullValue(-999)]
        public int HorseWeight;

        [FieldQuoted()]
        public string Sire;

        [FieldQuoted()]
        public string SireSire;

        [FieldQuoted()]
        public string Dam;

        [FieldQuoted()]
        public string DamSire;

        [FieldQuoted()]
        public string Breeder;

        [FieldQuoted()]
        public string BreedingLocation;

        [FieldNullValue(-999)]
        public int AuctionPrice;

        [FieldQuoted()]
        public string AuctionLocationDate;

        [FieldQuoted()]
        public string Reserved2;

        [FieldQuoted()]
        public string MainTrackOnly;

        [FieldNullValue(-999)]
        public int Medication1;

        [FieldNullValue(-999)]
        public int Medication2;

        [FieldNullValue(-999)]
        public int EquipmentChange;

        #region Horse distance stats

        [FieldNullValue(-999)]
        public int Horse_Distance_Starts;

        [FieldNullValue(-999)]
        public int Horse_Distance_Win;

        [FieldNullValue(-999)]
        public int Horse_Distance_Place;

        [FieldNullValue(-999)]
        public int Horse_Distance_Show;

        [FieldNullValue(-999)]
        public int Horse_Distance_Earnings;

        #endregion

        #region Horse track stats
        
        [FieldNullValue(-999)]
        public int Horse_Track_Starts;

        [FieldNullValue(-999)]
        public int Horse_Track_Win;

        [FieldNullValue(-999)]
        public int Horse_Track_Place;

        [FieldNullValue(-999)]
        public int Horse_Track_Show;

        [FieldNullValue(-999)]
        public int Horse_Track_Earnings;

        #endregion

        #region Horse turf stats

        [FieldNullValue(-999)]
        public int Horse_Turf_Starts;

        [FieldNullValue(-999)]
        public int Horse_Turf_Win;

        [FieldNullValue(-999)]
        public int Horse_Turf_Place;

        [FieldNullValue(-999)]
        public int Horse_Turf_Show;

        [FieldNullValue(-999)]
        public int Horse_Turf_Earnings;

        #endregion

        #region Horse wet stats

        [FieldNullValue(-999)]
        public int Horse_Wet_Starts;

        [FieldNullValue(-999)]
        public int Horse_Wet_Win;

        [FieldNullValue(-999)]
        public int Horse_Wet_Place;

        [FieldNullValue(-999)]
        public int Horse_Wet_Show;

        [FieldNullValue(-999)]
        public int Horse_Wet_Earnings;

        #endregion

        #region Horse current year stats

        [FieldNullValue(-999)]
        public int Horse_CurrentYear;

        [FieldNullValue(-999)]
        public int Horse_CurrentYear_Starts;

        [FieldNullValue(-999)]
        public int Horse_CurrentYear_Win;

        [FieldNullValue(-999)]
        public int Horse_CurrentYear_Place;

        [FieldNullValue(-999)]
        public int Horse_CurrentYear_Show;

        [FieldNullValue(-999)]
        public int Horse_CurrentYear_Earnings;

        #endregion

        #region Horse last year stats

        [FieldNullValue(-999)]
        public int Horse_PreviousYear;

        [FieldNullValue(-999)]
        public int Horse_LastYear_Starts;

        [FieldNullValue(-999)]
        public int Horse_LastYear_Win;

        [FieldNullValue(-999)]
        public int Horse_LastYear_Place;

        [FieldNullValue(-999)]
        public int Horse_LastYear_Show;

        [FieldNullValue(-999)]
        public int Horse_LastYear_Earnings;

        #endregion

        #region Horse lifetime stats

        [FieldNullValue(-999)]
        public int Horse_LifeTime_Starts;

        [FieldNullValue(-999)]
        public int Horse_LifeTime_Win;

        [FieldNullValue(-999)]
        public int Horse_LifeTime_Place;

        [FieldNullValue(-999)]
        public int Horse_LifeTime_Show;

        [FieldNullValue(-999)]
        public int Horse_LifeTime_Earnings;

        #endregion

        #region Workout dates
        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_1;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_2;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_3;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_4;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_5;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_6;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_7;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_8;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_9;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_10;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_11;

        [FieldQuoted()]
        [FieldNullValue(typeof(DateTime), "3 DEC 1974")]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime WorkDate_12;
        #endregion

        #region Workout times
        [FieldNullValue(-999.99)]
        public double WorkTime_1;

        [FieldNullValue(-999.99)]
        public double WorkTime_2;

        [FieldNullValue(-999.99)]
        public double WorkTime_3;

        [FieldNullValue(-999.99)]
        public double WorkTime_4;

        [FieldNullValue(-999.99)]
        public double WorkTime_5;

        [FieldNullValue(-999.99)]
        public double WorkTime_6;

        [FieldNullValue(-999.99)]
        public double WorkTime_7;

        [FieldNullValue(-999.99)]
        public double WorkTime_8;

        [FieldNullValue(-999.99)]
        public double WorkTime_9;

        [FieldNullValue(-999.99)]
        public double WorkTime_10;

        [FieldNullValue(-999.99)]
        public double WorkTime_11;

        [FieldNullValue(-999.99)]
        public double WorkTime_12;
        #endregion

        #region Workout tracks
        [FieldQuoted()]
        public string WorkTrack_1;

        [FieldQuoted()]
        public string WorkTrack_2;

        [FieldQuoted()]
        public string WorkTrack_3;

        [FieldQuoted()]
        public string WorkTrack_4;

        [FieldQuoted()]
        public string WorkTrack_5;

        [FieldQuoted()]
        public string WorkTrack_6;

        [FieldQuoted()]
        public string WorkTrack_7;

        [FieldQuoted()]
        public string WorkTrack_8;

        [FieldQuoted()]
        public string WorkTrack_9;

        [FieldQuoted()]
        public string WorkTrack_10;

        [FieldQuoted()]
        public string WorkTrack_11;

        [FieldQuoted()]
        public string WorkTrack_12;
        #endregion

        #region Workout distances

        [FieldNullValue(-999)]
        public int WorkDistance_1;

        [FieldNullValue(-999)]
        public int WorkDistance_2;

        [FieldNullValue(-999)]
        public int WorkDistance_3;

        [FieldNullValue(-999)]
        public int WorkDistance_4;

        [FieldNullValue(-999)]
        public int WorkDistance_5;

        [FieldNullValue(-999)]
        public int WorkDistance_6;

        [FieldNullValue(-999)]
        public int WorkDistance_7;

        [FieldNullValue(-999)]
        public int WorkDistance_8;

        [FieldNullValue(-999)]
        public int WorkDistance_9;

        [FieldNullValue(-999)]
        public int WorkDistance_10;

        [FieldNullValue(-999)]
        public int WorkDistance_11;

        [FieldNullValue(-999)]
        public int WorkDistance_12;

        #endregion

        #region Workout goings

        [FieldQuoted()]
        public string WorkGoing_1;

        [FieldQuoted()]
        public string WorkGoing_2;

        [FieldQuoted()]
        public string WorkGoing_3;

        [FieldQuoted()]
        public string WorkGoing_4;

        [FieldQuoted()]
        public string WorkGoing_5;

        [FieldQuoted()]
        public string WorkGoing_6;

        [FieldQuoted()]
        public string WorkGoing_7;

        [FieldQuoted()]
        public string WorkGoing_8;

        [FieldQuoted()]
        public string WorkGoing_9;

        [FieldQuoted()]
        public string WorkGoing_10;

        [FieldQuoted()]
        public string WorkGoing_11;

        [FieldQuoted()]
        public string WorkGoing_12;
        
        #endregion

        #region Workout descriptions

        [FieldQuoted()]
        public string WorkDescription_1;

        [FieldQuoted()]
        public string WorkDescription_2;

        [FieldQuoted()]
        public string WorkDescription_3;

        [FieldQuoted()]
        public string WorkDescription_4;

        [FieldQuoted()]
        public string WorkDescription_5;

        [FieldQuoted()]
        public string WorkDescription_6;

        [FieldQuoted()]
        public string WorkDescription_7;

        [FieldQuoted()]
        public string WorkDescription_8;

        [FieldQuoted()]
        public string WorkDescription_9;

        [FieldQuoted()]
        public string WorkDescription_10;

        [FieldQuoted()]
        public string WorkDescription_11;

        [FieldQuoted()]
        public string WorkDescription_12;
        
        #endregion

        #region Workout surfaces

        [FieldQuoted()]
        public string WorkSurface_1;

        [FieldQuoted()]
        public string WorkSurface_2;

        [FieldQuoted()]
        public string WorkSurface_3;

        [FieldQuoted()]
        public string WorkSurface_4;

        [FieldQuoted()]
        public string WorkSurface_5;

        [FieldQuoted()]
        public string WorkSurface_6;

        [FieldQuoted()]
        public string WorkSurface_7;

        [FieldQuoted()]
        public string WorkSurface_8;

        [FieldQuoted()]
        public string WorkSurface_9;

        [FieldQuoted()]
        public string WorkSurface_10;

        [FieldQuoted()]
        public string WorkSurface_11;

        [FieldQuoted()]
        public string WorkSurface_12;

        #endregion

        #region Workout count

        [FieldNullValue(-999)]
        public int WorkCount_1;

        [FieldNullValue(-999)]
        public int WorkCount_2;

        [FieldNullValue(-999)]
        public int WorkCount_3;

        [FieldNullValue(-999)]
        public int WorkCount_4;

        [FieldNullValue(-999)]
        public int WorkCount_5;

        [FieldNullValue(-999)]
        public int WorkCount_6;

        [FieldNullValue(-999)]
        public int WorkCount_7;

        [FieldNullValue(-999)]
        public int WorkCount_8;

        [FieldNullValue(-999)]
        public int WorkCount_9;

        [FieldNullValue(-999)]
        public int WorkCount_10;

        [FieldNullValue(-999)]
        public int WorkCount_11;

        [FieldNullValue(-999)]
        public int WorkCount_12;

        #endregion

        #region Workout rank

        [FieldNullValue(-999)]
        public int WorkRank_1;

        [FieldNullValue(-999)]
        public int WorkRank_2;

        [FieldNullValue(-999)]
        public int WorkRank_3;

        [FieldNullValue(-999)]
        public int WorkRank_4;

        [FieldNullValue(-999)]
        public int WorkRank_5;

        [FieldNullValue(-999)]
        public int WorkRank_6;

        [FieldNullValue(-999)]
        public int WorkRank_7;

        [FieldNullValue(-999)]
        public int WorkRank_8;

        [FieldNullValue(-999)]
        public int WorkRank_9;

        [FieldNullValue(-999)]
        public int WorkRank_10;

        [FieldNullValue(-999)]
        public int WorkRank_11;

        [FieldNullValue(-999)]
        public int WorkRank_12;

        #endregion

        [FieldQuoted()]
        public string RunStyle;

        [FieldNullValue(-999)]
        public int Quirin;

        [FieldQuoted()]
        public string Reserved3;

        [FieldQuoted()]
        public string Reserved4;

        [FieldNullValue(-999)]
        public int PacePar_2F;

        [FieldNullValue(-999)]
        public int PacePar_4F;

        [FieldNullValue(-999)]
        public int PacePar_6F;

        [FieldNullValue(-999)]
        public int SpeedPar;

        [FieldNullValue(-999)]
        public int PacePar_Late;

        [FieldQuoted()]
        public string Reserved5;

        [FieldQuoted()]
        public string Reserved6;

        [FieldNullValue(-999)]
        public int Draw_2;

        [FieldQuoted()]
        public string SaddleCloth;

        [FieldNullValue(-999.99)]
        public double ML;

        [FieldNullValue(-999)]
        public int DaysSinceLastRace;

        [FieldQuoted()]
        public string Conditions_1;

        [FieldQuoted()]
        public string Conditions_2;

        [FieldQuoted()]
        public string Conditions_3;

        [FieldQuoted()]
        public string Conditions_4;

        [FieldQuoted()]
        public string Conditions_5;

        [FieldQuoted()]
        public string Conditions_6;

        #region Horse lifetime AW stats

        [FieldNullValue(-999)]
        public int Horse_LifeTime_AW_Starts;

        [FieldNullValue(-999)]
        public int Horse_LifeTime_AW_Win;

        [FieldNullValue(-999)]
        public int Horse_LifeTime_AW_Place;

        [FieldNullValue(-999)]
        public int Horse_LifeTime_AW_Show;

        [FieldNullValue(-999)]
        public int Horse_LifeTime_AW_Earnings;

        #endregion    
        
        [FieldNullValue(-999)]
        public int BestBris_AW;

        [FieldQuoted()]
        public string Reserved7;

        [FieldNullValue(-999)]
        public int ClaimingPrice_Low;

        [FieldQuoted()]
        public string StateBred;

        #region Wager Types

        [FieldQuoted()]
        public string WagerType_1;

        [FieldQuoted()]
        public string WagerType_2;

        [FieldQuoted()]
        public string WagerType_3;

        [FieldQuoted()]
        public string WagerType_4;

        [FieldQuoted()]
        public string WagerType_5;

        [FieldQuoted()]
        public string WagerType_6;

        [FieldQuoted()]
        public string WagerType_7;

        [FieldQuoted()]
        public string WagerType_8;

        [FieldQuoted()]
        public string WagerType_9;

        #endregion

        [FieldNullValue(-999)]
        public int Sire_CurrentStudFee;

        [FieldNullValue(-999)]
        public int BestBris_Fast;

        [FieldNullValue(-999)]
        public int BestBris_Turf;

        [FieldNullValue(-999)]
        public int BestBris_OffTrack;

        [FieldNullValue(-999)]
        public int BestBris_Distance;

        [FieldQuoted()]
        public string Reserved8;

        [FieldQuoted()]
        public string Reserved9;
    }
}
