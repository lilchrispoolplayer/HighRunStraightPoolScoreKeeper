using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HighRunStraightPoolScoreKeeper
{
    public partial class FrmStraightPoolScoreKeeper : Form
    {
        private StatisticsModel statisticsModel = new StatisticsModel();
        private Point? previousMousePosition = null;
        private ToolTip tooltip = new ToolTip();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FrmStraightPoolScoreKeeper()
        {
            InitializeComponent();

            if (!File.Exists(Constants.SAVED_SCORES_CSV))
            {
                File.Create(Constants.SAVED_SCORES_CSV).Close();
            }
        }

        /// <summary>
        /// Loads the last known current scores and settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStraightPoolScoreKeeperShown(object sender, EventArgs e)
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

            LoadSettingsIni();
        }

        /// <summary>
        /// Saves the settings of the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStraightPoolScoreKeeperFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettingsIni();
        }

        /// <summary>
        /// Saved the current session of scores for a report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDailyReportToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (statisticsModel.GetCurrentScores().Count == 0)
            {
                using (new CenterWinDialog(this))
                {
                    MessageBox.Show("There are no scores to save for today!", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            DialogResult dr = DialogResult.Yes;
            IEnumerable<string> savedScoreLines = File.ReadLines(Constants.SAVED_SCORES_CSV);
            string currentScores = string.Format("{0}|{1}", DateTime.Now.ToShortDateString(), String.Join(",", statisticsModel.GetCurrentScores().Select(s => s.Score)));
            if (savedScoreLines.Count() > 0)
            {
                string lastLine = savedScoreLines.Last();
                if (lastLine.Substring(0, lastLine.IndexOf("|")) == currentScores.Substring(0, lastLine.IndexOf("|")))
                {
                    using (new CenterWinDialog(this))
                    {
                        dr = MessageBox.Show("You've already saved scores today.  Save Again?", "Question",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    }
                }
            }
            
            if (dr == DialogResult.Yes)
            {
                using (StreamWriter sw = new StreamWriter(Constants.SAVED_SCORES_CSV, true))
                {
                    sw.WriteLine(currentScores);
                }
            }

            using (new CenterWinDialog(this))
            {
                MessageBox.Show("Today's scores have been saved!  Clearing everything for the next session!", "Information", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            statisticsModel.Clear();
            CalculateStatistics(true, false);
            SaveCurrentScore(0);
        }

        /// <summary>
        /// Views all saved scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewReportToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (new CenterWinDialog(this))
            {
                HighRunStraightPoolReport report = new HighRunStraightPoolReport();
                report.ShowDialog();
            }
        }

        /// <summary>
        /// Selects all of the text in the current score text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtCurrentScoreEnter(object sender, EventArgs e)
        {
            txtCurrentScore.Focus();
            txtCurrentScore.SelectAll();

            ControlMouseEnter(sender, e);
        }

        /// <summary>
        /// Reacts to key presses for the current score text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Automatically sets the current score textbox to zero if blank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtCurrentScoreTextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentScore.Text))
            {
                txtCurrentScore.Text = "0";
                txtCurrentScore.SelectAll();
            }
        }

        /// <summary>
        /// Adds 14 to the current score
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlus14_Click(object sender, EventArgs e)
        {
            int currentScore = Convert.ToInt32(txtCurrentScore.Text);
            currentScore += 14;
            txtCurrentScore.Text = currentScore.ToString();

            SaveCurrentScore(Convert.ToInt32(txtCurrentScore.Text));
            txtCurrentScore.SelectAll();
        }

        /// <summary>
        /// Ends the current inning by saving the score and calculating statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEndInningClick(object sender, EventArgs e)
        {
            SaveCurrentScore(Convert.ToInt32(txtCurrentScore.Text));
            CalculateStatistics(false, false);

            SaveCurrentScore(0);
        }

        /// <summary>
        /// Displays the moused over data point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChtAveragesScoresMouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (previousMousePosition.HasValue && pos == previousMousePosition.Value)
                return;

            tooltip.RemoveAll();
            previousMousePosition = pos;
            var results = chtAveragesScores.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint &&
                    (result.Series == chtAveragesScores.Series[Constants.SCORE_SERIES] ||
                     result.Series == chtAveragesScores.Series[Constants.AVERAGE_SERIES]))
                {
                    string toolTipMessage = string.Format("{0}: {1}", result.Series.Name, result.Series.Points[result.PointIndex].YValues[0]);
                    tooltip.Show(toolTipMessage, chtAveragesScores, pos.X, pos.Y - 15);
                }
            }
        }

        /// <summary>
        /// Highlights the selected score row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgCurrentScoresMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgCurrentScores.HitTest(e.X, e.Y);
                dgCurrentScores.ClearSelection();
                dgCurrentScores.Rows[hti.RowIndex].Selected = true;
            }
        }

        /// <summary>
        /// Deletes the highlighted score row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiDeleteClick(object sender, EventArgs e)
        {
            if (dgCurrentScores.SelectedRows.Count == 0)
                return;

            statisticsModel.DeleteCurrentScore(dgCurrentScores.SelectedRows[0].Index);
            CalculateStatistics(true, false);
        }

        /// <summary>
        /// Clears all scores and statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Shows the tool tip of the mouse entered control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlMouseEnter(object sender, EventArgs e)
        {
            Control currentControl = ((Control)sender);
            Point p = ((Control)sender).PointToClient(MousePosition);
            p.X += 30;
            p.Y -= 20;
            
            toolTip1.Show(toolTip1.GetToolTip(currentControl), currentControl, p);
        }

        /// <summary>
        /// Hides the tool tip of the mouse leaved control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Saves the current score and calculates statistics
        /// </summary>
        /// <param name="score"></param>
        private void SaveCurrentScore(int score)
        {
            statisticsModel.SaveCurrentScore(score);

            txtCurrentBest.Text = statisticsModel.GetCurrentBest().ToString();
            txtRecord.Text = statisticsModel.GetRecord().ToString();

            txtCurrentScore.Text = score.ToString();
            txtCurrentScore.Focus();
            txtCurrentScore.SelectAll();
        }

        /// <summary>
        /// Calculates the statistics of the scores
        /// </summary>
        /// <param name="deleting"></param>
        /// <param name="loading"></param>
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

        /// <summary>
        /// Updates the line charts based on the scores
        /// </summary>
        private void UpdateLineChart()
        {
            if (statisticsModel.GetCurrentScores().Count == 0)
            {
                chtAveragesScores.Series[Constants.SCORE_LINE_SERIES].Points.Clear();
                chtAveragesScores.Series[Constants.SCORE_SERIES].Points.Clear();
                chtAveragesScores.Series[Constants.AVERAGE_LINE_SERIES].Points.Clear();
                chtAveragesScores.Series[Constants.AVERAGE_SERIES].Points.Clear();
                return;
            }

            var scores = statisticsModel.GetCurrentScores().Select(s => s.Score).ToList();
            scores.Insert(0, 0);
            chtAveragesScores.Series[Constants.SCORE_LINE_SERIES].Points.DataBindXY(Enumerable.Range(0, scores.Count).ToList(), scores);
            chtAveragesScores.Series[Constants.SCORE_SERIES].Points.DataBindXY(Enumerable.Range(0, scores.Count).ToList(), scores);

            var averages = statisticsModel.GetCurrentAveragesList().ToList();
            averages.Insert(0, 0);
            chtAveragesScores.Series[Constants.AVERAGE_LINE_SERIES].Points.DataBindXY(Enumerable.Range(0, averages.Count).ToList(), averages);
            chtAveragesScores.Series[Constants.AVERAGE_SERIES].Points.DataBindXY(Enumerable.Range(0, averages.Count).ToList(), averages);
        }

        /// <summary>
        /// Saves the settings of the UI
        /// </summary>
        private void SaveSettingsIni()
        {
            using (StreamWriter sw = new StreamWriter(Constants.SETTINGS_INI))
            {
                sw.WriteLine("TopMost={0}", this.TopMost);
                sw.WriteLine("Width={0}", this.Width);
                sw.WriteLine("Height={0}", this.Height);
            }
        }

        /// <summary>
        /// Loads the settings of the UI
        /// </summary>
        private void LoadSettingsIni()
        {
            using (StreamReader sr = new StreamReader(Constants.SETTINGS_INI))
            {
                while(sr.Peek() != -1)
                {
                    string line = sr.ReadLine();
                    string[] pieces = line.Split('=');
                    switch(pieces[0])
                    {
                        case Constants.TOP_MOST:
                            this.TopMost = Convert.ToBoolean(pieces[1]);
                            break;
                        case Constants.WIDTH:
                            this.Width = Convert.ToInt32(pieces[1]);
                            break;
                        case Constants.HEIGHT:
                            this.Height = Convert.ToInt32(pieces[1]);
                            break;
                        default:
                            using (new CenterWinDialog(this))
                            {
                                MessageBox.Show(this, String.Format(Constants.NOT_VALID_SETTING, line), Constants.ERROR,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                    }
                }
            }
        }
    }
}
