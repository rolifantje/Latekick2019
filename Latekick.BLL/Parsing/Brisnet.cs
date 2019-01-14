using System;
using System.Collections.Generic;
using System.Text;
using Latekick.BOL;
using FileHelpers;

namespace Latekick.BLL.Parsing
{
    public static class Brisnet
    {
        public static List<Latekick.BOL.Brisnet.Bris_Race> ParseRaces(string filename)
        {
            FileHelperEngine<Latekick.BOL.Brisnet.Bris_Race> engine = new FileHelperEngine<Latekick.BOL.Brisnet.Bris_Race>();
            //FileHelperEngine engine = new FileHelperEngine(typeof(Latekick.BOL.Brisnet.Race));
            //Latekick.BOL.Brisnet.Race[] races = (Latekick.BOL.Brisnet.Race[]) engine.ReadFile(filename);
            List<Latekick.BOL.Brisnet.Bris_Race> races = new List<Latekick.BOL.Brisnet.Bris_Race>(engine.ReadFile(filename));
            return races;
        }

        public static List<Latekick.BOL.Brisnet.Bris_Entry> ParseHorses(string filename)
        {
            FileHelperEngine<Latekick.BOL.Brisnet.Bris_Entry> engine = new FileHelperEngine<Latekick.BOL.Brisnet.Bris_Entry>();
            //FileHelperEngine engine = new FileHelperEngine(typeof(Latekick.BOL.Brisnet.Horse));
            //Latekick.BOL.Brisnet.Horse[] horses = (Latekick.BOL.Brisnet.Horse[])engine.ReadFile(filename);
            List<Latekick.BOL.Brisnet.Bris_Entry> horses = new List<Latekick.BOL.Brisnet.Bris_Entry>(engine.ReadFile(filename));
            return horses;
        }

        public static List<Latekick.BOL.Brisnet.Bris_PastPerformance> ParsePPs(string filename)
        {
            FileHelperEngine<Latekick.BOL.Brisnet.Bris_PastPerformance> engine = new FileHelperEngine<Latekick.BOL.Brisnet.Bris_PastPerformance>();
            //Latekick.BOL.Brisnet.PastPerformance[] pastperformances = (Latekick.BOL.Brisnet.PastPerformance[])engine.ReadFile(filename);
            List<Latekick.BOL.Brisnet.Bris_PastPerformance> pastperformances = new List<Latekick.BOL.Brisnet.Bris_PastPerformance>(engine.ReadFile(filename));
            return pastperformances;
        }

        public static List<Latekick.BOL.Brisnet.Bris_Stats> ParseStats(string filename)
        {
            FileHelperEngine<Latekick.BOL.Brisnet.Bris_Stats> engine = new FileHelperEngine<Latekick.BOL.Brisnet.Bris_Stats>();
            List<Latekick.BOL.Brisnet.Bris_Stats> stats = new List<Latekick.BOL.Brisnet.Bris_Stats>(engine.ReadFile(filename));
            return stats;
        }
    }
}
