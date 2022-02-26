using System.Collections.Generic;

namespace StraightPoolScoreKeeper
{
    public class RackStatistics
    {
        public int RackNumber { get; set; }
        public int RackCount { get; set; }
        private List<int> rackScores;

        public RackStatistics()
        {
            rackScores = new List<int>();
        }

        public string RackScores
        {
            get
            {
                return string.Join(", ", rackScores);
            }
        }

        public void AddRackScore(int score)
        {
            rackScores.Add(score);
        }
    }
}
