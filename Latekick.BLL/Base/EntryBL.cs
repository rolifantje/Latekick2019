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
    public class EntryBL
    {
        public static BOL.Base.Entry CreateObject()
        {
            return new Latekick.BOL.Base.Entry();
        }
        
        public static void CompileObject(XElement xe, Latekick.BOL.Base.Entry entry)
        {
            DataTable dtEntry = EntryDAL.GetEntryInfo(xe);

            entry.SaddleClothNo = dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("SaddleClothNo")].ToString();
            entry.Draw = int.Parse(dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("Draw")].ToString());
            entry.TrainerName = dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("TrainerName")].ToString();
            entry.JockeyName = dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("JockeyName")].ToString();
            entry.OwnerName = dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("OwnerName")].ToString();
            entry.Equip = dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("Equipment")].ToString();
            entry.Medication = dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("Medication")].ToString();
            entry.WeightCarried = int.Parse(dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("Weight")].ToString());
            if (int.Parse(dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("ApprenticeAllowance")].ToString()) == -999)
                entry.ApprenticeAllowance = null;
            else
                entry.ApprenticeAllowance = int.Parse(dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("ApprenticeAllowance")].ToString());
            try
            {
                entry.ML = double.Parse(dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("ML")].ToString());
            }
            catch { }
            entry.TrueOdds = double.Parse(dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("TrueOdds")].ToString());
            try { entry.ThisHorse.EarningsLifeTime = int.Parse(dtEntry.Rows[0].ItemArray[dtEntry.Columns.IndexOf("EarningsLifeTime")].ToString()); }
            catch { }
        }

        public static void LoadProjectedRatings(XElement xe, Latekick.BOL.Base.Entry entry)
        {
            DataTable dtProjectedRatings = EntryDAL.GetProjectedRatings(xe);

            entry.ProjRatings = new Latekick.BOL.Base.Entry.ProjectedRatings();
            entry.ProjRatings.Early = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Early")].ToString());
            entry.ProjRatings.Middle = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Middle")].ToString());
            entry.ProjRatings.Late = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Late")].ToString());
            entry.ProjRatings.Dash = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Dash")].ToString());
            entry.ProjRatings.Golden = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Golden")].ToString());
            entry.ProjRatings.Average = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Average")].ToString());
            entry.ProjRatings.Recent = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Recent")].ToString());
            entry.ProjRatings.Quirin = double.Parse(dtProjectedRatings.Rows[0].ItemArray[dtProjectedRatings.Columns.IndexOf("Quirin")].ToString());
        }
        public static void LoadStats(XElement xe, Latekick.BOL.Base.Entry entry)
        {
            DataTable dtStats = EntryDAL.GetStats(xe);

            entry.Horse_LifeTime_Stats = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Horse_CurrentYear_Stats = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Horse_LastYear_Stats = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Horse_Dirt_Stats = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Horse_AW_Stats = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Horse_Turf_Stats = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Horse_Track_Stats = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Horse_Wet_Stats = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Horse_Distance_Stats = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Trainer_Meet = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Jockey_Meet = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Jockey_30Days = new Latekick.BOL.Base.Entry.WPSStats();
            entry.Trainer_30Days = new Latekick.BOL.Base.Entry.WPSStats();

            try
            {
                entry.Horse_LifeTime_Stats.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("LifeTime_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_LifeTime_Stats.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("LifeTime_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_LifeTime_Stats.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("LifeTime_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_LifeTime_Stats.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("LifeTime_Show")].ToString());
            }
            catch { }

            try
            {
                entry.Horse_CurrentYear_Stats.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("ThisYear_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_CurrentYear_Stats.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("ThisYear_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_CurrentYear_Stats.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("ThisYear_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_CurrentYear_Stats.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("ThisYear_Show")].ToString());
            }
            catch { }

            try
            {
                entry.Horse_LastYear_Stats.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("LastYear_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_LastYear_Stats.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("LastYear_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_LastYear_Stats.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("LastYear_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_LastYear_Stats.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("LastYear_Show")].ToString());
            }
            catch { }

            try
            {
                entry.Horse_Track_Stats.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Course_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Track_Stats.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Course_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Track_Stats.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Course_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Track_Stats.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Course_Show")].ToString());
            }
            catch { }

            try
            {
                entry.Horse_Dirt_Stats.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Dirt_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Dirt_Stats.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Dirt_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Dirt_Stats.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Dirt_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Dirt_Stats.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Dirt_Show")].ToString());
            }
            catch { }

            try
            {
                entry.Horse_Turf_Stats.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Turf_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Turf_Stats.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Turf_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Turf_Stats.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Turf_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Turf_Stats.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Turf_Show")].ToString());
            }
            catch { }

            try
            {
                entry.Horse_AW_Stats.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("AW_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_AW_Stats.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("AW_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_AW_Stats.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("AW_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_AW_Stats.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("AW_Show")].ToString());
            }
            catch { }

            try
            {
                entry.Horse_Wet_Stats.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Wet_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Wet_Stats.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Wet_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Wet_Stats.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Wet_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Wet_Stats.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Wet_Show")].ToString());
            }
            catch { }

            try
            {
                entry.Horse_Distance_Stats.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Distance_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Distance_Stats.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Distance_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Distance_Stats.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Distance_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Horse_Distance_Stats.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Distance_Show")].ToString());
            }
            catch { }
            try
            {
                entry.Jockey_Meet.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Jockey_Runs_Meet")].ToString());
            }
            catch { }
            try
            {
                entry.Jockey_Meet.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Jockey_Win_Meet")].ToString());
            }
            catch { }
            try
            {
                entry.Jockey_Meet.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Jockey_Place_Meet")].ToString());
            }
            catch { }
            try
            {
                entry.Jockey_Meet.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Jockey_Show_Meet")].ToString());
            }
            catch { }
            try
            {
                entry.Trainer_Meet.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Trainer_Runs_Meet")].ToString());
            }
            catch { }
            try
            {
                entry.Trainer_Meet.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Trainer_Win_Meet")].ToString());
            }
            catch { }
            try
            {
                entry.Trainer_Meet.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Trainer_Place_Meet")].ToString());
            }
            catch { }
            try
            {
                entry.Trainer_Meet.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Trainer_Show_Meet")].ToString());
            }
            catch { }
            try
            {
                entry.Trainer_ThisYear = dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Trainer_ThisYear")].ToString();
            }
            catch { }
            try
            {
                entry.Trainer_LastYear = dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Trainer_LastYear")].ToString();
            }
            catch { }
            try
            {
                entry.Trainer_30Days.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Trainer_30d_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Trainer_30Days.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Trainer_30d_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Trainer_30Days.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Trainer_30d_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Trainer_30Days.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Trainer_30d_Show")].ToString());
            }
            catch { }
            try
            {
                entry.Jockey_30Days.Runs = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Jockey_30d_Runs")].ToString());
            }
            catch { }
            try
            {
                entry.Jockey_30Days.Win = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Jockey_30d_Win")].ToString());
            }
            catch { }
            try
            {
                entry.Jockey_30Days.Place = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Jockey_30d_Place")].ToString());
            }
            catch { }
            try
            {
                entry.Jockey_30Days.Show = int.Parse(dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Jockey_30d_Show")].ToString());
            }
            catch { }
            try
            {
                entry.Jockey_ThisYear = dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Jockey_ThisYear")].ToString();
            }
            catch{}
            try
            {
                entry.Jockey_LastYear = dtStats.Rows[0].ItemArray[dtStats.Columns.IndexOf("Jockey_LastYear")].ToString();
            }
            catch { }
        }

        public static void LoadBrisStats(XElement xe, Latekick.BOL.Base.Entry entry)
        {
            DataTable dtBrisStats = EntryDAL.GetBrisStats(xe);
            entry.BrisStats = new Latekick.BOL.Base.Entry.BrisStat[dtBrisStats.Rows.Count];
            for (int b = 0; b < entry.BrisStats.Length; b++)
            {
                entry.BrisStats[b] = new Latekick.BOL.Base.Entry.BrisStat();
                entry.BrisStats[b].Category = dtBrisStats.Rows[b].ItemArray[dtBrisStats.Columns.IndexOf("BrisStatCategory")].ToString();
                try
                {
                    entry.BrisStats[b].Runs = int.Parse(dtBrisStats.Rows[b].ItemArray[dtBrisStats.Columns.IndexOf("Runs")].ToString());
                }
                catch { }
                try
                {
                    entry.BrisStats[b].WinRatio = double.Parse(dtBrisStats.Rows[b].ItemArray[dtBrisStats.Columns.IndexOf("WinPct")].ToString());
                }
                catch { }
                try
                {
                    entry.BrisStats[b].ITM = double.Parse(dtBrisStats.Rows[b].ItemArray[dtBrisStats.Columns.IndexOf("ITM")].ToString());
                }
                catch { }
                try
                {
                    entry.BrisStats[b].ROI = double.Parse(dtBrisStats.Rows[b].ItemArray[dtBrisStats.Columns.IndexOf("ROI")].ToString());
                }
                catch { }
            }
        }
    }
}
