using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Latekick;
using Latekick.DAL.Base;


namespace Latekick.BLL.Base
{
    public class HorseBL
    {
        public static BOL.Base.Horse CreateObject()
        {
            return new Latekick.BOL.Base.Horse();
        }

        public static void CompileObject(XElement xe, Latekick.BOL.Base.Horse horse)
        {
            DataTable dtHorse = HorseDAL.GetHorseData(xe);

            horse.Name = dtHorse.Rows[0].ItemArray[dtHorse.Columns.IndexOf("HorseName")].ToString();
            horse.Gender = dtHorse.Rows[0].ItemArray[dtHorse.Columns.IndexOf("Gender")].ToString();
            int age = 0;
            Int32.TryParse(dtHorse.Rows[0].ItemArray[dtHorse.Columns.IndexOf("Age")].ToString(), out age);
            horse.Age = age;
            horse.Sire = dtHorse.Rows[0].ItemArray[dtHorse.Columns.IndexOf("Sire")].ToString();
            horse.Dam = dtHorse.Rows[0].ItemArray[dtHorse.Columns.IndexOf("Dam")].ToString();
            horse.DamSire = dtHorse.Rows[0].ItemArray[dtHorse.Columns.IndexOf("DamSire")].ToString();
        }


        public static void LoadWorkouts(XElement xe, Latekick.BOL.Base.Entry entry)
        {
            DataTable dtWorkouts = HorseDAL.GetWorkouts(xe);

            entry.ThisHorse.Workouts = new Latekick.BOL.Base.Workout[dtWorkouts.Rows.Count];

            for (int i = 0; i < dtWorkouts.Rows.Count; i++)
            {
                entry.ThisHorse.Workouts[i] = new Latekick.BOL.Base.Workout();
                entry.ThisHorse.Workouts[i].WorkDate = DateTime.Parse(dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkDate")].ToString());
                entry.ThisHorse.Workouts[i].WorkCourse = dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkTrack")].ToString();
                entry.ThisHorse.Workouts[i].WorkDaysAgo = dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkDaysAgo")].ToString();
                entry.ThisHorse.Workouts[i].WorkDistance = Double.Parse(dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkDistance")].ToString());
                entry.ThisHorse.Workouts[i].WorksSurface = dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkSurface")].ToString();
                entry.ThisHorse.Workouts[i].WorkGoing = dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkGoing")].ToString();
                entry.ThisHorse.Workouts[i].WorkMates = dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkMates")].ToString();
                entry.ThisHorse.Workouts[i].WorkTime = Double.Parse(dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkTime")].ToString());
                entry.ThisHorse.Workouts[i].WorkRating = Double.Parse(dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkRating")].ToString());
                entry.ThisHorse.Workouts[i].WorkDescription = dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkDescription")].ToString();
                entry.ThisHorse.Workouts[i].Gate = int.Parse(dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkFromGate")].ToString());
                entry.ThisHorse.Workouts[i].WorkRank = dtWorkouts.Rows[i].ItemArray[dtWorkouts.Columns.IndexOf("WorkRank")].ToString();
            }
        }

        public static void LoadPastPerformances(XElement xe, Latekick.BOL.Base.Entry entry)
        {
            DataTable dtPPs = HorseDAL.GetPastPerformances(xe);

            entry.ThisHorse.PastPerformances = new Latekick.BOL.Base.Performance[dtPPs.Rows.Count];

            for (int i = 0; i < dtPPs.Rows.Count; i++)
            {
                entry.ThisHorse.PastPerformances[i] = new Latekick.BOL.Base.Performance();

                entry.ThisHorse.PastPerformances[i].ThisRace = new Latekick.BOL.Base.Race();
                try
                {
                    entry.ThisHorse.PastPerformances[i].ThisRace.Purse = double.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Purse")].ToString());
                }
                catch { }
                try
                {
                    entry.ThisHorse.PastPerformances[i].ThisRace.ClaimingPrice = int.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("claim")].ToString());
                }
                catch { }
                entry.ThisHorse.PastPerformances[i].ThisRace.RaceDate = DateTime.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("RaceDate")].ToString());

                entry.ThisHorse.PastPerformances[i].ThisRace.CourseAbbreviation = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("CourseCode")].ToString();
                entry.ThisHorse.PastPerformances[i].ThisRace.Going = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Going")].ToString().ToLower();
                entry.ThisHorse.PastPerformances[i].ThisRace.Distance = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("DistanceFurlongs")].ToString();
                entry.ThisHorse.PastPerformances[i].ThisRace.Surface = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Surface")].ToString();
                entry.ThisHorse.PastPerformances[i].ThisRace.RaceClass = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("ClassRating_GMR")].ToString();
                entry.ThisHorse.PastPerformances[i].ThisRace.RaceType = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("RaceType")].ToString();
                entry.ThisHorse.PastPerformances[i].ThisRace.Finish123 = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Finish123")].ToString();
                entry.ThisHorse.PastPerformances[i].ThisRace.Finish123_GMR = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Finish123_GMR")].ToString();
                entry.ThisHorse.PastPerformances[i].OfficialPositionText = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("OfficialPositionText")].ToString();
                try
                {
                    entry.ThisHorse.PastPerformances[i].OfficialPosition = int.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("OfficialFinish")].ToString());
                }
                catch { }
                try
                {
                    entry.ThisHorse.PastPerformances[i].Odds = Double.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Odds")].ToString());
                }
                catch { }
                entry.ThisHorse.PastPerformances[i].OddsText = entry.ThisHorse.PastPerformances[i].Odds.Value.ToString("#.#");
                try
                {
                    entry.ThisHorse.PastPerformances[i].Weight = int.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Weight")].ToString());
                }
                catch { }
                try
                {
                    entry.ThisHorse.PastPerformances[i].DistanceBeaten = double.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("DistanceBeaten")].ToString());
                }
                catch { }

                System.Globalization.TextInfo ti = new System.Globalization.CultureInfo("en-US", false).TextInfo;

                entry.ThisHorse.PastPerformances[i].JockeyName = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("JockeyName")].ToString();
                entry.ThisHorse.PastPerformances[i].TrainerName = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("TrainerName")].ToString();
                entry.ThisHorse.PastPerformances[i].PerformanceComment = dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("TripComment")].ToString();

                entry.ThisHorse.PastPerformances[i].Early = int.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Early")].ToString());
                entry.ThisHorse.PastPerformances[i].Middle = int.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Middle")].ToString());
                entry.ThisHorse.PastPerformances[i].Late = int.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Late")].ToString());
                entry.ThisHorse.PastPerformances[i].GMR = int.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("Latekick")].ToString());
                entry.ThisHorse.PastPerformances[i].LateSpeed = Double.Parse(dtPPs.Rows[i].ItemArray[dtPPs.Columns.IndexOf("LateSpeed")].ToString());



            }
        }

        public static void LoadRunningStyle(XElement xe, Latekick.BOL.Base.Entry entry)
        {
            DataTable dtRunningStyle = HorseDAL.GetRunningStyle(xe);

            entry.ThisHorse.RunStyle = new Latekick.BOL.Base.Horse.RunningStyle();

            try { entry.ThisHorse.RunStyle.RunStyle_BRIS = dtRunningStyle.Rows[0].ItemArray[dtRunningStyle.Columns.IndexOf("RunStyle_BRIS")].ToString().Trim(); }
            catch { }
            try { entry.ThisHorse.RunStyle.PaceRuns = int.Parse(dtRunningStyle.Rows[0].ItemArray[dtRunningStyle.Columns.IndexOf("paceRuns")].ToString()); }
            catch { }
            try { entry.ThisHorse.RunStyle.PaceWins = int.Parse(dtRunningStyle.Rows[0].ItemArray[dtRunningStyle.Columns.IndexOf("paceWins")].ToString()); }
            catch { }
            try { entry.ThisHorse.RunStyle.OffPaceRuns = int.Parse(dtRunningStyle.Rows[0].ItemArray[dtRunningStyle.Columns.IndexOf("offPaceRuns")].ToString()); }
            catch { }
            try { entry.ThisHorse.RunStyle.OffPaceWins = int.Parse(dtRunningStyle.Rows[0].ItemArray[dtRunningStyle.Columns.IndexOf("offPaceWins")].ToString()); }
            catch { }
        }

        public static void LoadEarnings(XElement xe, Latekick.BOL.Base.Entry entry)
        {
            DataTable dtEarnings = HorseDAL.GetEarnings(xe);
            try
            {
                entry.ThisHorse.EarningsLifeTime = int.Parse(dtEarnings.Rows[0].ItemArray[dtEarnings.Columns.IndexOf("EarningsLifeTime")].ToString());
            }
            catch { }
        }    
    }
}
