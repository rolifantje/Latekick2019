using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Latekick.BOL.Base
{
    abstract public class WPSStats
    {
        #region Variables
        DateTime statDate;
        int horseCode;
        string statCourse;
        string statSurface;
        double statDistance;

        int win = 0;
        int place = 0;
        int show = 0;
        int runs = 0;
        #endregion

        #region Properties
        public int Horsecode
        {
            get { return horseCode; }
            set { horseCode = value; }
        }

        public DateTime StatDate
        {
            get { return statDate; }
            set { statDate = value; }
        }

        public string StatCourse
        {
            get { return statCourse; }
            set { statCourse = value; }
        }

        public string StatSurface
        {
            get { return statSurface; }
            set { statSurface = value; }
        }

        public double StatDistance
        {
            get { return statDistance; }
            set { statDistance = value; }
        }

        public int Win
        {
            get { return win; }
            set { win = value; }
        }
        public int Place
        {
            get { return place; }
            set { place = value; }
        }
        public int Show
        {
            get { return show; }
            set { show = value; }
        }
        public int Runs
        {
            get { return runs; }
            set { runs = value; }
        }
        #endregion

        #region Methods
        public virtual void LoadStats() { }
        #endregion
    }
}
