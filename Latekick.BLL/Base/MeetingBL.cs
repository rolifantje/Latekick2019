using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Latekick.BLL.Base
{
    public class MeetingBL
    {
        public static DataTable GetMeetings(DateTime dRaceDate)
        {
            return Latekick.DAL.Base.MeetingDAL.GetMeetings(dRaceDate);
        }

        public static DataTable GetLatekickableMeetings(DateTime dRaceDate, string LatekickRoot)
        {
            return Latekick_DAL.FileSystem.MeetingDAL.GetLatekickableMeetings(dRaceDate, LatekickRoot);
        }

        public static DataTable GetLatekickedMeetings(DateTime dRaceDate, string LatekickRoot)
        {
            return Latekick_DAL.FileSystem.MeetingDAL.GetLatekickedMeetings(dRaceDate, LatekickRoot);
        }

        public static DataTable GetBrisMeetings(DateTime dRaceDate, string BrisRoot)
        {
            return Latekick_DAL.FileSystem.MeetingDAL.GetBRISMeetings(dRaceDate, BrisRoot);
        }

        public static DataTable GetTrackmasterMeetings(DateTime dRaceDate, string TrackmasterRoot)
        {
            return Latekick_DAL.FileSystem.MeetingDAL.GetTrackmasterMeetings(dRaceDate, TrackmasterRoot);
        }
    }
}
