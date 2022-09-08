using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODApiTesting
{
    public class GamerStats
    {
        public double wins { get; set; }
        public double kills { get; set; }
        public double kdRatio { get; set; }
        public double killstreak { get; set; }
        public double level { get; set; }
        public double accuracy { get; set; }
        public double losses { get; set; }
        public double prestige { get; set; }
        public double hits { get; set; }
        public double score { get; set; }
        public double timePlayed { get; set; }
        public double headshots { get; set; }
        public double averageTime { get; set; }
        public double gamesPlayed { get; set; }
        public double assists { get; set; }
        public double misses { get; set; }
        public double xp { get; set; }
        public double scorePerMinute { get; set; }
        public double shots { get; set; }
        public double deaths { get; set; }


        public GamerStats(double winNum)
        {
            wins = winNum;
        }

        public void PrintVals(double winNum)
        {
            Console.WriteLine(wins);
        }
            
    }
        
        
}
