using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Latekick.BOL.Latekick;
using Latekick.DAL.Trackmaster;

namespace Latekick.BLL.Conversion
{
    public class TrackMaster2Latekick
    {
        public Latekick_Card LK = new Latekick.BOL.Latekick.Latekick_Card();

        public TrackMaster2Latekick()
        {
        }

        public void Convert(XDocument xdTrackmaster)
        {
            ConvertRaces(xdTrackmaster);
            for (int i=0; i<int.Parse(LK.NumberOfRaces); i++)
            {
                ConvertHorses(LK.Race[i], xdTrackmaster.Descendants("racedata").ElementAt(i));
                //IEnumerable<Entry> entries = LK.Race[i].Entry; 
                
                for (int j = 0; j < xdTrackmaster.Descendants("racedata").ElementAt(i).Descendants("horsedata").Count(); j++)
                {
                    IEnumerable<Entry> query = LK.Race[i].Entry.Where(entry => entry.HorseName == xdTrackmaster.Descendants("racedata").ElementAt(i).Descendants("horsedata").ElementAt(j).Element("horse_name").Value);
                    Entry currententry = (Entry)query.ElementAt(0);
                    ConvertWorkouts(currententry, xdTrackmaster.Descendants("racedata").ElementAt(i).Descendants("horsedata").ElementAt(j));
                    ConvertPastPerformances(currententry, xdTrackmaster.Descendants("racedata").ElementAt(i).Descendants("horsedata").ElementAt(j));

                    //currententry.HorseName = "FFS";
                }
            }
        }

        public void ConvertRaces(XDocument xdTrackmaster)
        {
            DataTable dtRaces = DAL.Trackmaster.RaceCardDAL.GetRaces(xdTrackmaster);
            LK.Course = new Course();
            LK.Course.CourseCode = dtRaces.Rows[0].ItemArray[dtRaces.Columns.IndexOf("Track")].ToString().ToUpper();
            LK.RaceDate = DateTime.ParseExact(dtRaces.Rows[0].ItemArray[dtRaces.Columns.IndexOf("RaceDate")].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            LK.Race = new Race[dtRaces.Rows.Count];
            int cnt = 0;

            foreach (DataRow drRace in dtRaces.Rows)
            {
                Latekick.BOL.Latekick.Race latekickrace = new Latekick.BOL.Latekick.Race();
                latekickrace.RaceDate = LK.RaceDate;
                latekickrace.RaceInfo = new RaceInfo();
                latekickrace.RaceInfo.Surface = dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("Surface")].ToString().ToUpper();
                if (dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("DistUnit")].ToString().ToUpper() == "Y")
                {
                    latekickrace.RaceInfo.DistanceFurlongs = Math.Round(Double.Parse(dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("Distance")].ToString()) / 220, 1);
                    latekickrace.RaceInfo.DistanceYards = Double.Parse(dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("Distance")].ToString());
                }
                else if (dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("DistUnit")].ToString().ToUpper() == "F")
                {
                    latekickrace.RaceInfo.DistanceFurlongs = Double.Parse(dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("Distance")].ToString())/100;
                    latekickrace.RaceInfo.DistanceYards = latekickrace.RaceInfo.DistanceFurlongs * 220;

                }
                latekickrace.RaceNumber = dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("RaceNr")].ToString();
                latekickrace.RaceInfo.PostTime = dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("PostTime")].ToString();
                latekickrace.RaceInfo.RaceNumber = Int32.Parse(dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("RaceNr")].ToString());
                latekickrace.RaceInfo.AgeSexRestrictions = dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("AgeRestr")].ToString();
                latekickrace.RaceInfo.RaceDescription = dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("RaceText")].ToString();
                latekickrace.RaceInfo.RaceType = dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("StkOrClm")].ToString();
                latekickrace.RaceInfo.Purse = Int32.Parse(dtRaces.Rows[cnt].ItemArray[dtRaces.Columns.IndexOf("Purse")].ToString());


                latekickrace.RaceInfo.CD_Profile = new CD_Profile();

                LK.Race[cnt] = latekickrace;
                cnt++;
            }
            LK.NumberOfRaces = cnt.ToString();   
        }

        public void ConvertHorses(Latekick.BOL.Latekick.Race race, XElement xeHorses)
        {
            DataTable dtEntries = RaceDAL.GetEntries(xeHorses);

            race.RaceInfo.NumberOfHorses = dtEntries.Rows.Count;
            race.Entry = new Entry[race.RaceInfo.NumberOfHorses];

            int e = 0;
            #region entry + stats
            foreach (DataRow dr in dtEntries.Rows)
            {
                Latekick.BOL.Latekick.Entry entry = new Latekick.BOL.Latekick.Entry();
                entry.HorseName = dr.ItemArray[dtEntries.Columns.IndexOf("HorseName")].ToString();
                try { entry.Draw = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Draw")].ToString()); }
                catch { }
                entry.SaddleClothNo = dr.ItemArray[dtEntries.Columns.IndexOf("SaddleClothNo")].ToString();
                entry.JockeyName = dr.ItemArray[dtEntries.Columns.IndexOf("JockeyName")].ToString();
                entry.TrainerName = dr.ItemArray[dtEntries.Columns.IndexOf("TrainerName")].ToString();
                entry.OwnerName = dr.ItemArray[dtEntries.Columns.IndexOf("OwnerName")].ToString();
                try { entry.Weight = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Weight")].ToString()); }
                catch { }
                //entry.ApprenticeAllowance = -1;
                entry.Equipment = dr.ItemArray[dtEntries.Columns.IndexOf("Equipment")].ToString();
                entry.Medication = dr.ItemArray[dtEntries.Columns.IndexOf("Medication")].ToString();
                entry.Sire = dr.ItemArray[dtEntries.Columns.IndexOf("Sire")].ToString();
                entry.Dam = dr.ItemArray[dtEntries.Columns.IndexOf("Dam")].ToString();
                entry.DamSire = dr.ItemArray[dtEntries.Columns.IndexOf("DamSire")].ToString();
                entry.Gender = dr.ItemArray[dtEntries.Columns.IndexOf("Gender")].ToString();
                //entry.Age = race.RaceDate.Year - (brisentry.YearOfBirth + (brisentry.YearOfBirth > 90 ? 1900 : 2000));
                try { entry.ML = double.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("ML")].ToString()); }
                catch { }
                entry.ProjectedRatings = new ProjectedRatings();
                entry.RunningStyle = new RunningStyle();

                entry.Stats = new Stats();

                try { entry.Stats.LifeTime_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Lifetime_Runs")].ToString()); }
                catch { }
                try { entry.Stats.LifeTime_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Lifetime_Win")].ToString()); }
                catch { }
                try { entry.Stats.LifeTime_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Lifetime_Place")].ToString()); }
                catch { }
                try { entry.Stats.LifeTime_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Lifetime_Show")].ToString()); }
                catch { }

                try { entry.Stats.ThisYear_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_ThisYear_Runs")].ToString()); }
                catch { }
                try { entry.Stats.ThisYear_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_ThisYear_Win")].ToString()); }
                catch { }
                try { entry.Stats.ThisYear_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_ThisYear_Place")].ToString()); }
                catch { }
                try { entry.Stats.ThisYear_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_ThisYear_Show")].ToString()); }
                catch { }

                try { entry.Stats.LastYear_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_LastYear_Runs")].ToString()); }
                catch { }
                try { entry.Stats.LastYear_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_LastYear_Win")].ToString()); }
                catch { }
                try { entry.Stats.LastYear_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_LastYear_Place")].ToString()); }
                catch { }
                try { entry.Stats.LastYear_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_LastYear_Show")].ToString()); }
                catch { }

                try { entry.Stats.Course_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Course_Runs")].ToString()); }
                catch { }
                try { entry.Stats.Course_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Course_Win")].ToString()); }
                catch { }
                try { entry.Stats.Course_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Course_Place")].ToString()); }
                catch { }
                try { entry.Stats.Course_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Course_Show")].ToString()); }
                catch { }

                try { entry.Stats.Dirt_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Dirt_Runs")].ToString()); }
                catch { }
                try { entry.Stats.Dirt_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Dirt_Win")].ToString()); }
                catch { }
                try { entry.Stats.Dirt_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Dirt_Place")].ToString()); }
                catch { }
                try { entry.Stats.Dirt_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Dirt_Show")].ToString()); }
                catch { }

                try { entry.Stats.Turf_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Turf_Runs")].ToString()); }
                catch { }
                try { entry.Stats.Turf_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Turf_Win")].ToString()); }
                catch { }
                try { entry.Stats.Turf_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Turf_Place")].ToString()); }
                catch { }
                try { entry.Stats.Turf_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Turf_Show")].ToString()); }
                catch { }

                try { entry.Stats.AW_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_AW_Runs")].ToString()); }
                catch { }
                try { entry.Stats.AW_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_AW_Win")].ToString()); }
                catch { }
                try { entry.Stats.AW_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_AW_Place")].ToString()); }
                catch { }
                try { entry.Stats.AW_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_AW_Show")].ToString()); }
                catch { }

                try { entry.Stats.Wet_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Mud_Runs")].ToString()) + int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Soft_Runs")].ToString()); }
                catch { }
                try { entry.Stats.Wet_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Mud_Win")].ToString()) + int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Soft_Win")].ToString()); }
                catch { }
                try { entry.Stats.Wet_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Mud_Place")].ToString()) + int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Soft_Place")].ToString()); }
                catch { }
                try { entry.Stats.Wet_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Mud_Show")].ToString()) + int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Soft_Show")].ToString()); }
                catch { }

                try { entry.Stats.Distance_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_DistanceDirt_Runs")].ToString()) + int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_DistanceTurf_Runs")].ToString()); }
                catch { }
                try { entry.Stats.Distance_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_DistanceDirt_Win")].ToString()) + int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_DistanceTurf_Win")].ToString()); }
                catch { }
                try { entry.Stats.Distance_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_DistanceDirt_Place")].ToString()) + int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_DistanceTurf_Place")].ToString()); }
                catch { }
                try { entry.Stats.Distance_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_DistanceDirt_Show")].ToString()) + int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_DistanceTurf_Show")].ToString()); }
                catch { }

                try { entry.Stats.Jockey_30d_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Jockey_30d_Runs")].ToString()); }
                catch { }
                try { entry.Stats.Jockey_30d_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Jockey_30d_Win")].ToString()); }
                catch { }
                try { entry.Stats.Jockey_30d_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Jockey_30d_Place")].ToString()); }
                catch { }
                try { entry.Stats.Jockey_30d_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Jockey_30d_Show")].ToString()); }
                catch { }

                try { entry.Stats.Trainer_30d_Runs = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Trainer_30d_Runs")].ToString()); }
                catch { }
                try { entry.Stats.Trainer_30d_Win = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Trainer_30d_Win")].ToString()); }
                catch { }
                try { entry.Stats.Trainer_30d_Place = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Trainer_30d_Place")].ToString()); }
                catch { }
                try { entry.Stats.Trainer_30d_Show = int.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Trainer_30d_Show")].ToString()); }
                catch { }

                entry.Earnings = new Earnings();
                try { entry.Earnings.EarningsLifeTime = (int)double.Parse(dr.ItemArray[dtEntries.Columns.IndexOf("Stats_Lifetime_Earnings")].ToString()); }
                catch { }

                race.Entry[e] = entry;
                e++;
            }
            #endregion
        }

        public void ConvertWorkouts(Entry entry, XElement xeWorkouts)
        {
            DataTable dtWorkouts = RaceDAL.GetWorkouts(xeWorkouts);
            var lWorkouts = new List<Workout>();
            for (int w = 1; w <= dtWorkouts.Rows.Count; w++)
            {
                Workout liWork = new Workout();
                try
                {
                    liWork.WorkDate = LK.RaceDate.AddDays(-int.Parse(dtWorkouts.Rows[w - 1].ItemArray[dtWorkouts.Columns.IndexOf("DaysBack")].ToString()));
                    liWork.WorkDaysAgo = dtWorkouts.Rows[w - 1].ItemArray[dtWorkouts.Columns.IndexOf("DaysBack")].ToString();
                    string worktext = dtWorkouts.Rows[w - 1].ItemArray[dtWorkouts.Columns.IndexOf("worktext")].ToString();

                    if (worktext.Substring(worktext.Length - 1) == "g")
                    {
                        liWork.WorkFromGate = 1;
                        worktext = worktext.Substring(0, worktext.Length - 2);
                    }
                    if (worktext.Substring(worktext.Length - 1).ToUpper() == "H" || worktext.Substring(worktext.Length - 1).ToUpper() == "B")
                    {
                        liWork.WorkDescription = worktext.Substring(worktext.Length - 1, 1);
                    }
                    else
                    {
                        liWork.WorkDescription = "";
                        worktext = worktext + " ";
                    }
                    liWork.WorkTrack = worktext.Substring(worktext.IndexOf(")") + 1, worktext.IndexOf(":") - worktext.IndexOf(")") - 1); ;
                    liWork.WorkSurface = worktext.Substring(worktext.IndexOf("(") - 1, 1);
                    liWork.WorkDistance = int.Parse(worktext.Substring(0, worktext.IndexOf("(")-1));
                    liWork.WorkGoing = worktext.Substring(worktext.IndexOf("(") + 1, 2); ;

                    liWork.WorkTime = double.Parse(worktext.Substring(worktext.IndexOf(":") +  1, worktext.Length - worktext.IndexOf(":") - 2).Trim());
                    if (liWork.WorkTime >= 100 && liWork.WorkTime < 200)
                        liWork.WorkTime = liWork.WorkTime - 40;
                    if (liWork.WorkTime > 200)
                        liWork.WorkTime = liWork.WorkTime - 80;
                    liWork.WorkRank = int.Parse(dtWorkouts.Rows[w - 1].ItemArray[dtWorkouts.Columns.IndexOf("Ranking")].ToString()) + "/" + dtWorkouts.Rows[w - 1].ItemArray[dtWorkouts.Columns.IndexOf("RankGroup")].ToString();
                    lWorkouts.Add(liWork);
                }
                catch(Exception e2) 
                { 
                }
            }
            Latekick.BOL.Latekick.Workouts workouts = new Latekick.BOL.Latekick.Workouts();
            workouts.Workout = lWorkouts.ToArray();

            if (lWorkouts.Count == 0)
            {
                entry.Workouts = new Workouts();
                entry.Workouts.Workout = new Workout[0] { };
            }
            else
                entry.Workouts = workouts;
        }

        public void ConvertPastPerformances(Entry entry, XElement xePastPerformances)
        {
            try
            {
                DataTable dtPPs = RaceDAL.GetPastPerformances(xePastPerformances);

                PPs pps = new PPs();
                pps.PP = new PP[dtPPs.Rows.Count];

                for (int p = 0; p < dtPPs.Rows.Count; p++)
                {
                    PP pp = new PP();
                    pp.RaceDate = DateTime.ParseExact(dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("RaceDate")].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                    pp.CourseCode = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("TrackCode")].ToString();
                    pp.RaceNumber = int.Parse(dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("RaceNumber")].ToString());
                    pp.Breed = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Breed")].ToString();
                    pp.Country = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Country")].ToString();
                    pp.Going = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Going")].ToString();
                    pp.Surface = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Surface")].ToString();
                    double divider = 100;
                    if (dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Surface")].ToString() == "Y")
                        divider = 220;
                    else if (dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Surface")].ToString() == "M")
                        divider = 201.168;
                    pp.DistanceFurlongs = Math.Abs(Math.Round((1 / divider) * double.Parse(dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Distance")].ToString()), 1));
                    //pp.DistanceYards = pps_thishorse[p].DistanceYards;
                    pp.Purse = int.Parse(dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Purse")].ToString());
                    pp.ClaimPrice = int.Parse(dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("ClaimPrice")].ToString()); ;
                    pp.Odds = double.Parse(dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Odds")].ToString());
                    pp.OfficialFinish = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("OfficialPosition")].ToString();
                    pp.OfficialPositionText = pp.OfficialFinish + "/" + dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("NumberOfRunners")].ToString();
                    pp.DistanceBeaten = double.Parse(dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("DistanceBeaten")].ToString()) / 100;
                    pp.Weight = int.Parse(dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Weight")].ToString());
                    pp.JockeyName = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Jockey")].ToString();
                    pp.TrainerName = "";
                    pp.Medication = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Medication")].ToString();
                    pp.Equipment = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Equipment")].ToString();
                    pp.WinName = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("WinHorse")].ToString();
                    pp.PlaceName = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("PlaceHorse")].ToString();
                    pp.ShowName = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("ShowHorse")].ToString();
                    pp.Finish123 = pp.WinName + ";" + pp.PlaceName + ";" + pp.ShowName;
                    pp.AgeSexRestrictions = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("AgeRestr")].ToString();

                    PP_Trackmaster pp_trackmaster = new PP_Trackmaster();
                    pp_trackmaster.TripComment = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("Comment")].ToString();
                    pp_trackmaster.LongTripComment = dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("LongComment")].ToString();
                    pp_trackmaster.SpeedFig = int.Parse(dtPPs.Rows[p].ItemArray[dtPPs.Columns.IndexOf("SpeedFig")].ToString());
                    pp.PP_Trackmaster = pp_trackmaster;

                    pp.PP_Latekick = new PP_Latekick();
                    pps.PP[p] = pp;
                }
                entry.PPs = pps;
            }
            catch (Exception e3)
            {

            }
        }

        public XmlDocument SaveLatekickXml()
        {
            string retVal = string.Empty;
            TextWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(LK.GetType());
            serializer.Serialize(writer, LK);
            retVal = writer.ToString();

            XmlDocument xd = new XmlDocument();
            xd.InnerXml = retVal;
            return xd;
        }
    }
}
