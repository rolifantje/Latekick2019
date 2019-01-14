using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Latekick.BOL.Latekick;

namespace Latekick.BLL.Conversion
{
    public class Brisnet2Latekick
    {
        public Latekick_Card LK = new Latekick.BOL.Latekick.Latekick_Card();

        public Brisnet2Latekick()
        {
        }

        public void ConvertRaces(List<Latekick.BOL.Brisnet.Bris_Race> races)
        {
            LK.Course = new Course();
            LK.Course.CourseCode = races[0].Track.Trim();
            LK.RaceDate = races[0].RaceDate;

            LK.Race = new Race[races.Count];
            int cnt = 0;
            for (int r = 0; r < races.Count; r++)
            {
                Latekick.BOL.Brisnet.Bris_Race brisrace = races[r];
                Latekick.BOL.Latekick.Race latekickrace = new Latekick.BOL.Latekick.Race();
                latekickrace.RaceDate = LK.RaceDate;
                latekickrace.RaceInfo = new RaceInfo();
                latekickrace.RaceInfo.Surface = brisrace.Surface.ToUpper();
                latekickrace.RaceInfo.DistanceFurlongs = Math.Round((double)brisrace.DistanceYards / 220, 1);
                latekickrace.RaceInfo.DistanceYards = brisrace.DistanceYards;
                latekickrace.RaceNumber = brisrace.RaceNumber.ToString();
                string pt2 = brisrace.PostTimes.ToString();
                string pt = pt2.Replace("\"", "");
                latekickrace.RaceInfo.PostTime = pt.Substring(pt.IndexOf("("), pt.IndexOf(")") - pt.IndexOf("(") + 1).Replace("(", "").Replace(")", "");
                latekickrace.RaceInfo.RaceNumber = brisrace.RaceNumber;
                latekickrace.RaceInfo.AgeSexRestrictions = ParseAgeSexCode(brisrace.Restrictions);
                latekickrace.RaceInfo.RaceDescription = brisrace.Conditions;
                latekickrace.RaceInfo.RaceType = ParseRaceType(brisrace.RaceType);
                latekickrace.RaceInfo.Purse = brisrace.Purse;


                latekickrace.RaceInfo.CD_Profile = new CD_Profile();
               
                LK.Race[r] = latekickrace;
                cnt++;
            }
            LK.NumberOfRaces = cnt.ToString();
        }
        public void ConvertHorses(List<Latekick.BOL.Brisnet.Bris_Entry> entries)
        {
            foreach (Latekick.BOL.Latekick.Race race in LK.Race)
            {
                var entries_thisrace = from brisentry in entries
                                       where brisentry.RaceNumber == int.Parse(race.RaceNumber)
                                       orderby brisentry.SaddleCloth ascending
                                       select brisentry;
                race.RaceInfo.NumberOfHorses = entries_thisrace.Count();
                race.Entry = new Entry[race.RaceInfo.NumberOfHorses];

                int e = 0;
                foreach (Latekick.BOL.Brisnet.Bris_Entry brisentry in entries_thisrace)
                {
                    Latekick.BOL.Latekick.Entry entry = new Latekick.BOL.Latekick.Entry();
                    if (Enum.IsDefined(typeof(State), brisentry.BreedingLocation))
                        entry.HorseName = brisentry.HorseName;
                    else
                        entry.HorseName = brisentry.HorseName + " (" + brisentry.BreedingLocation + ")" ;
                    entry.Draw = brisentry.Draw;
                    entry.SaddleClothNo = brisentry.SaddleCloth;
                    entry.JockeyName = brisentry.JockeyName;
                    entry.TrainerName = brisentry.TrainerName;
                    entry.OwnerName = brisentry.OwnerName;
                    entry.Weight = brisentry.HorseWeight;
                    entry.ApprenticeAllowance = brisentry.ApprenticeAllowance;
                    entry.Equipment = ParseEquipmentCode(brisentry.EquipmentChange);
                    entry.Medication = ParseMedicationCode(brisentry.Medication1);
                    entry.Sire = brisentry.Sire;
                    entry.Dam = brisentry.Dam;
                    entry.DamSire = brisentry.DamSire;
                    entry.Gender = brisentry.Gender;
                    entry.Age = race.RaceDate.Year - (brisentry.YearOfBirth + (brisentry.YearOfBirth > 90 ? 1900 : 2000));
                    entry.ML = brisentry.ML;
                    entry.ProjectedRatings = new ProjectedRatings();
                    entry.RunningStyle = new RunningStyle();
                    entry.RunningStyle.RunStyle_BRIS = brisentry.RunStyle;

                    entry.Stats = new Stats();
                    entry.Stats.LifeTime_Runs = brisentry.Horse_LifeTime_Starts;
                    entry.Stats.LifeTime_Win = brisentry.Horse_LifeTime_Win;
                    entry.Stats.LifeTime_Place = brisentry.Horse_LifeTime_Place;
                    entry.Stats.LifeTime_Show = brisentry.Horse_LifeTime_Show;

                    entry.Stats.ThisYear_Runs = brisentry.Horse_CurrentYear_Starts;
                    entry.Stats.ThisYear_Win = brisentry.Horse_CurrentYear_Win;
                    entry.Stats.ThisYear_Place = brisentry.Horse_CurrentYear_Place;
                    entry.Stats.ThisYear_Show = brisentry.Horse_CurrentYear_Show;

                    entry.Stats.LastYear_Runs = brisentry.Horse_LastYear_Starts;
                    entry.Stats.LastYear_Win = brisentry.Horse_LastYear_Win;
                    entry.Stats.LastYear_Place = brisentry.Horse_LastYear_Place;
                    entry.Stats.LastYear_Show = brisentry.Horse_LastYear_Show;

                    entry.Stats.Course_Runs = brisentry.Horse_Track_Starts;
                    entry.Stats.Course_Win = brisentry.Horse_Track_Win;
                    entry.Stats.Course_Place = brisentry.Horse_Track_Place;
                    entry.Stats.Course_Show = brisentry.Horse_Track_Show;

                    entry.Stats.Dirt_Runs = 0;
                    entry.Stats.Dirt_Win = 0;
                    entry.Stats.Dirt_Place = 0;
                    entry.Stats.Dirt_Show = 0;

                    entry.Stats.Turf_Runs = brisentry.Horse_Turf_Starts;
                    entry.Stats.Turf_Win = brisentry.Horse_Turf_Win;
                    entry.Stats.Turf_Place = brisentry.Horse_Turf_Place;
                    entry.Stats.Turf_Show = brisentry.Horse_Turf_Show;

                    entry.Stats.AW_Runs = brisentry.Horse_LifeTime_AW_Starts;
                    entry.Stats.AW_Win = brisentry.Horse_LifeTime_AW_Win;
                    entry.Stats.AW_Place = brisentry.Horse_LifeTime_AW_Place;
                    entry.Stats.AW_Show = brisentry.Horse_LifeTime_AW_Show;
                    
                    entry.Stats.Wet_Runs = brisentry.Horse_Wet_Starts;
                    entry.Stats.Wet_Win = brisentry.Horse_Wet_Win;
                    entry.Stats.Wet_Place = brisentry.Horse_Wet_Place;
                    entry.Stats.Wet_Show = brisentry.Horse_Wet_Show;

                    entry.Stats.Distance_Runs = brisentry.Horse_Distance_Starts;
                    entry.Stats.Distance_Win = brisentry.Horse_Distance_Win;
                    entry.Stats.Distance_Place = brisentry.Horse_Distance_Place;
                    entry.Stats.Distance_Show = brisentry.Horse_Distance_Show;

                    entry.Stats.Jockey_LastYear = brisentry.Jockey_LastYear;
                    entry.Stats.Jockey_ThisYear = brisentry.Jockey_ThisYear;
                    entry.Stats.Trainer_LastYear = brisentry.Trainer_LastYear;
                    entry.Stats.Trainer_ThisYear = brisentry.Trainer_ThisYear;

                    entry.Stats.Trainer_Runs_Meet = brisentry.TrainerStarts;
                    entry.Stats.Trainer_Win_Meet = brisentry.TrainerWin;
                    entry.Stats.Trainer_Place_Meet = brisentry.TrainerPlace;
                    entry.Stats.Trainer_Show_Meet = brisentry.TrainerShow;

                    entry.Stats.Jockey_Runs_Meet = brisentry.JockeyStarts;
                    entry.Stats.Jockey_Win_Meet = brisentry.JockeyWin;
                    entry.Stats.Jockey_Place_Meet = brisentry.JockeyPlace;
                    entry.Stats.Jockey_Show_Meet = brisentry.JockeyShow;

                    entry.Earnings = new Earnings();
                    entry.Earnings.EarningsLifeTime = brisentry.Horse_LifeTime_Earnings;

                    
                    var lWorkouts = new List<Workout>();
                    for (int w = 1; w <= 12; w++)
                    {
                        Workout liWork = new Workout();
                        liWork.WorkDate = DateTime.Parse(brisentry.GetType().GetField("WorkDate_" + w).GetValue(brisentry).ToString());

                        if (liWork.WorkDate == new DateTime(1974, 12, 3))
                            break;

                        liWork.WorkTrack = brisentry.GetType().GetField("WorkTrack_" + w).GetValue(brisentry).ToString();
                        liWork.WorkSurface = ParseSurfaceType(brisentry.GetType().GetField("WorkSurface_" + w).GetValue(brisentry).ToString());
                        liWork.WorkDistance = Math.Abs(Math.Round(double.Parse(brisentry.GetType().GetField("WorkDistance_" + w).GetValue(brisentry).ToString()) / 220, 1));
                        liWork.WorkGoing = brisentry.GetType().GetField("WorkGoing_" + w).GetValue(brisentry).ToString().ToUpper();
                        liWork.WorkDescription = brisentry.GetType().GetField("WorkDescription_" + w).GetValue(brisentry).ToString();
                        liWork.WorkTime = Math.Abs(double.Parse(brisentry.GetType().GetField("WorkTime_" + w).GetValue(brisentry).ToString()));
                        liWork.WorkRank = brisentry.GetType().GetField("WorkRank_" + w).GetValue(brisentry).ToString() + "/" + brisentry.GetType().GetField("WorkCount_" + w).GetValue(brisentry).ToString();

                        lWorkouts.Add(liWork);
                    }
                    Latekick.BOL.Latekick.Workouts workouts = new Latekick.BOL.Latekick.Workouts();
                    workouts.Workout = lWorkouts.ToArray();

                    if (lWorkouts.Count == 0)
                    {
                        entry.Workouts = new Workouts();
                        entry.Workouts.Workout = new Workout[0]{};
                    }
                    else
                        entry.Workouts = workouts;
                    
                    race.Entry[e] = entry;
                    e++;
                }
            }
        }
        public void ConvertPastPerformances(List<Latekick.BOL.Brisnet.Bris_PastPerformance> ppsBRIS)
        {
            foreach (Latekick.BOL.Latekick.Race race in LK.Race)
            {
                var draws_thisrace = (from d in ppsBRIS
                                     where d.RaceNumber_This_Day == int.Parse(race.RaceNumber)
                                     orderby d.Draw_This_Day
                                     select d.Draw_This_Day).Distinct();

                race.RaceInfo.NumberOfHorses = draws_thisrace.Count();
                
                foreach(int draw in draws_thisrace)
                {
                    List<Latekick.BOL.Brisnet.Bris_PastPerformance> pps_thishorse = (from p in ppsBRIS
                                       where p.RaceNumber_This_Day == int.Parse(race.RaceNumber)
                                        && p.Draw_This_Day == draw
                                        select p).ToList();
                    
                    PPs pps = new PPs();
                    pps.PP = new PP[pps_thishorse.Count()];

                    for (int p = 0; p < pps_thishorse.Count(); p++)
                    {
                        PP pp = new PP();
                        pp.RaceDate = pps_thishorse[p].RaceDate;
                        pp.CourseCode = pps_thishorse[p].Track;
                        pp.RaceNumber = pps_thishorse[p].RaceNumber;
                        pp.Surface = pps_thishorse[p].Surface.ToUpper();
                        pp.Going = pps_thishorse[p].Going;
                        pp.DistanceFurlongs = Math.Abs(Math.Round((double)pps_thishorse[p].DistanceYards / 220, 1));
                        pp.DistanceYards = pps_thishorse[p].DistanceYards;
                        pp.Purse = pps_thishorse[p].Purse;
                        pp.ClaimPrice = pps_thishorse[p].ClaimingPrice;
                        pp.Odds = Math.Round(pps_thishorse[p].Odds, 1);
                        pp.OfficialFinish = pps_thishorse[p].Pos_Finish;
                        pp.OfficialPositionText = pps_thishorse[p].Pos_Finish + "/" + pps_thishorse[p].FieldSize;
                        pp.Weight = pps_thishorse[p].Weight;
                        pp.JockeyName = pps_thishorse[p].Jockey;
                        pp.TrainerName = pps_thishorse[p].Trainer;
                        pp.Medication = ParseMedicationCode(pps_thishorse[p].Medication);
                        pp.Equipment = pps_thishorse[p].Equipment;
                        pp.WinName = pps_thishorse[p].WinName;
                        pp.PlaceName = pps_thishorse[p].PlaceName;
                        pp.ShowName = pps_thishorse[p].ShowName;
                        pp.Finish123 = pps_thishorse[p].WinName + ";" + pps_thishorse[p].PlaceName + ";" + pps_thishorse[p].ShowName;
                        pp.AgeSexRestrictions = ParseAgeSexCode(pps_thishorse[p].Restrictions);
                        pp.DistanceBeaten = pps_thishorse[p].BL_Finish;
                        PP_Brisnet pp_brisnet = new PP_Brisnet();
                        pp_brisnet.SpeedFig = pps_thishorse[p].SpeedFig_BRIS;
                        pp_brisnet.TripComment = pps_thishorse[p].TripComment;
                        pp.PP_Brisnet = pp_brisnet;
                        pp.PP_Latekick = new PP_Latekick();
                        pps.PP[p] = pp;
                    }

                    var latekickhorse = (from h in race.Entry
                                         where h.Draw == draw
                                         select h).First();
                    latekickhorse.PPs = pps;
                }
            }
        }
        public void ConvertStats(List<Latekick.BOL.Brisnet.Bris_Stats> brisstats)
        {
            foreach (Latekick.BOL.Latekick.Race race in LK.Race)
            {
                var brisstats_thisrace = from brisentry in brisstats
                                       where brisentry.RaceNumber_This_Day == int.Parse(race.RaceNumber)
                                       orderby brisentry.Draw_This_Day ascending
                                       select brisentry;

                int e = 0;

                foreach (Latekick.BOL.Brisnet.Bris_Stats brisstat in brisstats_thisrace)
                {
                    
                    var lBrisStats = new List<BrisStat>();
                    for (int b = 1; b <= 6; b++)
                    {
                        BrisStat liBrisStat = new BrisStat();
                        liBrisStat.BrisStatCategory = brisstat.GetType().GetField("StatCategory_" + b).GetValue(brisstat).ToString();

                        if (liBrisStat.BrisStatCategory == "")
                            break;

                        liBrisStat.Runs = int.Parse(brisstat.GetType().GetField("StatCategory_" + b + "_Starts").GetValue(brisstat).ToString());
                        liBrisStat.WinPct = double.Parse(brisstat.GetType().GetField("StatCategory_" + b + "_WinPct").GetValue(brisstat).ToString());
                        liBrisStat.ITM = double.Parse(brisstat.GetType().GetField("StatCategory_" + b + "_ItmPct").GetValue(brisstat).ToString().ToUpper());
                        liBrisStat.ROI = double.Parse(brisstat.GetType().GetField("StatCategory_" + b + "_ROI").GetValue(brisstat).ToString());

                        lBrisStats.Add(liBrisStat);
                    }
                    Latekick.BOL.Latekick.BrisStats bs = new Latekick.BOL.Latekick.BrisStats();
                    bs.BrisStat = lBrisStats.ToArray();

                    var latekickhorse = (from h in race.Entry
                                         where h.Draw == brisstat.Draw_This_Day
                                         select h).First();

                    latekickhorse.Stats.Dirt_Runs = int.Parse(brisstat.GetType().GetField("FastDirtStarts").GetValue(brisstat).ToString());
                    latekickhorse.Stats.Dirt_Win = int.Parse(brisstat.GetType().GetField("FastDirtWin").GetValue(brisstat).ToString());
                    latekickhorse.Stats.Dirt_Place = int.Parse(brisstat.GetType().GetField("FastDirtPlace").GetValue(brisstat).ToString());
                    latekickhorse.Stats.Course_Show = int.Parse(brisstat.GetType().GetField("FastDirtShow").GetValue(brisstat).ToString());

                    latekickhorse.BrisStats = bs;
                }
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

        private string ParseRaceType(string code)
        {
            switch (code)
            {
                case "N":
                    return "ST";
                case "A":
                    return "AL";
                case "R":
                    return "SA";
                case "T":
                    return "SH";
                case "CO":
                    return "OC";
                case "S":
                    return "MS";
                case "M":
                    return "MC";
                default:
                    return code;
            }
        }
        private string ParseSurfaceType(string code)
        {
            switch (code)
            {
                case "MT":
                    return "D";
                case "IM":
                    return "D";
                case "TT":
                    return "D";
                case "T":
                    return "T";
                case "WC":
                    return "WC";
                case "HC":
                    return "HC";
                case "TN":
                    return "T";
                case "IN":
                    return "T";
                case "TR":
                    return " ";
                default:
                    return " ";
            }
        }
        private string ParseMedicationCode(int code)
        {
            switch (code)
            {
                case 0:
                    return "";
                case 1:
                    return "L";
                case 2:
                    return "B";
                case 3:
                    return "L+B";
                case 4:
                    return "L1";
                case 5:
                    return "L1+B";
                default:
                    return "";
            }
        }
        private string ParseEquipmentCode(int code)
        {
            switch (code)
            {
                case 0:
                    return "No Change";
                case 1:
                    return "Blinkers On";
                case 2:
                    return "Blinkers Off";
                case 9:
                    return "Unavailable";
                default:
                    return "";
            }
        }
        private string ParseAgeSexCode(string code)
        {
            string char1 = code.Substring(0, 1);
            string char2 = code.Substring(1, 1);
            string char3 = code.Substring(2, 1);

            string restrictions = "";

            switch (char1)
            {
                case "A":
                    restrictions = "2 year olds";
                    break;
                case "B":
                    restrictions = "3 year olds";
                    break;
                case "C":
                    restrictions = "4 year olds";
                    break;
                case "D":
                    restrictions = "5 year olds";
                    break;
                case "E":
                    restrictions = "3 & 4 year olds";
                    break;
                case "F":
                    restrictions = "4 & 5 year olds";
                    break;
                case "G":
                    restrictions = "3, 4 & 5 year olds";
                    break;
                case "H":
                    restrictions = "all ages";
                    break;
                default:
                    return "";
            }

            switch (char2)
            {
                case "O":
                    restrictions += " only";
                    break;
                case "U":
                    restrictions += " and up";
                    break;
                default:
                    break;
            }

            switch (char3)
            {
                case "N":
                    break;
                case "M":
                    restrictions += " (Fillies and Mares only)";
                    break;
                case "C":
                    restrictions += " (Colts and/or Geldings only)";
                    break;
                case "F":
                    restrictions += " (Fillies only)";
                    break;
                default:
                    break;
            }

            return restrictions;
        }

        public enum State
        {
            AL, AK, AS, AZ, AR,
            CA, CO, CT,
            DE, DC,
            FM, FL,
            GA, GU,
            HI,
            ID, IL, IN, IA,
            KS, KY,
            LA,
            ME, MH, MD, MA, MI, MN, MS, MO, MT, MP,
            NE, NV, NH, NJ, NM,  NY, NC, ND,
            OH, OK, OR,
            PW, PA, PR,
            RI,
            SC, SD,
            TN, TX,
            UT,
            VT, VI, VA,
            WA, WV, WI, WY
        }
    }
}
