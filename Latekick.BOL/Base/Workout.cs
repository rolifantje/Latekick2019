using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Latekick.BOL.Base
{
    public class Workout
    {
        DateTime workDate;
        string workCourse, worksSurface, workGoing, workDescription, workRank, workMates, workDaysAgo;
        int gate;
        double workDistance, workTime;
        double? workRating;



        public DateTime WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }

        public string WorkCourse
        {
            get { return workCourse; }
            set { workCourse = value; }
        }

        public string WorksSurface
        {
            get { return worksSurface; }
            set { worksSurface = value; }
        }

        public string WorkGoing
        {
            get { return workGoing; }
            set { workGoing = value; }
        }

        public string WorkDescription
        {
            get { return workDescription; }
            set { workDescription = value; }
        }

        public int Gate
        {
            get { return gate; }
            set { gate = value; }
        }

        public string WorkRank
        {
            get { return workRank; }
            set { workRank = value; }
        }

        public double WorkDistance
        {
            get { return workDistance; }
            set { workDistance = value; }
        }

        public double WorkTime
        {
            get { return workTime; }
            set { workTime = value; }
        }

        public double? WorkRating
        {
            get { return workRating; }
            set { workRating = value; }
        }
        public string WorkMates
        {
            get { return workMates; }
            set { workMates = value; }
        }
        public string WorkDaysAgo
        {
            get { return workDaysAgo; }
            set { workDaysAgo = value; }
        }
    }
}