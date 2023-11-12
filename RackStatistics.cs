using System.Collections.Generic;

namespace HighRunStraightPoolScoreKeeper
{
    public class RackStatistics
    {
        public int RackNumber { get; set; }
        public int RackCount { get; set; }
        private List<int> rackScores;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RackStatistics()
        {
            rackScores = new List<int>();
        }

        /// <summary>
        /// Gets the rack scores
        /// </summary>
        public string RackScores
        {
            get
            {
                return string.Join(", ", rackScores);
            }
        }

        /// <summary>
        /// Adds a rack score to a list
        /// </summary>
        /// <param name="score">Rack score</param>
        public void AddRackScore(int score)
        {
            rackScores.Add(score);
        }
    }
}
