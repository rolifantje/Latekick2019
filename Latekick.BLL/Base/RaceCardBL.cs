using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Latekick.DAL.Base;

namespace Latekick.BLL.Base
{
    public class RaceCardBL
    {
        public static BOL.Base.RaceCard CreateObject()
        {
            return new Latekick.BOL.Base.RaceCard();
        }        
 
        public static void CompileObject(XDocument xd, ref Latekick.BOL.Base.RaceCard racecard)
        {
            DataTable dtRaces = RaceCardDAL.GetRaces(xd);
            int numberOfRaces = dtRaces.Rows.Count;
            racecard.Races = new Latekick.BOL.Base.Race[numberOfRaces];
            racecard.NumberOfRaces = numberOfRaces;

            for (int i = 0; i < numberOfRaces; i++)
            {
                XElement xRace = xd.Descendants("Race").ElementAt(i);
                Latekick.BOL.Base.Race race = new Latekick.BOL.Base.Race();
                race.RaceDate = racecard.RaceDate;
                race.CourseCode = racecard.CourseCode;

                RaceBL.CompileObject(xRace, ref race);
                RaceBL.LoadEntries(xRace, race);

                //Race race2 = new Race(CardDate, CourseCode, int.Parse(dtRaces.Rows[i].ItemArray[dtRaces.Columns.IndexOf("RaceNumber")].ToString()));
                racecard.Races[i] = race;
            }
        }
    }
}
