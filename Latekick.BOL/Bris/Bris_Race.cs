using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Latekick.BOL;
using FileHelpers;

namespace Latekick.BOL.Brisnet
{
    [DelimitedRecord(",")]
    public class Bris_Race
    {
        [FieldQuoted()]
        public string Track;

        [FieldQuoted()]
        [FieldConverter(ConverterKind.Date, "yyyyMMdd")]
        public DateTime RaceDate;

        public int RaceNumber;

        public int DistanceYards;

        [FieldQuoted()]
        public string Surface;

        [FieldQuoted()]
        public string AllWeather;

        [FieldQuoted()]
        public string RaceType;

        [FieldQuoted()]
        public string Restrictions;

        public string Reserved;

        [FieldNullValue(-999)]
        public int Purse;

        [FieldNullValue(-999)]
        public int ClaimingPrice;

        [FieldNullValue(-999.99)]
        public double TrackRecord;

        [FieldQuoted()]
        public string Conditions;

        [FieldQuoted()]
        public string LasixList;

        [FieldQuoted()]
        public string ButeList;

        [FieldQuoted()]
        public string CoupledList;

        [FieldQuoted()]
        public string MutuelList;

        [FieldQuoted()]
        public string SimulcastTrack;

        [FieldNullValue(-999)]
        public int SimulcastRaceNumber;

        [FieldQuoted()]
        public string Reserved2;

        public string Reserved3;

        public string Reserved4;

        public string PostTimes;

        public string Reserved5;

    }
}
