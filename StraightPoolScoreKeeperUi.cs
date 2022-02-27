using System;
using System.Linq;
using System.Windows.Forms;

namespace StraightPoolScoreKeeper
{
    public partial class FrmStraightPoolScoreKeeper : Form
    {
        private StatisticsModel statisticsModel = new StatisticsModel();

        public FrmStraightPoolScoreKeeper()
        {
            InitializeComponent();

            txtCurrentBest.Text = statisticsModel.GetCurrentBest().ToString();
            txtRecord.Text = statisticsModel.GetRecord().ToString();
            txtAverage.Text = statisticsModel.GetAverage().ToString();
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
                SaveCurrentScore(txtCurrentScore.Text);
                txtCurrentScore.SelectAll();
            }
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            SaveCurrentScore(txtCurrentScore.Text);
            CalculateStatistics(false);

            SaveCurrentScore("0");
        }

        private void MiDeleteClick(object sender, EventArgs e)
        {
            if (dgCurrentScores.SelectedRows.Count == 0)
                return;

            statisticsModel.DeleteCurrentScore(dgCurrentScores.SelectedRows[0].Index);
            CalculateStatistics(true);
        }

        private void SaveCurrentScore(string score)
        {
            if (!statisticsModel.SaveCurrentScore(score))
            {
                MessageBox.Show("Error saving current score. Not a valid score!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtCurrentBest.Text = statisticsModel.GetCurrentBest().ToString();
            txtRecord.Text = statisticsModel.GetRecord().ToString();

            txtCurrentScore.Text = score;
            txtCurrentScore.Focus();
            txtCurrentScore.SelectAll();
        }

        private void CalculateStatistics(bool deleting)
        {
            statisticsModel.CalculateStatistics(deleting);

            txtTotalAttempts.Text = statisticsModel.GetTotalAttempts().ToString();
            txtTotalRacks.Text = statisticsModel.GetTotalRacks().ToString();
            txtTotalBalls.Text = string.Format("{0} of {1} ({2:P0})", 
                statisticsModel.GetTotalBalls().ToString(),
                statisticsModel.GetTotalPossibleBalls(),
                statisticsModel.GetTotalBalls() / (double)statisticsModel.GetTotalPossibleBalls());
            txtAverage.Text = statisticsModel.GetAverage().ToString();

            dgCurrentScores.DataSource = statisticsModel.GetCurrentScores().ToList();
            dgCurrentScores.FirstDisplayedScrollingRowIndex = dgCurrentScores.Rows.Count - 1;
            dgCurrentScores.Rows[dgCurrentScores.Rows.Count - 1].Selected = true;
            
            dgRackStatistics.DataSource = statisticsModel.GetRackStatistcs().OrderBy(stat => stat.RackNumber).ToList();
        }
    }
}
