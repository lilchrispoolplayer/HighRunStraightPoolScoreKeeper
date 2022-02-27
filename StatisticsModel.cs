using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace StraightPoolScoreKeeper
{
    public class StatisticsModel
    {
        // Constants
        private const string CURRENT_SCORE_TXT = "CurrentScore.txt";
        private const string CURRENT_BEST_TXT = "CurrentBest.txt";
        private const string RECORD_TXT = "Record.txt";
        private const string AVERAGE_TXT = "Average.txt";

        // Fields
        private int currentScore;
        private int currentBest;
        private int record;

        private int totalAttempts;
        private int totalRacks;
        private int totalBalls;
        private int totalPossibleBalls;
        private int average;

        private List<ScoreModel> currentScores = new List<ScoreModel>();
        private List<RackStatistics> rackStatistics = new List<RackStatistics>();
        
        /// <summary>
        /// Default constructor 
        /// 
        /// Loads the current record and initializes all fields 
        ///  for the UI
        /// </summary>
        public StatisticsModel()
        {
            CreateFiles();
            LoadField(ref record, RECORD_TXT);
            SaveCurrentScore("0");
            CalculateStatistics(true);
        }

        /// <summary>
        /// Gets the current best score
        /// </summary>
        /// <returns>Current best score</returns>
        public int GetCurrentBest()
        {
            return currentBest;
        }

        /// <summary>
        /// Gets the current record
        /// </summary>
        /// <returns>Current record</returns>
        public int GetRecord()
        {
            return record;
        }

        /// <summary>
        /// Gets the average number of balls pocketed
        /// </summary>
        /// <returns>Average number of balls pocketed</returns>
        public int GetAverage()
        {
            return average;
        }

        /// <summary>
        /// Gets total attempts made
        /// </summary>
        /// <returns>Total attempts made</returns>
        public int GetTotalAttempts()
        {
            return totalAttempts;
        }

        /// <summary>
        /// Gets total racks played
        /// </summary>
        /// <returns>Total racks played</returns>
        public int GetTotalRacks()
        {
            return totalRacks;
        }

        /// <summary>
        /// Gets total balls pocketed
        /// </summary>
        /// <returns>Total balls pocketed</returns>
        public int GetTotalBalls()
        {
            return totalBalls;
        }

        /// <summary>
        /// Gets total possible balls that could have been pocketed
        /// </summary>
        /// <returns>Total possible balls that could have been pocketed</returns>
        public int GetTotalPossibleBalls()
        {
            return totalPossibleBalls;
        }

        /// <summary>
        /// Returns current scores as an array
        /// </summary>
        /// <returns>Array of current scores</returns>
        public List<ScoreModel> GetCurrentScores()
        {
            return currentScores;
        }

        /// <summary>
        /// Returns rack statistics as an array
        /// </summary>
        /// <returns>Array of rack statistics</returns>
        public List<RackStatistics> GetRackStatistcs()
        {
            return rackStatistics;
        }

        /// <summary>
        /// Saves the current score to file
        /// </summary>
        /// <param name="score">Current score to save</param>
        /// <returns>True/False if save is successful</returns>
        public bool SaveCurrentScore(string score)
        {
            if (!int.TryParse(score, out currentScore))
                return false;

            SaveField(currentScore, CURRENT_SCORE_TXT);
            SaveCurrentBest();
            SaveRecord();

            return true;
        }

        /// <summary>
        /// Calculates the statics of all attempts
        /// </summary>
        /// <param name="deleting">Flag if deleting a current score</param>
        public void CalculateStatistics(bool deleting)
        {
            if (!deleting)
            {
                currentScores.Add(new ScoreModel { Score = currentScore });
            }

            CalculateRackStatistics();
            SaveAverage();

            totalBalls = currentScores.Sum(sm => sm.Score);
            totalRacks = 0;
            currentScores.ForEach(sm => {
                totalRacks += sm.Score / 14 + 1;
            });
            totalPossibleBalls = totalRacks * 14;
            totalAttempts = currentScores.Count;
        }

        /// <summary>
        /// Deletes a selected score from the list of scores
        /// </summary>
        /// <param name="scoreIndex">Index location of the score to delete</param>
        public void DeleteCurrentScore(int scoreIndex)
        {
            int score = currentScores[scoreIndex].Score;
            currentScores.RemoveAt(scoreIndex);
        }

        /// <summary>
        /// Saves the current best score to a file
        /// </summary>
        private void SaveCurrentBest()
        {
            if (currentScore < currentBest)
                return;

            currentBest = currentScore;
            SaveField(currentBest, CURRENT_BEST_TXT);
        }

        /// <summary>
        /// Saves the current record to a file
        /// </summary>
        private void SaveRecord()
        {
            if (currentBest < record)
                return;

            record = currentBest;
            SaveField(record, RECORD_TXT);
        }

        /// <summary>
        /// Saves the current average to a file
        /// </summary>
        private void SaveAverage()
        {
            if (currentScores.Count == 0)
            {
                SaveField(0, AVERAGE_TXT);
                return;
            }

            average = currentScores.Sum(sm => sm.Score) / currentScores.Count;
            SaveField(average, AVERAGE_TXT);
        }

        /// <summary>
        /// Calculates the number of times a rack count was reached
        /// </summary>
        private void CalculateRackStatistics()
        {
            rackStatistics.Clear();
            currentScores.ForEach(sm =>
            {
                int rackNumber = sm.Score / 14 + 1;
                IEnumerable<RackStatistics> rackStatistic = rackStatistics.Where(rack => rack.RackNumber == rackNumber);
                if (rackStatistic.Count() == 0)
                {
                    RackStatistics rackStat = new RackStatistics
                    {
                        RackNumber = rackNumber
                    };
                    rackStat.RackCount++;
                    rackStat.AddRackScore(sm.Score);
                    rackStatistics.Add(rackStat);
                } 
                else
                {
                    RackStatistics rackStat = rackStatistic.First();
                    rackStat.RackCount++;
                    rackStat.AddRackScore(sm.Score);
                }
            });
        }

        /// <summary>
        /// Saves a field to a file
        /// </summary>
        /// <param name="field">Field to save</param>
        /// <param name="file">Name of file</param>
        private void SaveField(int field, string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(field);
            }
        }

        /// <summary>
        /// Loads a field from a file
        /// </summary>
        /// <param name="field">Field to receive value from file</param>
        /// <param name="file">File name</param>
        private void LoadField(ref int field, string file)
        {
            if (!File.Exists(file))
                return;

            using (StreamReader reader = new StreamReader(file))
            {
                field = Convert.ToInt32(reader.ReadLine());
            }
        }

        /// <summary>
        /// Creates the files to store statistics
        /// </summary>
        private void CreateFiles()
        {
            CreateFile(AVERAGE_TXT);
            CreateFile(CURRENT_BEST_TXT);
            CreateFile(CURRENT_SCORE_TXT);
            CreateFile(RECORD_TXT);
        }

        private void CreateFile(string file)
        {
            if (!File.Exists(file))
            {
                SaveField(0, file);
            }
        }
    }
}
