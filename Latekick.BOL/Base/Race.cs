using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Latekick.DAL.Base;

namespace Latekick.BOL.Base
{
    public class Race
    {
        #region Variables
        private DateTime raceDate;
        private string courseCode;
        private string courseAbbreviation;
        private string courseName;
        private int raceNumber;
        private string distance, going;
        private double distanceRounded;
        private string surface;
        private string surfaceLong;
        private string age;
        private string ageLong;
        private double purse, claimingPrice;
        private string posttime;
        private string raceClass;
        private string raceType;
        private string raceTypeLong;
        private string courseDistanceComment;
        private int ratingLimit;

        private string thisYear;
        private string lastYear;
        private string raceDescription;
        private string betting;
        private int maxEarly;
        private int maxMiddle;
        private int maxLate;
        private int maxAverage;
        private int maxRecent;
        private double maxPace;
        int numberOfHorses;
        Entry[] entries;
        string finish123, finish123_GMR;
        string[] horseNames;
        CourseDistanceProfile cD_Profile = new CourseDistanceProfile();
        #endregion

        #region Properties
        public DateTime RaceDate
        {
            get { return raceDate; }
            set { raceDate = value; }
        }
        public string CourseCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }

        public string CourseAbbreviation
        {
            get { return courseAbbreviation; }
            set { courseAbbreviation = value; }
        }
        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }
        public int RaceNumber
        {
            get { return raceNumber; }
            set { raceNumber = value; }
        }
        public string Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public double DistanceRounded
        {
            get { return distanceRounded; }
            set { distanceRounded = value; }
        }
        public string Surface
        {
            get { return surface; }
            set { surface = value; }
        }
        public string Going
        {
            get { return going; }
            set { going = value; }
        }
        public string SurfaceLong
        {
            get { return surfaceLong; }
            set { surfaceLong = value; }
        }
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        public string AgeLong
        {
            get { return ageLong; }
            set { ageLong = value; }
        }
        public double ClaimingPrice
        {
            get { return claimingPrice; }
            set { claimingPrice = value; }
        }

        public double Purse
        {
            get { return purse; }
            set { purse = value; }
        }
        public string Posttime
        {
            get { return posttime; }
            set { posttime = value; }
        }
        public string RaceClass
        {
            get { return raceClass; }
            set { raceClass = value; }
        }
        public string RaceTypeLong
        {
            get { return raceTypeLong; }
            set { raceTypeLong = value; }
        }
        public string RaceType
        {
            get { return raceType; }
            set { raceType = value; }
        }
        public string CourseDistanceComment
        {
            get { return courseDistanceComment; }
            set { courseDistanceComment = value; }
        }
        public int RatingLimit
        {
            get { return ratingLimit; }
            set { ratingLimit = value; }
        }
        public string ThisYear
        {
            get { return thisYear; }
            set { thisYear = value; }
        }
        public string LastYear
        {
            get { return lastYear; }
            set { lastYear = value; }
        }
        public string RaceDescription
        {
            get { return raceDescription; }
            set { raceDescription = value; }
        }
        public string Betting
        {
            get { return betting; }
            set { betting = value; }
        }
        public int MaxEarly
        {
            get { return maxEarly; }
            set { maxEarly = value; }
        }
        public int MaxMiddle
        {
            get { return maxMiddle; }
            set { maxMiddle = value; }
        }
        public int MaxLate
        {
            get { return maxLate; }
            set { maxLate = value; }
        }
        public int MaxAverage
        {
            get { return maxAverage; }
            set { maxAverage = value; }
        }

        public int MaxRecent
        {
            get { return maxRecent; }
            set { maxRecent = value; }
        }
        public double MaxPace
        {
            get { return maxPace; }
            set { maxPace = value; }
        }

        public int NumberOfHorses
        {
            get { return numberOfHorses; }
            set { numberOfHorses = value; }
        }

        public Entry[] Entries
        {
            get { return entries; }
            set { entries = value; }
        }

        public string[] HorseNames
        {
            get { return horseNames; }
            set { horseNames = value; }
        }

        public string Finish123
        {
            get { return finish123; }
            set { finish123 = value; }
        }

        public string Finish123_GMR
        {
            get { return finish123_GMR; }
            set { finish123_GMR = value; }
        }
        public CourseDistanceProfile CD_Profile
        {
            get { return cD_Profile; }
            set { cD_Profile = value; }
        }
        #endregion

        #region Constructors
        public Race()
        {
        }

        public Race(DateTime racedate, string coursecode, int racenumber)
            : base()
        {
            this.RaceDate = racedate;
            this.CourseCode = coursecode;
            this.RaceNumber = racenumber;

            //LoadRaceInformation();
        }
        #endregion

        public class CourseDistanceProfile
        {
            int runs_All, paceWins_All, stalkWins_All, closeWins_All;
            int runs_Recent, paceWins_Recent, stalkWins_Recent, closeWins_Recent;

            public int Runs_All
            {
                get { return runs_All; }
                set { runs_All = value; }
            }

            public int PaceWins_All
            {
                get { return paceWins_All; }
                set { paceWins_All = value; }
            }

            public int StalkWins_All
            {
                get { return stalkWins_All; }
                set { stalkWins_All = value; }
            }

            public int CloseWins_All
            {
                get { return closeWins_All; }
                set { closeWins_All = value; }
            }
            public int Runs_Recent
            {
                get { return runs_Recent; }
                set { runs_Recent = value; }
            }

            public int PaceWins_Recent
            {
                get { return paceWins_Recent; }
                set { paceWins_Recent = value; }
            }

            public int StalkWins_Recent
            {
                get { return stalkWins_Recent; }
                set { stalkWins_Recent = value; }
            }

            public int CloseWins_Recent
            {
                get { return closeWins_Recent; }
                set { closeWins_Recent = value; }
            }
        }

    }
}
