using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HighRunStraightPoolScoreKeeper
{
    public class ReportModel
    {
        public string Date { private set; get; }
        public string Scores { private set; get; }
        public int TotalAttempts { private set; get; }
        public int HighRun { private set; get; }
        public int Bpi { private set; get; }
        public string RacksRan { private set; get; }
        public string BallsMade { private set; get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="data"></param>
        public ReportModel(string data)
        {
            string[] pieces = data.Split('|');
            Date = pieces[0];
            Scores = pieces[1];

            List<string> scoresArray = Scores.Split(',').ToList();
            TotalAttempts = scoresArray.Count;
            HighRun = scoresArray.Max(s => Convert.ToInt32(s));
            Bpi = (int)scoresArray.Average(s => Convert.ToInt32(s));

            int totalRacks = 0;
            int totalPossibleRacks = 0;
            scoresArray.ForEach(s => {
                totalRacks += Convert.ToInt32(s) / 14;
                totalPossibleRacks += Convert.ToInt32(s) / 14 + 1;
            });
            RacksRan = string.Format("{0} of {1}", totalRacks, totalPossibleRacks);

            int totalBallsMade = scoresArray.Sum(s => Convert.ToInt32(s));
            int totalPossibleBalls = totalPossibleRacks * 14;
            BallsMade = string.Format("{0} of {1}", totalBallsMade, totalPossibleBalls);
        }
    }
}
