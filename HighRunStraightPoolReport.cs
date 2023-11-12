using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HighRunStraightPoolScoreKeeper
{
    public partial class HighRunStraightPoolReport : Form
    {
        private List<ReportModel> reportsRow = new List<ReportModel>();

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
            if (dgReportsGrid.SelectedRows.Count == 0)
            {
                chtAveragesScores.Series[Constants.SCORE_SERIES].Points.Clear();
                chtAveragesScores.Series[Constants.AVERAGE_SERIES].Points.Clear();
                return;
            }

            List<int> scores = new List<int>();
            List<int> averages = new List<int>();
            
            int j = 1;
            for(int i = 0; i < dgReportsGrid.SelectedRows.Count; i++)
            {
                scores.AddRange(dgReportsGrid.SelectedRows[i].Cells[1].Value.ToString().Split(',')
                    .Select(s => Convert.ToInt32(s)));

                while(j <= scores.Count)
                {
                    averages.Add((int)scores.GetRange(0, j++).Average());
                }
            }

            scores.Insert(0, 0);
            averages.Insert(0, 0);
            chtAveragesScores.Series[Constants.SCORE_SERIES].Points.DataBindXY(Enumerable.Range(0, scores.Count).ToList(), scores);
            chtAveragesScores.Series[Constants.AVERAGE_SERIES].Points.DataBindXY(Enumerable.Range(0, averages.Count).ToList(), averages);
        }
    }
}
