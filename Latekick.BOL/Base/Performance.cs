using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Latekick.BOL.Base
{
    public class Performance
    {
        #region Variables
        Race thisRace;
        int horseCode;

        string saddleCloth, officialPositionText, oddsText, performanceComment, trainerName, jockeyName;
        double? odds, pace, distanceBeaten, lateSpeed;

        int? weight, postPosition, officialPosition, age, early, middle, late, golden, gMR, performanceRating, projRating, officialRating;
        #endregion

        #region Properties
        public Race ThisRace
        {
            get { return thisRace; }
            set { thisRace = value; }
        }
        public int HorseCode
        {
            get { return horseCode; }
            set { horseCode = value; }
        }
        public string TrainerName
        {
            get { return trainerName; }
            set { trainerName = value; }
        }
        public string JockeyName
        {
            get { return jockeyName; }
            set { jockeyName = value; }
        }

        public string PerformanceComment
        {
            get { return performanceComment; }
            set { performanceComment = value; }
        }

        public double? Odds
        {
            get { return odds; }
            set { odds = value; }
        }

        public string OddsText
        {
            get { return oddsText; }
            set { oddsText = value; }
        }

        public string SaddleCloth
        {
            get { return saddleCloth; }
            set { saddleCloth = value; }
        }

        public int? Age
        {
            get { return age; }
            set { age = value; }
        }
        public string OfficialPositionText
        {
            get { return officialPositionText; }
            set { officialPositionText = value; }
        }
        public int? OfficialPosition
        {
            get { return officialPosition; }
            set { officialPosition = value; }
        }

        public int? PostPosition
        {
            get { return postPosition; }
            set { postPosition = value; }
        }

        public int? Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double? Pace
        {
            get { return pace; }
            set { pace = value; }
        }
        public double? DistanceBeaten
        {
            get { return distanceBeaten; }
            set { distanceBeaten = value; }
        }

        public int? Early
        {
            get { return early; }
            set { early = value; }
        }
        public int? Middle
        {
            get { return middle; }
            set { middle = value; }
        }
        public int? Late
        {
            get { return late; }
            set { late = value; }
        }
        public int? PerformanceRating
        {
            get { return performanceRating; }
            set { performanceRating = value; }
        }

        public int? GMR
        {
            get { return gMR; }
            set { gMR = value; }
        }
        public int? ProjRating
        {
            get { return projRating; }
            set { projRating = value; }
        }
        public int? OfficialRating
        {
            get { return officialRating; }
            set { officialRating = value; }
        }
        public double? LateSpeed
        {
            get { return lateSpeed; }
            set { lateSpeed = value; }
        }
        #endregion
    }
}
