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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStraightPoolScoreKeeper));
            this.gbxCurrentScore = new System.Windows.Forms.GroupBox();
            this.txtCurrentScore = new System.Windows.Forms.TextBox();
            this.gbxCurrentBest = new System.Windows.Forms.GroupBox();
            this.txtCurrentBest = new System.Windows.Forms.TextBox();
            this.gbxStatistics = new System.Windows.Forms.GroupBox();
            this.dgCurrentScores = new System.Windows.Forms.DataGridView();
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
            this.btnReset = new System.Windows.Forms.Button();
            this.gbxCurrentScore.SuspendLayout();
            this.gbxCurrentBest.SuspendLayout();
            this.gbxStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrentScores)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRackStatistics)).BeginInit();
            this.gbxRecord.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxCurrentScore
            // 
            this.gbxCurrentScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxCurrentScore.Controls.Add(this.txtCurrentScore);
            this.gbxCurrentScore.Location = new System.Drawing.Point(12, 12);
            this.gbxCurrentScore.Name = "gbxCurrentScore";
            this.gbxCurrentScore.Size = new System.Drawing.Size(352, 50);
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
            this.txtCurrentScore.Size = new System.Drawing.Size(333, 20);
            this.txtCurrentScore.TabIndex = 0;
            this.txtCurrentScore.Text = "0";
            this.txtCurrentScore.TextChanged += new System.EventHandler(this.TxtCurrentScoreTextChanged);
            this.txtCurrentScore.Enter += new System.EventHandler(this.TxtCurrentScoreEnter);
            this.txtCurrentScore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCurrentScoreKeyPress);
            // 
            // gbxCurrentBest
            // 
            this.gbxCurrentBest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxCurrentBest.Controls.Add(this.txtCurrentBest);
            this.gbxCurrentBest.Location = new System.Drawing.Point(12, 68);
            this.gbxCurrentBest.Name = "gbxCurrentBest";
            this.gbxCurrentBest.Size = new System.Drawing.Size(352, 50);
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
            this.txtCurrentBest.Size = new System.Drawing.Size(333, 20);
            this.txtCurrentBest.TabIndex = 0;
            this.txtCurrentBest.TabStop = false;
            this.txtCurrentBest.Text = "0";
            this.txtCurrentBest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCurrentBestKeyPress);
            // 
            // gbxStatistics
            // 
            this.gbxStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.gbxStatistics.Location = new System.Drawing.Point(12, 180);
            this.gbxStatistics.Name = "gbxStatistics";
            this.gbxStatistics.Size = new System.Drawing.Size(352, 240);
            this.gbxStatistics.TabIndex = 2;
            this.gbxStatistics.TabStop = false;
            this.gbxStatistics.Text = "Statistics";
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
            this.Scores});
            this.dgCurrentScores.ContextMenuStrip = this.contextMenuStrip;
            this.dgCurrentScores.Location = new System.Drawing.Point(6, 17);
            this.dgCurrentScores.MultiSelect = false;
            this.dgCurrentScores.Name = "dgCurrentScores";
            this.dgCurrentScores.RowHeadersVisible = false;
            this.dgCurrentScores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCurrentScores.Size = new System.Drawing.Size(84, 108);
            this.dgCurrentScores.TabIndex = 13;
            // 
            // Scores
            // 
            this.Scores.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Scores.DataPropertyName = "Score";
            this.Scores.Frozen = true;
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
            this.dgRackStatistics.Location = new System.Drawing.Point(96, 17);
            this.dgRackStatistics.MultiSelect = false;
            this.dgRackStatistics.Name = "dgRackStatistics";
            this.dgRackStatistics.RowHeadersVisible = false;
            this.dgRackStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRackStatistics.Size = new System.Drawing.Size(243, 108);
            this.dgRackStatistics.TabIndex = 12;
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
            this.colRackScores.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRackScores.DataPropertyName = "RackScores";
            this.colRackScores.HeaderText = "Scores";
            this.colRackScores.Name = "colRackScores";
            this.colRackScores.ReadOnly = true;
            this.colRackScores.Width = 65;
            // 
            // lblAverage
            // 
            this.lblAverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAverage.Location = new System.Drawing.Point(6, 214);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.Size = new System.Drawing.Size(84, 20);
            this.lblAverage.TabIndex = 11;
            this.lblAverage.Text = "Average:";
            this.lblAverage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalBalls
            // 
            this.txtTotalBalls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalBalls.Location = new System.Drawing.Point(96, 188);
            this.txtTotalBalls.Name = "txtTotalBalls";
            this.txtTotalBalls.ReadOnly = true;
            this.txtTotalBalls.Size = new System.Drawing.Size(243, 20);
            this.txtTotalBalls.TabIndex = 10;
            this.txtTotalBalls.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(6, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Balls:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalRacks
            // 
            this.txtTotalRacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalRacks.Location = new System.Drawing.Point(96, 162);
            this.txtTotalRacks.Name = "txtTotalRacks";
            this.txtTotalRacks.ReadOnly = true;
            this.txtTotalRacks.Size = new System.Drawing.Size(243, 20);
            this.txtTotalRacks.TabIndex = 8;
            this.txtTotalRacks.Text = "0";
            // 
            // lblTotalRacks
            // 
            this.lblTotalRacks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRacks.Location = new System.Drawing.Point(6, 161);
            this.lblTotalRacks.Name = "lblTotalRacks";
            this.lblTotalRacks.Size = new System.Drawing.Size(84, 20);
            this.lblTotalRacks.TabIndex = 7;
            this.lblTotalRacks.Text = "Total Racks:";
            this.lblTotalRacks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalAttempts
            // 
            this.txtTotalAttempts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAttempts.Location = new System.Drawing.Point(96, 136);
            this.txtTotalAttempts.Name = "txtTotalAttempts";
            this.txtTotalAttempts.ReadOnly = true;
            this.txtTotalAttempts.Size = new System.Drawing.Size(243, 20);
            this.txtTotalAttempts.TabIndex = 6;
            this.txtTotalAttempts.Text = "0";
            // 
            // lblTotalAttemps
            // 
            this.lblTotalAttemps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalAttemps.Location = new System.Drawing.Point(6, 135);
            this.lblTotalAttemps.Name = "lblTotalAttemps";
            this.lblTotalAttemps.Size = new System.Drawing.Size(84, 20);
            this.lblTotalAttemps.TabIndex = 5;
            this.lblTotalAttemps.Text = "Total Attempts:";
            this.lblTotalAttemps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAverage
            // 
            this.txtAverage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAverage.Location = new System.Drawing.Point(96, 214);
            this.txtAverage.Name = "txtAverage";
            this.txtAverage.ReadOnly = true;
            this.txtAverage.Size = new System.Drawing.Size(243, 20);
            this.txtAverage.TabIndex = 4;
            this.txtAverage.TabStop = false;
            this.txtAverage.Text = "0";
            // 
            // gbxRecord
            // 
            this.gbxRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRecord.Controls.Add(this.txtRecord);
            this.gbxRecord.Location = new System.Drawing.Point(12, 124);
            this.gbxRecord.Name = "gbxRecord";
            this.gbxRecord.Size = new System.Drawing.Size(352, 50);
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
            this.txtRecord.Size = new System.Drawing.Size(333, 20);
            this.txtRecord.TabIndex = 0;
            this.txtRecord.TabStop = false;
            this.txtRecord.Text = "0";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(12, 426);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(352, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // 
            // FrmStraightPoolScoreKeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 457);
            this.Controls.Add(this.btnReset);
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
        private System.Windows.Forms.Button btnReset;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Scores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRackNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRackCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRackScores;
    }
}

