namespace StraightPoolScoreKeeper
{
    partial class FrmStraightPoolScoreKeeper
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStraightPoolScoreKeeper));
            this.gbxCurrentScore = new System.Windows.Forms.GroupBox();
            this.txtCurrentScore = new System.Windows.Forms.TextBox();
            this.gbxCurrentBest = new System.Windows.Forms.GroupBox();
            this.txtCurrentBest = new System.Windows.Forms.TextBox();
            this.gbxStatistics = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgCurrentScores = new System.Windows.Forms.DataGridView();
            this.AttemptNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.dgRackStatistics = new System.Windows.Forms.DataGridView();
            this.colRackNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRackCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRackScores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAverage = new System.Windows.Forms.Label();
            this.txtTotalBalls = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalRacks = new System.Windows.Forms.TextBox();
            this.lblTotalRacks = new System.Windows.Forms.Label();
            this.txtTotalAttempts = new System.Windows.Forms.TextBox();
            this.lblTotalAttemps = new System.Windows.Forms.Label();
            this.txtAverage = new System.Windows.Forms.TextBox();
            this.gbxRecord = new System.Windows.Forms.GroupBox();
            this.txtRecord = new System.Windows.Forms.TextBox();
            this.btnEndInning = new System.Windows.Forms.Button();
            this.chtAveragesScores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbxCurrentScore.SuspendLayout();
            this.gbxCurrentBest.SuspendLayout();
            this.gbxStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrentScores)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRackStatistics)).BeginInit();
            this.gbxRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtAveragesScores)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxCurrentScore
            // 
            this.gbxCurrentScore.Controls.Add(this.txtCurrentScore);
            this.gbxCurrentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCurrentScore.Location = new System.Drawing.Point(12, 12);
            this.gbxCurrentScore.Name = "gbxCurrentScore";
            this.gbxCurrentScore.Size = new System.Drawing.Size(135, 84);
            this.gbxCurrentScore.TabIndex = 0;
            this.gbxCurrentScore.TabStop = false;
            this.gbxCurrentScore.Text = "Current Score";
            // 
            // txtCurrentScore
            // 
            this.txtCurrentScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentScore.Location = new System.Drawing.Point(6, 19);
            this.txtCurrentScore.Name = "txtCurrentScore";
            this.txtCurrentScore.Size = new System.Drawing.Size(123, 26);
            this.txtCurrentScore.TabIndex = 0;
            this.txtCurrentScore.Text = "0";
            this.toolTip1.SetToolTip(this.txtCurrentScore, "Enter your score at the end of each rack or when you miss.\r\nPressing the ENTER ke" +
        "y will automatically update the \"Current Best\" and \"Record\".");
            this.txtCurrentScore.TextChanged += new System.EventHandler(this.TxtCurrentScoreTextChanged);
            this.txtCurrentScore.Enter += new System.EventHandler(this.TxtCurrentScoreEnter);
            this.txtCurrentScore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCurrentScoreKeyPress);
            this.txtCurrentScore.MouseEnter += new System.EventHandler(this.TxtCurrentScoreEnter);
            this.txtCurrentScore.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // gbxCurrentBest
            // 
            this.gbxCurrentBest.Controls.Add(this.txtCurrentBest);
            this.gbxCurrentBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCurrentBest.Location = new System.Drawing.Point(12, 102);
            this.gbxCurrentBest.Name = "gbxCurrentBest";
            this.gbxCurrentBest.Size = new System.Drawing.Size(135, 50);
            this.gbxCurrentBest.TabIndex = 1;
            this.gbxCurrentBest.TabStop = false;
            this.gbxCurrentBest.Text = "Current Best";
            // 
            // txtCurrentBest
            // 
            this.txtCurrentBest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentBest.Location = new System.Drawing.Point(6, 19);
            this.txtCurrentBest.Name = "txtCurrentBest";
            this.txtCurrentBest.ReadOnly = true;
            this.txtCurrentBest.Size = new System.Drawing.Size(123, 26);
            this.txtCurrentBest.TabIndex = 0;
            this.txtCurrentBest.TabStop = false;
            this.txtCurrentBest.Text = "0";
            // 
            // gbxStatistics
            // 
            this.gbxStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxStatistics.Controls.Add(this.btnClear);
            this.gbxStatistics.Controls.Add(this.dgCurrentScores);
            this.gbxStatistics.Controls.Add(this.dgRackStatistics);
            this.gbxStatistics.Controls.Add(this.lblAverage);
            this.gbxStatistics.Controls.Add(this.txtTotalBalls);
            this.gbxStatistics.Controls.Add(this.label1);
            this.gbxStatistics.Controls.Add(this.txtTotalRacks);
            this.gbxStatistics.Controls.Add(this.lblTotalRacks);
            this.gbxStatistics.Controls.Add(this.txtTotalAttempts);
            this.gbxStatistics.Controls.Add(this.lblTotalAttemps);
            this.gbxStatistics.Controls.Add(this.txtAverage);
            this.gbxStatistics.Location = new System.Drawing.Point(12, 214);
            this.gbxStatistics.Name = "gbxStatistics";
            this.gbxStatistics.Size = new System.Drawing.Size(554, 296);
            this.gbxStatistics.TabIndex = 2;
            this.gbxStatistics.TabStop = false;
            this.gbxStatistics.Text = "Statistics";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(6, 267);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(535, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear Scores && Statistics";
            this.toolTip1.SetToolTip(this.btnClear, "Click to clear scores and statistics");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
            this.btnClear.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.btnClear.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // dgCurrentScores
            // 
            this.dgCurrentScores.AllowUserToAddRows = false;
            this.dgCurrentScores.AllowUserToDeleteRows = false;
            this.dgCurrentScores.AllowUserToResizeColumns = false;
            this.dgCurrentScores.AllowUserToResizeRows = false;
            this.dgCurrentScores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgCurrentScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCurrentScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCurrentScores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttemptNumber,
            this.Scores});
            this.dgCurrentScores.ContextMenuStrip = this.contextMenuStrip;
            this.dgCurrentScores.Location = new System.Drawing.Point(6, 17);
            this.dgCurrentScores.MultiSelect = false;
            this.dgCurrentScores.Name = "dgCurrentScores";
            this.dgCurrentScores.RowHeadersVisible = false;
            this.dgCurrentScores.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgCurrentScores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCurrentScores.Size = new System.Drawing.Size(129, 140);
            this.dgCurrentScores.TabIndex = 13;
            this.dgCurrentScores.TabStop = false;
            this.dgCurrentScores.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgCurrentScoresMouseDown);
            // 
            // AttemptNumber
            // 
            this.AttemptNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AttemptNumber.DataPropertyName = "AttemptNumber";
            this.AttemptNumber.HeaderText = "#";
            this.AttemptNumber.MaxInputLength = 3;
            this.AttemptNumber.MinimumWidth = 28;
            this.AttemptNumber.Name = "AttemptNumber";
            this.AttemptNumber.ReadOnly = true;
            this.AttemptNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Scores
            // 
            this.Scores.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Scores.DataPropertyName = "Score";
            this.Scores.HeaderText = "Scores";
            this.Scores.MaxInputLength = 3;
            this.Scores.Name = "Scores";
            this.Scores.ReadOnly = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(107, 22);
            this.miDelete.Text = "Delete";
            this.miDelete.Click += new System.EventHandler(this.MiDeleteClick);
            // 
            // dgRackStatistics
            // 
            this.dgRackStatistics.AllowUserToAddRows = false;
            this.dgRackStatistics.AllowUserToDeleteRows = false;
            this.dgRackStatistics.AllowUserToResizeRows = false;
            this.dgRackStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRackStatistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRackStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRackStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRackNumber,
            this.colRackCount,
            this.colRackScores});
            this.dgRackStatistics.Location = new System.Drawing.Point(141, 17);
            this.dgRackStatistics.MultiSelect = false;
            this.dgRackStatistics.Name = "dgRackStatistics";
            this.dgRackStatistics.ReadOnly = true;
            this.dgRackStatistics.RowHeadersVisible = false;
            this.dgRackStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRackStatistics.Size = new System.Drawing.Size(400, 140);
            this.dgRackStatistics.TabIndex = 12;
            this.dgRackStatistics.TabStop = false;
            // 
            // colRackNumber
            // 
            this.colRackNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colRackNumber.DataPropertyName = "RackNumber";
            this.colRackNumber.HeaderText = "Rack";
            this.colRackNumber.MaxInputLength = 3;
            this.colRackNumber.Name = "colRackNumber";
            this.colRackNumber.ReadOnly = true;
            this.colRackNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRackNumber.Width = 58;
            // 
            // colRackCount
            // 
            this.colRackCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colRackCount.DataPropertyName = "RackCount";
            this.colRackCount.HeaderText = "Count";
            this.colRackCount.MaxInputLength = 3;
            this.colRackCount.Name = "colRackCount";
            this.colRackCount.ReadOnly = true;
            this.colRackCount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRackCount.Width = 60;
            // 
            // colRackScores
            // 
            this.colRackScores.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRackScores.DataPropertyName = "RackScores";
            this.colRackScores.HeaderText = "Scores";
            this.colRackScores.Name = "colRackScores";
            this.colRackScores.ReadOnly = true;
            // 
            // lblAverage
            // 
            this.lblAverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAverage.Location = new System.Drawing.Point(6, 241);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(84, 20);
            this.lblAverage.TabIndex = 11;
            this.lblAverage.Text = "Average:";
            this.lblAverage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalBalls
            // 
            this.txtTotalBalls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalBalls.Location = new System.Drawing.Point(96, 215);
            this.txtTotalBalls.Name = "txtTotalBalls";
            this.txtTotalBalls.ReadOnly = true;
            this.txtTotalBalls.Size = new System.Drawing.Size(445, 20);
            this.txtTotalBalls.TabIndex = 10;
            this.txtTotalBalls.TabStop = false;
            this.txtTotalBalls.Text = "0 of 0 (0%)";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(6, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Balls:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalRacks
            // 
            this.txtTotalRacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalRacks.Location = new System.Drawing.Point(96, 189);
            this.txtTotalRacks.Name = "txtTotalRacks";
            this.txtTotalRacks.ReadOnly = true;
            this.txtTotalRacks.Size = new System.Drawing.Size(445, 20);
            this.txtTotalRacks.TabIndex = 8;
            this.txtTotalRacks.TabStop = false;
            this.txtTotalRacks.Text = "0 of 0 (0%)";
            // 
            // lblTotalRacks
            // 
            this.lblTotalRacks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRacks.Location = new System.Drawing.Point(6, 188);
            this.lblTotalRacks.Name = "lblTotalRacks";
            this.lblTotalRacks.Size = new System.Drawing.Size(84, 20);
            this.lblTotalRacks.TabIndex = 7;
            this.lblTotalRacks.Text = "Total Racks:";
            this.lblTotalRacks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalAttempts
            // 
            this.txtTotalAttempts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAttempts.Location = new System.Drawing.Point(96, 163);
            this.txtTotalAttempts.Name = "txtTotalAttempts";
            this.txtTotalAttempts.ReadOnly = true;
            this.txtTotalAttempts.Size = new System.Drawing.Size(445, 20);
            this.txtTotalAttempts.TabIndex = 6;
            this.txtTotalAttempts.TabStop = false;
            this.txtTotalAttempts.Text = "0";
            // 
            // lblTotalAttemps
            // 
            this.lblTotalAttemps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalAttemps.Location = new System.Drawing.Point(6, 162);
            this.lblTotalAttemps.Name = "lblTotalAttemps";
            this.lblTotalAttemps.Size = new System.Drawing.Size(84, 20);
            this.lblTotalAttemps.TabIndex = 5;
            this.lblTotalAttemps.Text = "Total Attempts:";
            this.lblTotalAttemps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAverage
            // 
            this.txtAverage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAverage.Location = new System.Drawing.Point(96, 241);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.ReadOnly = true;
            this.txtAverage.Size = new System.Drawing.Size(445, 20);
            this.txtAverage.TabIndex = 4;
            this.txtAverage.TabStop = false;
            this.txtAverage.Text = "0";
            // 
            // gbxRecord
            // 
            this.gbxRecord.Controls.Add(this.txtRecord);
            this.gbxRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRecord.Location = new System.Drawing.Point(12, 158);
            this.gbxRecord.Name = "gbxRecord";
            this.gbxRecord.Size = new System.Drawing.Size(135, 50);
            this.gbxRecord.TabIndex = 3;
            this.gbxRecord.TabStop = false;
            this.gbxRecord.Text = "Record";
            // 
            // txtRecord
            // 
            this.txtRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecord.Location = new System.Drawing.Point(6, 19);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.ReadOnly = true;
            this.txtRecord.Size = new System.Drawing.Size(123, 26);
            this.txtRecord.TabIndex = 0;
            this.txtRecord.TabStop = false;
            this.txtRecord.Text = "0";
            // 
            // btnEndInning
            // 
            this.btnEndInning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndInning.Location = new System.Drawing.Point(18, 63);
            this.btnEndInning.Name = "btnEndInning";
            this.btnEndInning.Size = new System.Drawing.Size(123, 23);
            this.btnEndInning.TabIndex = 4;
            this.btnEndInning.Text = "End Inning";
            this.toolTip1.SetToolTip(this.btnEndInning, "Click when you miss.\r\nThe statistics will be calculated from the current score an" +
        "d the current score will be reset to 0.");
            this.btnEndInning.UseVisualStyleBackColor = true;
            this.btnEndInning.Click += new System.EventHandler(this.BtnEndInningClick);
            this.btnEndInning.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.btnEndInning.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // chtAveragesScores
            // 
            this.chtAveragesScores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chtAveragesScores.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "# Attempts";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.Interval = 14D;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineWidth = 2;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.Title = "Scores";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chtAveragesScores.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Black;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            this.chtAveragesScores.Legends.Add(legend1);
            this.chtAveragesScores.Location = new System.Drawing.Point(153, 12);
            this.chtAveragesScores.Name = "chtAveragesScores";
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.DodgerBlue;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Score";
            series2.BorderWidth = 5;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Average";
            this.chtAveragesScores.Series.Add(series1);
            this.chtAveragesScores.Series.Add(series2);
            this.chtAveragesScores.Size = new System.Drawing.Size(413, 196);
            this.chtAveragesScores.TabIndex = 5;
            this.chtAveragesScores.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Title1";
            title1.Text = "Averages & Scores";
            this.chtAveragesScores.Titles.Add(title1);
            // 
            // FrmStraightPoolScoreKeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 522);
            this.Controls.Add(this.chtAveragesScores);
            this.Controls.Add(this.btnEndInning);
            this.Controls.Add(this.gbxRecord);
            this.Controls.Add(this.gbxStatistics);
            this.Controls.Add(this.gbxCurrentBest);
            this.Controls.Add(this.gbxCurrentScore);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(784, 992);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(392, 496);
            this.Name = "FrmStraightPoolScoreKeeper";
            this.Text = "High Run Straight Pool Score Keeper";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmStraightPoolScoreKeeperLoad);
            this.gbxCurrentScore.ResumeLayout(false);
            this.gbxCurrentScore.PerformLayout();
            this.gbxCurrentBest.ResumeLayout(false);
            this.gbxCurrentBest.PerformLayout();
            this.gbxStatistics.ResumeLayout(false);
            this.gbxStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrentScores)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRackStatistics)).EndInit();
            this.gbxRecord.ResumeLayout(false);
            this.gbxRecord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtAveragesScores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCurrentScore;
        private System.Windows.Forms.TextBox txtCurrentScore;
        private System.Windows.Forms.GroupBox gbxCurrentBest;
        private System.Windows.Forms.TextBox txtCurrentBest;
        private System.Windows.Forms.GroupBox gbxStatistics;
        private System.Windows.Forms.TextBox txtAverage;
        private System.Windows.Forms.GroupBox gbxRecord;
        private System.Windows.Forms.TextBox txtRecord;
        private System.Windows.Forms.Button btnEndInning;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.TextBox txtTotalBalls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalRacks;
        private System.Windows.Forms.Label lblTotalRacks;
        private System.Windows.Forms.TextBox txtTotalAttempts;
        private System.Windows.Forms.Label lblTotalAttemps;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.DataGridView dgRackStatistics;
        private System.Windows.Forms.DataGridView dgCurrentScores;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtAveragesScores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRackNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRackCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRackScores;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttemptNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scores;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

