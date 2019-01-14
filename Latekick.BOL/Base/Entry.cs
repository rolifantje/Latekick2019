using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Latekick.DAL.Base;

namespace Latekick.BOL.Base
{
    public class Entry
    {
        #region Variables
        Race thisRace;
        ProjectedRatings projRatings;
        WPSStats horse_LifeTime_Stats, horse_LastYear_Stats, horse_CurrentYear_Stats, horse_Track_Stats;
        WPSStats horse_Dirt_Stats, horse_Turf_Stats, horse_AW_Stats, horse_Wet_Stats, horse_Distance_Stats;
        WPSStats jockey_Meet, trainer_Meet, jockey_30Days, trainer_30Days;
        Horse thisHorse;
        BrisStat[] brisStats;

        string jockeyName, trainerName, ownerName, medication, equip, saddleClothNo;

        string trainer_ThisYear, trainer_LastYear, jockey_ThisYear, jockey_LastYear;
        int? draw;
        double? weightCarried, wfa, mL, odds, trueOdds, apprenticeAllowance;
        #endregion

        #region Properties
        public Race ThisRace
        {
            get { return thisRace; }
            set { thisRace = value; }
        }
        public Horse ThisHorse
        {
            get { return thisHorse; }
            set { thisHorse = value; }
        }

        public ProjectedRatings ProjRatings
        {
            get { return projRatings; }
            set { projRatings = value; }
        }

        public WPSStats Horse_LifeTime_Stats
        {
          get { return horse_LifeTime_Stats; }
          set { horse_LifeTime_Stats = value; }
        }
        public WPSStats Horse_Track_Stats
        {
          get { return horse_Track_Stats; }
          set { horse_Track_Stats = value; }
        }
        public WPSStats Horse_CurrentYear_Stats
        {
          get { return horse_CurrentYear_Stats; }
          set { horse_CurrentYear_Stats = value; }
        }
        public WPSStats Horse_LastYear_Stats
        {
          get { return horse_LastYear_Stats; }
          set { horse_LastYear_Stats = value; }
        }
        public WPSStats Horse_Distance_Stats
        {
          get { return horse_Distance_Stats; }
          set { horse_Distance_Stats = value; }
        }
        public WPSStats Horse_Wet_Stats
        {
          get { return horse_Wet_Stats; }
          set { horse_Wet_Stats = value; }
        }
        public WPSStats Horse_Dirt_Stats
        {
          get { return horse_Dirt_Stats; }
          set { horse_Dirt_Stats = value; }
        }
        public WPSStats Horse_AW_Stats
        {
            get { return horse_AW_Stats; }
            set { horse_AW_Stats = value; }
        }
        public WPSStats Horse_Turf_Stats
        {
            get { return horse_Turf_Stats; }
            set { horse_Turf_Stats = value; }
        }
        public WPSStats Trainer_Meet
        {
            get { return trainer_Meet; }
            set { trainer_Meet = value; }
        }
        public WPSStats Jockey_Meet
        {
            get { return jockey_Meet; }
            set { jockey_Meet = value; }
        }

        public WPSStats Trainer_30Days
        {
            get { return trainer_30Days; }
            set { trainer_30Days = value; }
        }

        public WPSStats Jockey_30Days
        {
            get { return jockey_30Days; }
            set { jockey_30Days = value; }
        }

        public BrisStat[] BrisStats
        {
            get { return brisStats; }
            set { brisStats = value; }
        }        

        public string Trainer_ThisYear
        {
            get { return trainer_ThisYear; }
            set { trainer_ThisYear = value; }
        }
        public string Trainer_LastYear
        {
            get { return trainer_LastYear; }
            set { trainer_LastYear = value; }
        }

        public string Jockey_ThisYear
        {
            get { return jockey_ThisYear; }
            set { jockey_ThisYear = value; }
        }
        public string Jockey_LastYear
        {
            get { return jockey_LastYear; }
            set { jockey_LastYear = value; }
        }

        public string JockeyName
        {
            get { return jockeyName; }
            set { jockeyName = value; }
        }
        public string TrainerName
        {
            get { return trainerName; }
            set { trainerName = value; }
        }
        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }
        }
        public string Equip
        {
            get { return equip; }
            set { equip = value; }
        }
        public string Medication
        {
            get { return medication; }
            set { medication = value; }
        }
        public string SaddleClothNo
        {
            get { return saddleClothNo; }
            set { saddleClothNo = value; }
        }
        public int? Draw
        {
            get { return draw; }
            set { draw = value; }
        }
        public double? WeightCarried
        {
            get { return weightCarried; }
            set { weightCarried = value; }
        }
        public double? ApprenticeAllowance
        {
            get { return apprenticeAllowance; }
            set { apprenticeAllowance = value; }
        }
        public double? WFA
        {
            get { return wfa; }
            set { wfa = value; }
        }
        public double? ML
        {
            get { return mL; }
            set { mL = value; }
        }
        public double? Odds
        {
            get { return odds; }
            set { odds = value; }
        }
        public double? TrueOdds
        {
            get { return trueOdds; }
            set { trueOdds = value; }
        }
        #endregion

        #region Constructors

        public Entry()
        { }

        public Entry(Race thisrace, Horse thishorse)
        {
            thisRace = thisrace;
            thisHorse = thishorse;
            //LoadRunnerInformation();
        }

        #endregion

        public class ProjectedRatings
        {
            double? early, middle, late, dash, golden, average, recent, quirin;

            public double? Early
            {
                get { return early; }
                set { early = value; }
            }
            public double? Middle
            {
                get { return middle; }
                set { middle = value; }
            }
            public double? Late
            {
                get { return late; }
                set { late = value; }
            }
            public double? Dash
            {
                get { return dash; }
                set { dash = value; }
            }
            public double? Golden
            {
                get { return golden; }
                set { golden = value; }
            }
            public double? Average
            {
                get { return average; }
                set { average = value; }
            }
            public double? Recent
            {
                get { return recent; }
                set { recent = value; }
            }
            public double? Quirin
            {
                get { return quirin; }
                set { quirin = value; }
            }
        }

        public class WPSStats
        {
            #region Variables
            int win = 0;
            int place = 0;
            int show = 0;
            int runs = 0;
            #endregion

            #region Properties

            public int Win
            {
                get { return win; }
                set { win = value; }
            }
            public int Place
            {
                get { return place; }
                set { place = value; }
            }
            public int Show
            {
                get { return show; }
                set { show = value; }
            }
            public int Runs
            {
                get { return runs; }
                set { runs = value; }
            }
            #endregion
        }

        public class BrisStat
        {
            #region Variables
            string category;

            int runs = 0;
            double winRatio = 0, iTM = 0, rOI = 0;
            #endregion

            #region Properties
            public string Category
            {
                get { return category; }
                set { category = value; }
            }
            public int Runs
            {
                get { return runs; }
                set { runs = value; }
            }
            public double WinRatio
            {
                get { return winRatio; }
                set { winRatio = value; }
            }
            public double ITM
            {
                get { return iTM; }
                set { iTM = value; }
            }
            public double ROI
            {
                get { return rOI; }
                set { rOI = value; }
            }
            #endregion
        }

    }
}
