using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace StraightPoolScoreKeeper
{
    public partial class FrmStraightPoolScoreKeeper : Form
    {
        private StatisticsModel statisticsModel = new StatisticsModel();
        private const int SCORE_SERIES = 0;
        private const int AVERAGE_SERIES = 1;

        public FrmStraightPoolScoreKeeper()
        {
            InitializeComponent();
        }

        private void FrmStraightPoolScoreKeeperLoad(object sender, EventArgs e)
        {
            statisticsModel.LoadScores();
            if (statisticsModel.GetCurrentScores().Count > 0)
            {
                CalculateStatistics(false, true);

                dgCurrentScores.FirstDisplayedScrollingRowIndex = dgCurrentScores.Rows.Count - 1;
                dgCurrentScores.Rows[dgCurrentScores.Rows.Count - 1].Selected = true;
            }

            txtCurrentBest.Text = statisticsModel.GetCurrentBest().ToString();
            txtRecord.Text = statisticsModel.GetRecord().ToString();
            txtAverage.Text = statisticsModel.GetAverage().ToString();

            dgRackStatistics.DefaultCellStyle.SelectionBackColor = dgRackStatistics.DefaultCellStyle.BackColor;
            dgRackStatistics.DefaultCellStyle.SelectionForeColor = dgRackStatistics.DefaultCellStyle.ForeColor;
        }

        private void TxtCurrentScoreEnter(object sender, EventArgs e)
        {
            txtCurrentScore.Focus();
            txtCurrentScore.SelectAll();

            ControlMouseEnter(sender, e);
        }

        private void TxtCurrentScoreKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SaveCurrentScore(Convert.ToInt32(txtCurrentScore.Text));
                txtCurrentScore.SelectAll();
                return;
            }
            else if (e.KeyChar == (char)Keys.E || e.KeyChar == 'e')
            {
                btnEndInning.PerformClick();
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
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

        private void BtnEndInningClick(object sender, EventArgs e)
        {
            SaveCurrentScore(Convert.ToInt32(txtCurrentScore.Text));
            CalculateStatistics(false, false);

            SaveCurrentScore(0);
        }

        private void DgCurrentScoresMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgCurrentScores.HitTest(e.X, e.Y);
                dgCurrentScores.ClearSelection();
                dgCurrentScores.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void MiDeleteClick(object sender, EventArgs e)
        {
            if (dgCurrentScores.SelectedRows.Count == 0)
                return;

            statisticsModel.DeleteCurrentScore(dgCurrentScores.SelectedRows[0].Index);
            CalculateStatistics(true, false);
        }

        private void BtnClearClick(object sender, EventArgs e)
        {
            using (new CenterWinDialog(this))
            {
                if (MessageBox.Show(this, "Are you sure you want to clear scores?", "Question",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                statisticsModel.Clear();
                CalculateStatistics(true, false);
                SaveCurrentScore(0);
            }
        }

        private void ControlMouseEnter(object sender, EventArgs e)
        {
            Control currentControl = ((Control)sender);
            Point p = ((Control)sender).PointToClient(Cursor.Position);
            p.X += 30;
            p.Y -= 20;
            
            toolTip1.Show(toolTip1.GetToolTip(currentControl), currentControl, p);
        }

        private void ControlMouseLeave(object sender, EventArgs e)
        {
            if (sender is TextBox currentTextBox)
            {
                toolTip1.Hide(currentTextBox);
            }
            else if (sender is Button currentButton)
            {
                toolTip1.Hide(currentButton);
            }
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

        private void CalculateStatistics(bool deleting, bool loading)
        {
            statisticsModel.CalculateStatistics(deleting, loading);

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

            dgCurrentScores.DataSource = statisticsModel.GetCurrentScores().ToList();
            if (dgCurrentScores.Rows.Count > 0)
            {
                dgCurrentScores.FirstDisplayedScrollingRowIndex = dgCurrentScores.Rows.Count - 1;
                dgCurrentScores.Rows[dgCurrentScores.Rows.Count - 1].Selected = true;
            }
            
            dgRackStatistics.DataSource = statisticsModel.GetRackStatistcs().OrderBy(stat => stat.RackNumber).ToList();

            UpdateLineChart();
        }

        private void UpdateLineChart()
        {
            if (statisticsModel.GetCurrentScores().Count == 0)
            {
                chtAveragesScores.Series[SCORE_SERIES].Points.Clear();
                chtAveragesScores.Series[AVERAGE_SERIES].Points.Clear();
                return;
            }

            var scores = statisticsModel.GetCurrentScores().Select(s => s.Score).ToList();
            scores.Insert(0, 0);
            chtAveragesScores.Series[SCORE_SERIES].Points.DataBindXY(Enumerable.Range(0, scores.Count).ToList(), scores);
            
            var averages = statisticsModel.GetCurrentAveragesList().ToList();
            averages.Insert(0, 0);
            chtAveragesScores.Series[AVERAGE_SERIES].Points.DataBindXY(Enumerable.Range(0, averages.Count).ToList(), averages);
        }
    }
}
