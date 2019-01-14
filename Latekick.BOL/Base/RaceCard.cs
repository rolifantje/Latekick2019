using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using Latekick.DAL.Base;

namespace Latekick.BOL.Base
{
    public class RaceCard
    {
        #region Variables

        Race[] races;
        DateTime raceDate;
        string courseCode;
        string courseName;
        int numberOfRaces;

        #endregion

        #region Properties
        public Race[] Races
        {
            get { return races; }
            set { races = value; }
        }
        public string CourseCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }
        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }
        public DateTime RaceDate
        {
            get { return raceDate; }
            set { raceDate = value; }
        }

        public int NumberOfRaces
        {
            get { return numberOfRaces; }
            set { numberOfRaces = value; }
        }
        #endregion

        #region Contructors
        public RaceCard()
        {
        }

        public RaceCard(DateTime carddate, string coursecode)
        {
            this.RaceDate = carddate;
            this.CourseCode = coursecode;

            //LoadRaces(xd);
        }
        #endregion

        #region Methods

        #endregion
    }
}
