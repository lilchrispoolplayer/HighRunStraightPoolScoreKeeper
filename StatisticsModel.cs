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
        private int totalPossibleRacks;
        private int totalBalls;
        private int totalPossibleBalls;
        private int average;

        private List<ScoreModel> currentScores = new List<ScoreModel>();
        private List<RackStatistics> rackStatistics = new List<RackStatistics>();
        private List<int> handicapsList = new List<int>();
        private List<int> averagesList = new List<int>();

        // Handicap is Average of Best 10 of the Last 20 scores
        private const int HandicapBest = 10;
        private const int HandicapLast = 20;

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
            SaveCurrentScore(0);
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
        /// Gets the Handicap value (an average number of balls pocketed
        /// from the Best 'x' scores of the most recent 'y' scores)
        /// Returns 0 until 'y' scores have been entered
        /// </summary>
        /// <returns>Handicap value</returns>
        public int GetHandicap()
        {
            return Handicap;
        }

        /// <summary>
        /// Gets the list of all current scores for this session 
        /// </summary>
        /// <returns>The List of integer score values</returns>
        public List<int> GetCurrentScoresList()
        {
            List<int> scoresList = new List<int>();
            foreach (ScoreModel sm in currentScores)
                scoresList.Add(sm.Score);
            return scoresList;
        }

        /// <summary>
        /// Gets the list of all current Handicaps for this session 
        /// </summary>
        /// <returns>The List of integer handicap values</returns>
        public List<int> GetCurrentHandicapsList()
        {
            return handicapsList;
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

            SaveField(currentScore, CURRENT_SCORE_TXT);
            SaveCurrentBest(currentScore);
            SaveRecord(currentBest);
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
            totalPossibleRacks = 0;
            currentScores.ForEach(sm => {
                totalRacks += sm.Score / 14;
                totalPossibleRacks += sm.Score / 14 + 1;
            });
            totalPossibleBalls = totalPossibleRacks * 14;
            totalAttempts = currentScores.Count;
            if (!deleting)
            {
                averagesList.Add(average);
                handicapsList.Add(Handicap);
            }
        }

        /// <summary>
        /// Deletes a selected score from the list of scores
        /// </summary>
        /// <param name="scoreIndex">Index location of the score to delete</param>
        public void DeleteCurrentScore(int scoreIndex)
        {
            int score = currentScores[scoreIndex].Score;
            currentScores.RemoveAt(scoreIndex);
            handicapsList.RemoveAt(scoreIndex);
            averagesList.RemoveAt(scoreIndex);

            if (currentScores.Count == 0)
                currentBest = 0;
            else
            {
                currentBest = currentScores.OrderByDescending(s => s.Score).First().Score;
                SaveCurrentBest(currentBest);
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
            SaveField(currentBest, CURRENT_BEST_TXT);
        }

        /// <summary>
        /// Saves the current record to a file
        /// </summary>
        public void SaveRecord(int score)
        {
            if (score < record)
                return;

            record = score;
            SaveField(record, RECORD_TXT);
        }

        /// <summary>
        /// Saves the current average to a file
        /// </summary>
        private void SaveAverage()
        {
            if (currentScores.Count == 0)
            {
                average = 0;
                SaveField(average, AVERAGE_TXT);
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

        /// <summary>
        /// Return the array of the Last set of scores to potentially factor into the Handicap
        /// or null if there are not yet enough scores
        /// </summary>
        /// <returns>integer array with the set of scores, or null (if not enough scores)</returns>
        private int[] LastHandicapScores()
        {
            int[] Last = null;

            if (currentScores.Count >= HandicapLast)
            {
                Last = new int[HandicapLast];
                int iStart = currentScores.Count - HandicapLast;
                for (int i = 0; i < HandicapLast;i++)
                {
                    Last[i] = currentScores[iStart].Score;
                    iStart++;
                }
            }
            return Last;
        }

        /// <summary>
        /// Given an array of integers, identify and return
        /// the index (position) of the lowest value within the array
        /// (in case of ties, the index of the first entry is returned)
        /// </summary>
        /// <param name="arr">An array with 1 or more integers</param>
        /// <returns>The index (position) where the lowest value was found</returns>
        private int IndexOfLowest(int[] arr)
        {
            int iLow = 0;
            if (arr.Length > 1)
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[iLow])
                    {
                        iLow = i;
                    }
                }
            }
            return iLow;
        }

        /// <summary>
        /// Return the array of the Best set of scores to factor into the Handicap
        /// (taken from within the larger set of potential scores)
        /// or null if there are not yet enough scores
        /// </summary>
        /// <returns>integer array with the set of scores, or null (if not enough scores)</returns>
        private int[] BestHandicapScores()
        {
            int[] Best = null;
            int[] Last = LastHandicapScores();
            if (Last != null)
            {
                Best = new int[HandicapBest];
                // Step 1 - Populate the Best array with the first part of the Last array
                for ( int i = 0; i < HandicapBest; i++)
                {
                    Best[i] = Last[i];
                }

                // Step 2 - for each of the remaining values in the Last array
                //          check if it is larger than the lowest value in the Best array
                //          if so, replace the value in the Best array with the value from the Last array
                for (int iLast = HandicapBest; iLast < HandicapLast; iLast++)
                {
                    int ixLow = IndexOfLowest(Best);
                    if (Last[iLast] > Best[ixLow])
                    {
                        Best[ixLow] = Last[iLast];
                    }
                }
            }
            return Best;
        }

        /// <summary>
        /// Calculate the Handicap value by taking the average of the 
        /// best 'x' scores out of the set of 'y' most recent scores
        /// </summary>
        private int Handicap
        {
            get
            {
                int iHandicap = 0;
                int[] Best = BestHandicapScores();
                if (Best != null)
                {
                    int iTotal = 0;
                    for (int i = 0; i < HandicapBest; i++)
                        iTotal += Best[i];
                    // Calculate the average, rounding down (0 to 4) or up (5 to 9)
                    iHandicap = (iTotal + (HandicapBest / 2)) / HandicapBest;
                }
                return iHandicap;
            }
        }
    }
}
