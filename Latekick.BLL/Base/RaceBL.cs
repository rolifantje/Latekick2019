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
    public class RaceBL
    {
        public static BOL.Base.Race CreateObject()
        {
            return new Latekick.BOL.Base.Race();
        }

        public static void CompileObject(XElement xRace, ref BOL.Base.Race race)
        {
            DataTable dtRaceInfo = RaceDAL.GetRaceData(xRace);
            
            race.CourseName = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("CourseName")].ToString();
            try
            {
                race.RaceNumber = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("RaceNumber")].ToString());
            }
            catch{}
            try
            {
                race.Purse = double.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("Purse")].ToString());
            }
            catch
            {
                race.Purse = 0;
            }
            ////try
            ////{
            ////    int Tag = int.Parse(drRace.ItemArray[drRace.Columns.IndexOf("Claim")].ToString());
            ////    if (Tag == 0)
            ////        this.claimingPrice = "";
            ////    else
            ////        this.claimingPrice = String.Format(nfi, "{0:c0}", Tag);
            ////}
            ////catch
            ////{
            ////    this.claimingPrice += "";
            ////}
            race.ClaimingPrice = 0;
            race.Posttime = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("PostTime")].ToString();
            race.Distance = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("DistanceFurlongs")].ToString();
            race.DistanceRounded = Double.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("DistanceFurlongs")].ToString());

            race.AgeLong = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("AgeSexRestrictions")].ToString();
            race.Surface = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("Surface")].ToString();
            race.RaceClass = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("ClassRating")].ToString();
            race.RaceType = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("RaceType")].ToString();
            race.RaceTypeLong = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("RaceTypeLong")].ToString();
            race.ThisYear = race.RaceDate.Year.ToString();
            race.LastYear = race.RaceDate.AddYears(-1).Year.ToString();
            race.RaceDescription = dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("RaceDescription")].ToString();
            race.Betting = "";

            try
            {
                race.MaxEarly = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("MaxEarly")].ToString());
            }
            catch { race.MaxEarly = 999; }
            try
            {
                race.MaxMiddle = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("MaxMiddle")].ToString());
            }
            catch { race.MaxMiddle = 999; }
            try
            {
                race.MaxLate = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("MaxLate")].ToString());
            }
            catch { race.MaxLate = 999; }
            try
            {
                race.MaxAverage = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("MaxAverage")].ToString());
            }
            catch { race.MaxAverage = 999; }
            try
            {
                race.MaxRecent = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("MaxRecent")].ToString());
            }
            catch { race.MaxRecent = 999; }
            try
            {
                race.MaxPace = double.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("MaxPace")].ToString());
            }
            catch { race.MaxPace = 999; }

            race.CD_Profile.Runs_All = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("Runs_All")].ToString());
            race.CD_Profile.PaceWins_All = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("PaceWins_All")].ToString());
            race.CD_Profile.StalkWins_All = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("StalkWins_All")].ToString());
            race.CD_Profile.CloseWins_All = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("CloseWins_All")].ToString());
            race.CD_Profile.Runs_Recent = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("Runs_Recent")].ToString());
            race.CD_Profile.PaceWins_Recent = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("PaceWins_Recent")].ToString());
            race.CD_Profile.StalkWins_Recent = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("StalkWins_Recent")].ToString());
            race.CD_Profile.CloseWins_Recent = int.Parse(dtRaceInfo.Rows[0].ItemArray[dtRaceInfo.Columns.IndexOf("CloseWins_Recent")].ToString());
        }

        public static void LoadEntries(XElement xRace, BOL.Base.Race race)
        {
            try
            {
                DataTable dtRunners = RaceDAL.GetHorseNames(xRace);

                race.NumberOfHorses = dtRunners.Rows.Count;
                race.Entries = new Latekick.BOL.Base.Entry[race.NumberOfHorses];
                race.HorseNames = new string[race.NumberOfHorses];

                List<XElement> xEntries_Unsorted = xRace.Elements("Entry").ToList<XElement>();
                IOrderedEnumerable<XElement> xEntries = xEntries_Unsorted.OrderBy(entry => entry.Element("SaddleClothNo").Value, new CustomComparer());

                for (int i = 0; i < race.NumberOfHorses; i++)
                {

                    Latekick.BOL.Base.Entry entry = EntryBL.CreateObject();
                    EntryBL.CompileObject(xEntries.ElementAt(i), entry);

                    Latekick.BOL.Base.Horse horse = HorseBL.CreateObject();
                    HorseBL.CompileObject(xEntries.ElementAt(i), horse);

                    entry.ThisHorse = horse;

                    EntryBL.LoadProjectedRatings(xEntries.ElementAt(i), entry);
                    EntryBL.LoadStats(xEntries.ElementAt(i), entry);
                    EntryBL.LoadBrisStats(xEntries.ElementAt(i), entry);
                    HorseBL.LoadWorkouts(xEntries.ElementAt(i), entry);
                    HorseBL.LoadPastPerformances(xEntries.ElementAt(i), entry);
                    HorseBL.LoadRunningStyle(xEntries.ElementAt(i), entry);
                    HorseBL.LoadEarnings(xEntries.ElementAt(i), entry);

                    race.Entries[i] = entry;
                    race.HorseNames[i] = entry.ThisHorse.Name;
                }
            }
            catch (Exception e2)
            {

            }
        }

        public class CustomComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                double xNum, yNum;
                bool xIsNum = Double.TryParse(x, out xNum);
                bool yIsNum = Double.TryParse(y, out yNum);

                // compare numbers
                if (xIsNum && yIsNum)
                {
                    return xNum.CompareTo(yNum);
                }

                // compare num to string
                if (xIsNum)
                {
                    return 1;
                }

                // compare num to string
                if (yIsNum)
                {
                    return -1;
                }

                // compare as strings
                return x.CompareTo(y);
            }
        }
    }
}
