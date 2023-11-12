using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace HighRunStraightPoolScoreKeeper
{
    public class StatisticsModel
    {
        // Fields
        private int currentScore;
        private int currentBest;
        private int record;

        private int totalAttempts;
        private int totalRacks;
        private int totalPossibleRacks;
        private int totalBalls;
        private int totalPossibleBalls;
        private int average;

        private List<ScoreModel> currentScores = new List<ScoreModel>();
        private List<RackStatistics> rackStatistics = new List<RackStatistics>();
        private List<int> averagesList = new List<int>();
        
        /// <summary>
        /// Default constructor 
        /// 
        /// Loads the current record and initializes all fields 
        ///  for the UI
        /// </summary>
        public StatisticsModel()
        {
            CreateFiles();
            LoadField(ref record, Constants.RECORD_TXT);
            SaveCurrentScore(0);
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
        /// Gets the list of all current Averages for this session 
        /// </summary>
        /// <returns>The List of integer average values</returns>
        public List<int> GetCurrentAveragesList()
        {
            return averagesList;
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
        /// Gets total possible racks
        /// </summary>
        /// <returns>Total possible racks</returns>
        public int GetTotalPossibleRacks()
        {
            return totalPossibleRacks;
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
        /// Returns the racks completed percentage
        /// </summary>
        /// <returns>Racks completed percentage</returns>
        public double GetRacksCompletedPercentage()
        {
            if (totalRacks == 0 && totalPossibleRacks == 0)
                return 0;

            return totalRacks / (double)totalPossibleRacks;
        }

        /// <summary>
        /// Returns the percentage of balls pocketed
        /// </summary>
        /// <returns></returns>
        public double GetBallPocketingPercentage()
        {
            if (totalBalls == 0 && totalPossibleBalls == 0)
                return 0;

            return totalBalls / (double)totalPossibleBalls;
        }

        /// <summary>
        /// Saves the current score to file
        /// </summary>
        /// <param name="score">Current score to save</param>
        public void SaveCurrentScore(int  score)
        {
            currentScore = score;

            SaveField(currentScore, Constants.CURRENT_SCORE_TXT);
            SaveCurrentBest(currentScore);
            SaveRecord(currentBest);
        }

        /// <summary>
        /// Calculates the statics of all attempts
        /// </summary>
        /// <param name="deleting">Flag if deleting a current score</param>
        public void CalculateStatistics(bool deleting, bool loading)
        {
            if (!deleting && !loading)
            {
                currentScores.Add(new ScoreModel
                {
                    AttemptNumber = currentScores.Count + 1,
                    Score = currentScore
                });
                SaveScores();
            }

            CalculateRackStatistics();
            if (!deleting && !loading)
            {
                CalculateAndSaveAverage();
            }

            totalBalls = currentScores.Sum(sm => sm.Score);
            totalRacks = 0;
            totalPossibleRacks = 0;
            currentScores.ForEach(sm => {
                totalRacks += sm.Score / 14;
                totalPossibleRacks += sm.Score / 14 + 1;
            });
            totalPossibleBalls = totalPossibleRacks * 14;
            totalAttempts = currentScores.Count;
        }

        /// <summary>
        /// Deletes a selected score from the list of scores
        /// </summary>
        /// <param name="scoreIndex">Index location of the score to delete</param>
        public void DeleteCurrentScore(int scoreIndex)
        {
            currentScores.RemoveAt(scoreIndex);
            averagesList.RemoveAt(scoreIndex);

            if (currentScores.Count == 0)
                currentBest = 0;
            else
            {
                currentBest = currentScores.OrderByDescending(s => s.Score).First().Score;
                SaveCurrentBest(currentBest);
            }

            SaveScores();
            for (int i = scoreIndex; i < currentScores.Count; i++)
            {
                currentScores[i].AttemptNumber = i + 1;
            }
        }

        /// <summary>
        /// Saves the current best score to a file
        /// </summary>
        public void SaveCurrentBest(int score)
        {
            if (score < currentBest)
                return;

            currentBest = score;
            SaveField(currentBest, Constants.CURRENT_BEST_TXT);
        }

        /// <summary>
        /// Saves the current record to a file
        /// </summary>
        public void SaveRecord(int score)
        {
            if (score < record)
                return;

            record = score;
            SaveField(record, Constants.RECORD_TXT);
        }

        /// <summary>
        /// Loads all scores from a file
        /// </summary>
        public void LoadScores()
        {
            if (!File.Exists(Constants.SCORES_TXT))
            {
                return;
            }

            IEnumerable<int> scores = File.ReadAllLines(Constants.SCORES_TXT).Select(s => Convert.ToInt32(s));
            foreach (int score in scores)
            {
                currentScores.Add(new ScoreModel
                {
                    AttemptNumber = currentScores.Count + 1,
                    Score = score
                });
                SaveCurrentBest(score);
                CalculateAndSaveAverage();
            }
        }

        /// <summary>
        /// Clears the statistics model
        /// </summary>
        public void Clear()
        {
            currentScores.Clear();
            averagesList.Clear();
            average = 0;
            currentBest = 0;
            SaveScores();
            CalculateAndSaveAverage();
        }

        /// <summary>
        /// Saves the current average to a file
        /// </summary>
        private void CalculateAndSaveAverage()
        {
            if (currentScores.Count == 0)
            {
                average = 0;
                SaveField(average, Constants.AVERAGE_TXT);
                return;
            }

            average = currentScores.Sum(sm => sm.Score) / currentScores.Count;
            averagesList.Add(average);
            SaveField(average, Constants.AVERAGE_TXT);
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
        /// Saves all scores to a file
        /// </summary>
        private void SaveScores()
        {
            File.WriteAllLines(Constants.SCORES_TXT, currentScores.Select(s => s.Score.ToString()));
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
            CreateFile(Constants.AVERAGE_TXT);
            CreateFile(Constants.CURRENT_BEST_TXT);
            CreateFile(Constants.CURRENT_SCORE_TXT);
            CreateFile(Constants.RECORD_TXT);
        }

        /// <summary>
        /// Creates the file for the appropriate field
        /// </summary>
        /// <param name="file">File name</param>
        private void CreateFile(string file)
        {
            if (!File.Exists(file))
            {
                SaveField(0, file);
            }
        }
    }
}
