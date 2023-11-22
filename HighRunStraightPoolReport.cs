using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HighRunStraightPoolScoreKeeper
{
    public partial class HighRunStraightPoolReport : Form
    {
        private List<ReportModel> reportsRow = new List<ReportModel>();
        private Point? previousMousePosition = null;
        private ToolTip tooltip = new ToolTip();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HighRunStraightPoolReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the data from the saved scores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HighRunStraightPoolReportShown(object sender, EventArgs e)
        {
            if (File.Exists(Constants.SAVED_SCORES_CSV))
            {
                using (StreamReader sr = new StreamReader(Constants.SAVED_SCORES_CSV))
                {
                    while (sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();
                        ReportModel reportModel = new ReportModel(line);
                        reportsRow.Add(reportModel);
                    }
                }
            }

            dgReportsGrid.DataSource = reportsRow;
            dgReportsGrid.ClearSelection();

            if (dgReportsGrid.Rows.Count > 0)
                dgReportsGrid.Rows[dgReportsGrid.Rows.Count - 1].Selected = true;
        }

        /// <summary>
        /// Updates the line chart based on the selected rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgReportsGridSelectionChanged(object sender, EventArgs e)
        {
            chtAveragesScores.Series[Constants.HIGHLIGHT_SCORE_SESSION_SERIES].Points.Clear();
            chtAveragesScores.Series[Constants.HIGHLIGHT_AVERAGE_SESSION_SERIES].Points.Clear();
            if (dgReportsGrid.SelectedRows.Count == 0)
            {
                chtAveragesScores.Series[Constants.SCORE_LINE_SERIES].Points.Clear();
                chtAveragesScores.Series[Constants.SCORE_SERIES].Points.Clear();
                chtAveragesScores.Series[Constants.AVERAGE_LINE_SERIES].Points.Clear();
                chtAveragesScores.Series[Constants.AVERAGE_SERIES].Points.Clear();
                return;
            }

            List<int> scores = new List<int>();
            List<int> averages = new List<int>();

            int j = 1;
            List<DataGridViewRow> selectedRows = dgReportsGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(sr => sr.Index).ToList();
            for (int i = 0; i < selectedRows.Count; i++)
            {
                scores.AddRange(selectedRows[i].Cells[1].Value.ToString().Split(',')
                    .Select(s => Convert.ToInt32(s)));

                while(j <= scores.Count)
                {
                    averages.Add((int)scores.GetRange(0, j++).Average());
                }
            }

            scores.Insert(0, 0);
            averages.Insert(0, 0);
            chtAveragesScores.Series[Constants.SCORE_LINE_SERIES].Points.DataBindXY(Enumerable.Range(0, scores.Count).ToList(), scores);
            chtAveragesScores.Series[Constants.SCORE_SERIES].Points.DataBindXY(Enumerable.Range(0, scores.Count).ToList(), scores);
            chtAveragesScores.Series[Constants.AVERAGE_LINE_SERIES].Points.DataBindXY(Enumerable.Range(0, averages.Count).ToList(), averages);
            chtAveragesScores.Series[Constants.AVERAGE_SERIES].Points.DataBindXY(Enumerable.Range(0, averages.Count).ToList(), averages);

            int x = 1;
            for (int i = 0; i < selectedRows.Count; i++)
            {
                int scoreY = scores[x];
                int averageY = averages[x];
                chtAveragesScores.Series[Constants.HIGHLIGHT_SCORE_SESSION_SERIES].Points.AddXY(x, scoreY);
                chtAveragesScores.Series[Constants.HIGHLIGHT_AVERAGE_SESSION_SERIES].Points.AddXY(x, averageY);

                x += selectedRows[i].Cells[1].Value.ToString().Split(',').Length;
            }
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
            var results = chtAveragesScores.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); 
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
    }
}
