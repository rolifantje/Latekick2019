using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using Latekick.BOL.Latekick;

namespace Latekick.BLL.Conversion
{
    public class LatekickExtras
    {
        Latekick_Card latekickCard;

        public Latekick_Card LatekickCard
        {
            get { return latekickCard; }
            set { latekickCard = value; }
        }

        public LatekickExtras()
        {
        }

        public void UpdateRaces()
        {
            latekick.com.Latekick2 ws = new Latekick.BLL.latekick.com.Latekick2();

            foreach (Latekick.BOL.Latekick.Race race in latekickCard.Race)
            {
                DataTable dtRaceInfo = ws.GetRaceDetails(latekickCard.RaceDate, latekickCard.Course.CourseCode, int.Parse(race.RaceNumber));
                if (dtRaceInfo.Rows.Count > 0)
                {
                    race.RaceInfo.CourseName = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("course_name")].ToString();
                    race.RaceInfo.RaceTypeLong = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("race_type_long")].ToString();
                    try
                    {
                        race.RaceInfo.ClassRating = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("class_gmr")].ToString());
                    }
                    catch { }
                }
                try
                {
                    race.RaceInfo.MaxEarly = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("maxearly")].ToString());
                }
                catch { }
                try
                {
                    race.RaceInfo.MaxMiddle = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("maxmiddle")].ToString());
                }
                catch { }
                try
                {
                    race.RaceInfo.MaxLate = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("maxlate")].ToString());
                }
                catch { }
                try
                {
                    race.RaceInfo.MaxAverage = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("maxaverage")].ToString());
                }
                catch { }
                try
                {
                    race.RaceInfo.MaxRecent = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("maxrecent")].ToString());
                }
                catch { }
                try
                {
                    race.RaceInfo.MaxPace = double.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("maxpace")].ToString());
                }
                catch { }


                try
                {
                    race.RaceInfo.CD_Profile.Runs_All = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("runs_all")].ToString());
                }
                catch { race.RaceInfo.CD_Profile.Runs_All = 0; }
                try
                {
                    race.RaceInfo.CD_Profile.PaceWins_All = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("pacewins_all")].ToString());
                }
                catch { race.RaceInfo.CD_Profile.PaceWins_All = 0; }
                try
                {
                    race.RaceInfo.CD_Profile.StalkWins_All = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("stalkwins_all")].ToString());
                }
                catch { race.RaceInfo.CD_Profile.StalkWins_All = 0; }
                try
                {
                    race.RaceInfo.CD_Profile.CloseWins_All = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("closewins_all")].ToString());
                }
                catch { race.RaceInfo.CD_Profile.CloseWins_All = 0; }
                try
                {
                    race.RaceInfo.CD_Profile.Runs_Recent = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("runs_recent")].ToString());
                }
                catch { race.RaceInfo.CD_Profile.Runs_Recent = 0; }
                try
                {
                    race.RaceInfo.CD_Profile.PaceWins_Recent = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("pacewins_recent")].ToString());
                }
                catch { race.RaceInfo.CD_Profile.PaceWins_Recent = 0; }
                try
                {
                    race.RaceInfo.CD_Profile.StalkWins_Recent = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("stalkwins_recent")].ToString());
                }
                catch { race.RaceInfo.CD_Profile.StalkWins_Recent = 0; }
                try
                {
                    race.RaceInfo.CD_Profile.CloseWins_Recent = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("closewins_recent")].ToString());
                }
                catch { race.RaceInfo.CD_Profile.CloseWins_Recent = 0; }
            }
        }

        public void UpdateProjectedRatings()
        {
            foreach (Latekick.BOL.Latekick.Race race in latekickCard.Race)
            {
                latekick.com.Latekick2 ws = new Latekick.BLL.latekick.com.Latekick2();
                foreach (Latekick.BOL.Latekick.Entry entry in race.Entry)
                {
                    DataTable dtProjectedRatings = ws.GetProjectedRatings(latekickCard.RaceDate, latekickCard.Course.CourseCode, int.Parse(race.RaceNumber), entry.HorseName);
                    if (dtProjectedRatings.Rows.Count > 0)
                    {
                        race.RaceInfo.CourseName = dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("course_name")].ToString();
                        race.RaceInfo.RaceTypeLong = dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("race_type_long")].ToString();
                        try
                        {
                            race.RaceInfo.ClassRating = int.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("class_gmr")].ToString());
                        }
                        catch { }
                        entry.ML = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("ML")].ToString());
                        entry.LK_Odds = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("LK_Odds")].ToString());

                        entry.RunningStyle.PaceRuns = 0;
                        entry.RunningStyle.PaceWins = 0;
                        entry.RunningStyle.OffPaceRuns = 0;
                        entry.RunningStyle.OffPaceWins = 0;

                        entry.ProjectedRatings.Early = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Early")].ToString());
                        entry.ProjectedRatings.Middle = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Middle")].ToString());
                        entry.ProjectedRatings.Late = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Late")].ToString());
                        entry.ProjectedRatings.Average = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("AverageSpeed")].ToString());
                        entry.ProjectedRatings.Recent = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("RecentSpeed")].ToString());
                        entry.ProjectedRatings.Quirin = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Quirin")].ToString());
                    }
                }
            }
        }

        public void UpdatePastPerformances()
        {
            foreach (Latekick.BOL.Latekick.Race race in latekickCard.Race)
            {
                latekick.com.Latekick2 ws = new Latekick.BLL.latekick.com.Latekick2();
                foreach (Latekick.BOL.Latekick.Entry entry in race.Entry)
                {
                    DataTable dtHistoricalRatings = ws.GetHistoricalRatings(latekickCard.RaceDate, entry.HorseName);
                    for (int h = 0; h < Math.Min(entry.PPs == null ? 0 : entry.PPs.PP.Length, dtHistoricalRatings.Rows.Count); h++)
                    {
                        DateTime SQLracedate = DateTime.Parse(dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("RaceDate")].ToString());
                        if (entry.PPs.PP[h].RaceDate == SQLracedate)
                        {
                            try { entry.PPs.PP[h].PP_Latekick.ClassRating_GMR = int.Parse(dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("CLASS_GMR")].ToString()); }
                            catch { }
                            entry.PPs.PP[h].PP_Latekick.Finish123_GMR = dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("Finish123")].ToString() == null ? "" : dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("Finish123")].ToString();
                            entry.PPs.PP[h].PP_Latekick.RaceType = dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("RaceType")].ToString() == null ? "" : dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("RaceType")].ToString();
                            try { entry.PPs.PP[h].PP_Latekick.Early = double.Parse(dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("FF")].ToString()); }
                            catch { }
                            try { entry.PPs.PP[h].PP_Latekick.Middle = double.Parse(dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("MF")].ToString()); }
                            catch { }
                            try { entry.PPs.PP[h].PP_Latekick.Late = double.Parse(dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("LF")].ToString()); }
                            catch { }
                            try { entry.PPs.PP[h].PP_Latekick.Latekick = double.Parse(dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("GMR_COMPO")].ToString()); }
                            catch { }
                            try { entry.PPs.PP[h].PP_Latekick.LateSpeed = double.Parse(dtHistoricalRatings.Rows[h].ItemArray[dtHistoricalRatings.Columns.IndexOf("LateSpeed")].ToString()); }
                            catch { }
                        }
                        else if (latekickCard.RaceDate > SQLracedate)
                        {
                        }
                    }
                }
            }
        }

        public void UpdateWorkouts()
        {
            foreach (Latekick.BOL.Latekick.Race race in latekickCard.Race)
            {
                latekick.com.Latekick2 ws = new Latekick.BLL.latekick.com.Latekick2();
                foreach (Latekick.BOL.Latekick.Entry entry in race.Entry)
                {
                    DataTable dtWorkouts = ws.GetWorkouts(latekickCard.RaceDate, entry.HorseName);
                    for (int h = 0; h < Math.Min(entry.Workouts.Workout.Length, dtWorkouts.Rows.Count); h++)
                    {
                        int workrating;
                        int.TryParse(dtWorkouts.Rows[h].ItemArray[dtWorkouts.Columns.IndexOf("GMR_Workout")].ToString(), out workrating);
                        entry.Workouts.Workout[h].WorkRating = workrating;
                        entry.Workouts.Workout[h].WorkFromGate = int.Parse(dtWorkouts.Rows[h].ItemArray[dtWorkouts.Columns.IndexOf("Gate")].ToString());
                        entry.Workouts.Workout[h].WorkMates = dtWorkouts.Rows[h].ItemArray[dtWorkouts.Columns.IndexOf("WorkMates")].ToString();
                    }
                }
            }
        }

    }
}
