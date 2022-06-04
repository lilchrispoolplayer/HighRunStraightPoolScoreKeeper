using System;
using System.Linq;
using System.Windows.Forms;

namespace StraightPoolScoreKeeper
{
    public partial class FrmStraightPoolScoreKeeper : Form
    {
        private StatisticsModel statisticsModel = new StatisticsModel();
        private const int ScoresSeries = 0;
        private const int HandicapsSeries = 1;
        private const int AveragesSeries = 2;

        public FrmStraightPoolScoreKeeper()
        {
            InitializeComponent();

            txtCurrentBest.Text = statisticsModel.GetCurrentBest().ToString();
            txtRecord.Text = statisticsModel.GetRecord().ToString();
            txtAverage.Text = statisticsModel.GetAverage().ToString();
            txtHandicap.Text = statisticsModel.GetHandicap().ToString();
        }

        private void TxtCurrentScoreEnter(object sender, EventArgs e)
        {
            txtCurrentScore.Focus();
            txtCurrentScore.SelectAll();
        }

        private void TxtCurrentScoreKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SaveCurrentScore(Convert.ToInt32(txtCurrentScore.Text));
                txtCurrentScore.SelectAll();
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TxtCurrentScoreTextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentScore.Text))
            {
                txtCurrentScore.Text = "0";
                txtCurrentScore.SelectAll();
            }
        }

        private void TxtCurrentBestKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                statisticsModel.SaveCurrentBest(Convert.ToInt32(txtCurrentBest.Text));
            }
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            SaveCurrentScore(Convert.ToInt32(txtCurrentScore.Text));
            CalculateStatistics(false);

            SaveCurrentScore(0);
        }

        private void MiDeleteClick(object sender, EventArgs e)
        {
            if (dgCurrentScores.SelectedRows.Count == 0)
                return;

            statisticsModel.DeleteCurrentScore(dgCurrentScores.SelectedRows[0].Index);
            CalculateStatistics(true);
        }

        private void SaveCurrentScore(int score)
        {
            statisticsModel.SaveCurrentScore(score);

            txtCurrentBest.Text = statisticsModel.GetCurrentBest().ToString();
            txtRecord.Text = statisticsModel.GetRecord().ToString();

            txtCurrentScore.Text = score.ToString();
            txtCurrentScore.Focus();
            txtCurrentScore.SelectAll();
        }

        private void CalculateStatistics(bool deleting)
        {
            statisticsModel.CalculateStatistics(deleting);

            txtCurrentBest.Text = statisticsModel.GetCurrentBest().ToString();
            txtTotalAttempts.Text = statisticsModel.GetTotalAttempts().ToString();
            txtTotalRacks.Text = string.Format("{0} of {1} ({2:P0})",
                statisticsModel.GetTotalRacks().ToString(),
                statisticsModel.GetTotalPossibleRacks(),
                statisticsModel.GetRacksCompletedPercentage());
            txtTotalBalls.Text = string.Format("{0} of {1} ({2:P0})",
                statisticsModel.GetTotalBalls().ToString(),
                statisticsModel.GetTotalPossibleBalls(),
                statisticsModel.GetBallPocketingPercentage());
            txtAverage.Text = statisticsModel.GetAverage().ToString();

            // Update the Handicap value
            txtHandicap.Text = statisticsModel.GetHandicap().ToString();
            // Update the running chart with the latest data
            chart1.Series[ScoresSeries].Points.DataBindY(statisticsModel.GetCurrentScoresList());
            chart1.Series[HandicapsSeries].Points.DataBindY(statisticsModel.GetCurrentHandicapsList());
            chart1.Series[AveragesSeries].Points.DataBindY(statisticsModel.GetCurrentAveragesList());

            dgCurrentScores.DataSource = statisticsModel.GetCurrentScores().ToList();
            if (dgCurrentScores.Rows.Count > 0)
            {
                dgCurrentScores.FirstDisplayedScrollingRowIndex = dgCurrentScores.Rows.Count - 1;
                dgCurrentScores.Rows[dgCurrentScores.Rows.Count - 1].Selected = true;
            }
            
            dgRackStatistics.DataSource = statisticsModel.GetRackStatistcs().OrderBy(stat => stat.RackNumber).ToList();
        }

        /// <summary>
        /// Used for testing.  Populates the 'Current Score' field with a random number
        /// and simulates clicking the 'Reset' button.
        /// (Button removed from the UI, but can be added back if needed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            int iVal = random.Next(0, 100); // Calculate a value from 0 to 99, inclusive
            int iRandomScore = 0;
            if (iVal < 10)
                iRandomScore = random.Next(29, 43); // 10% chance of scoring 29 to 42
            else if (iVal < 40)
                iRandomScore = random.Next(10, 29); // 30% chance of scoring 10 to 28
            else
                iRandomScore = random.Next(0, 10); // 60% chance of scoring 0 to 9
            txtCurrentScore.Text = iRandomScore.ToString();
            BtnResetClick(sender, e);
        }
    }
}
