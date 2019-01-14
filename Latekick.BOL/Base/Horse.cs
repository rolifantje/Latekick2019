using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Latekick.DAL.Base;

namespace Latekick.BOL.Base
{
    public class Horse
    {
        #region Variables
        int horseCode;

        string sire;
        string dam;
        string damSire;
        string gender;
        string name;

        int? age = null;
        int earningsLifeTime;

        Performance[] pastPerformances;
        Workout[] workouts;
        RunningStyle runStyle;

        #endregion Variables

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int HorseCode
        {
            get { return horseCode; }
            set { horseCode = value; }
        }

        public int? Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Sire
        {
            get { return sire; }
            set { sire = value; }
        }
        public string Dam
        {
            get { return dam; }
            set { dam = value; }
        }
        public string DamSire
        {
            get { return damSire; }
            set { damSire = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public int EarningsLifeTime
        {
            get { return earningsLifeTime; }
            set { earningsLifeTime = value; }
        }

        public Performance[] PastPerformances
        {
            get { return pastPerformances; }
            set { pastPerformances = value; }
        }
        public Workout[] Workouts
        {
            get { return workouts; }
            set { workouts = value; }
        }
        public RunningStyle RunStyle
        {
            get { return runStyle; }
            set { runStyle = value; }
        }

        #endregion Properties

        #region Constructors
        public Horse()
        { }
        public Horse(int horsecode)
        {
            this.HorseCode = horsecode;
        }
        #endregion

        public class HorseComment
        {
            #region Variables
            DateTime commentDate;
            string comment;
            string source;
            string commentType;
            #endregion

            #region Properties
            public DateTime CommentDate
            {
                get { return commentDate; }
                set { commentDate = value; }
            }
            public string Comment
            {
                get { return comment; }
                set { comment = value; }
            }
            public string Source
            {
                get { return source; }
                set { source = value; }
            }
            public string CommentType
            {
                get { return commentType; }
                set { commentType = value; }
            }
            #endregion
        }

        public class WorkOut
        {
            #region Variables
            DateTime workDate;

            string comment, workmates, distance, source, gallop, daysAgo;

            #endregion

            #region Properties
            public DateTime WorkDate
            {
                get { return workDate; }
                set { workDate = value; }
            }
            public string Gallop
            {
                get { return gallop; }
                set { gallop = value; }
            }

            public string Source
            {
                get { return source; }
                set { source = value; }
            }

            public string Distance
            {
                get { return distance; }
                set { distance = value; }
            }

            public string Workmates
            {
                get { return workmates; }
                set { workmates = value; }
            }

            public string Comment
            {
                get { return comment; }
                set { comment = value; }
            }
            public string DaysAgo
            {
                get { return daysAgo; }
                set { daysAgo = value; }
            }

            #endregion
        }

        public class RunningStyle
        {

            string runStyle_BRIS;
            int? paceRuns, paceWins, offPaceRuns, offPaceWins;

            public int? OffPaceWins
            {
                get { return offPaceWins; }
                set { offPaceWins = value; }
            }

            public int? OffPaceRuns
            {
                get { return offPaceRuns; }
                set { offPaceRuns = value; }
            }

            public int? PaceWins
            {
                get { return paceWins; }
                set { paceWins = value; }
            }

            public int? PaceRuns
            {
                get { return paceRuns; }
                set { paceRuns = value; }
            }
            public string RunStyle_BRIS
            {
                get { return runStyle_BRIS; }
                set { runStyle_BRIS = value; }
            }
        }
    }
}
