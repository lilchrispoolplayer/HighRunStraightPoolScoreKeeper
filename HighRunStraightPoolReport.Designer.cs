namespace HighRunStraightPoolScoreKeeper
{
    partial class HighRunStraightPoolReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chtAveragesScores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbxStatistics = new System.Windows.Forms.GroupBox();
            this.dgReportsGrid = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRackScores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAttempts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRackCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBpi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRacksRan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBallsMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chtAveragesScores)).BeginInit();
            this.gbxStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReportsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // chtAveragesScores
            // 
            this.chtAveragesScores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chtAveragesScores.BackColor = System.Drawing.Color.Black;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "# Attempts";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.Interval = 14D;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.IsMarginVisible = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorGrid.LineWidth = 2;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.Title = "Scores";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.BackSecondaryColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chtAveragesScores.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Black;
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.Name = "Legend1";
            this.chtAveragesScores.Legends.Add(legend2);
            this.chtAveragesScores.Location = new System.Drawing.Point(12, 12);
            this.chtAveragesScores.Name = "chtAveragesScores";
            series3.BorderWidth = 5;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.DodgerBlue;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "Score";
            series4.BorderWidth = 5;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "Average";
            this.chtAveragesScores.Series.Add(series3);
            this.chtAveragesScores.Series.Add(series4);
            this.chtAveragesScores.Size = new System.Drawing.Size(776, 320);
            this.chtAveragesScores.TabIndex = 6;
            this.chtAveragesScores.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.White;
            title2.Name = "Title1";
            title2.Text = "Averages & Scores";
            this.chtAveragesScores.Titles.Add(title2);
            // 
            // gbxStatistics
            // 
            this.gbxStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxStatistics.Controls.Add(this.dgReportsGrid);
            this.gbxStatistics.Location = new System.Drawing.Point(12, 338);
            this.gbxStatistics.Name = "gbxStatistics";
            this.gbxStatistics.Size = new System.Drawing.Size(776, 383);
            this.gbxStatistics.TabIndex = 7;
            this.gbxStatistics.TabStop = false;
            this.gbxStatistics.Text = "Statistics";
            // 
            // dgReportsGrid
            // 
            this.dgReportsGrid.AllowUserToAddRows = false;
            this.dgReportsGrid.AllowUserToDeleteRows = false;
            this.dgReportsGrid.AllowUserToResizeRows = false;
            this.dgReportsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgReportsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgReportsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReportsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colRackScores,
            this.colTotalAttempts,
            this.colRackCount,
            this.colBpi,
            this.colRacksRan,
            this.colBallsMade});
            this.dgReportsGrid.Location = new System.Drawing.Point(6, 19);
            this.dgReportsGrid.Name = "dgReportsGrid";
            this.dgReportsGrid.ReadOnly = true;
            this.dgReportsGrid.RowHeadersVisible = false;
            this.dgReportsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgReportsGrid.Size = new System.Drawing.Size(764, 358);
            this.dgReportsGrid.TabIndex = 12;
            this.dgReportsGrid.TabStop = false;
            this.dgReportsGrid.SelectionChanged += new System.EventHandler(this.DgReportsGridSelectionChanged);
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDate.DataPropertyName = "Date";
            this.colDate.FillWeight = 55F;
            this.colDate.HeaderText = "Date";
            this.colDate.MaxInputLength = 10;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colRackScores
            // 
            this.colRackScores.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colRackScores.DataPropertyName = "Scores";
            this.colRackScores.HeaderText = "Scores";
            this.colRackScores.Name = "colRackScores";
            this.colRackScores.ReadOnly = true;
            this.colRackScores.Width = 265;
            // 
            // colTotalAttempts
            // 
            this.colTotalAttempts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colTotalAttempts.DataPropertyName = "TotalAttempts";
            this.colTotalAttempts.HeaderText = "Total Attempts";
            this.colTotalAttempts.Name = "colTotalAttempts";
            this.colTotalAttempts.ReadOnly = true;
            this.colTotalAttempts.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colRackCount
            // 
            this.colRackCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colRackCount.DataPropertyName = "HighRun";
            this.colRackCount.HeaderText = "High Run";
            this.colRackCount.MaxInputLength = 3;
            this.colRackCount.Name = "colRackCount";
            this.colRackCount.ReadOnly = true;
            this.colRackCount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRackCount.Width = 77;
            // 
            // colBpi
            // 
            this.colBpi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colBpi.DataPropertyName = "Bpi";
            this.colBpi.HeaderText = "BPI";
            this.colBpi.MaxInputLength = 3;
            this.colBpi.Name = "colBpi";
            this.colBpi.ReadOnly = true;
            this.colBpi.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBpi.Width = 49;
            // 
            // colRacksRan
            // 
            this.colRacksRan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colRacksRan.DataPropertyName = "RacksRan";
            this.colRacksRan.HeaderText = "Racks Ran";
            this.colRacksRan.Name = "colRacksRan";
            this.colRacksRan.ReadOnly = true;
            this.colRacksRan.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRacksRan.Width = 86;
            // 
            // colBallsMade
            // 
            this.colBallsMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colBallsMade.DataPropertyName = "BallsMade";
            this.colBallsMade.HeaderText = "Balls Made";
            this.colBallsMade.Name = "colBallsMade";
            this.colBallsMade.ReadOnly = true;
            this.colBallsMade.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBallsMade.Width = 84;
            // 
            // HighRunStraightPoolReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 733);
            this.Controls.Add(this.gbxStatistics);
            this.Controls.Add(this.chtAveragesScores);
            this.Name = "HighRunStraightPoolReport";
            this.Text = "HighRunStraightPoolReport";
            this.Shown += new System.EventHandler(this.HighRunStraightPoolReportShown);
            ((System.ComponentModel.ISupportInitialize)(this.chtAveragesScores)).EndInit();
            this.gbxStatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReportsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtAveragesScores;
        private System.Windows.Forms.GroupBox gbxStatistics;
        private System.Windows.Forms.DataGridView dgReportsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRackScores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAttempts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRackCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBpi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRacksRan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBallsMade;
    }
}