namespace ToornamentAPP.UserControlls
{
    partial class Tournaments
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbAvailable = new System.Windows.Forms.RadioButton();
            this.rbCancelled = new System.Windows.Forms.RadioButton();
            this.rbFinished = new System.Windows.Forms.RadioButton();
            this.rbPending = new System.Windows.Forms.RadioButton();
            this.rbInProgress = new System.Windows.Forms.RadioButton();
            this.flowLayoutTournaments = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSearchBySport = new System.Windows.Forms.Button();
            this.cbSportType = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbAvailable
            // 
            this.rbAvailable.AutoSize = true;
            this.rbAvailable.Checked = true;
            this.rbAvailable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbAvailable.Location = new System.Drawing.Point(31, 22);
            this.rbAvailable.Name = "rbAvailable";
            this.rbAvailable.Size = new System.Drawing.Size(113, 32);
            this.rbAvailable.TabIndex = 0;
            this.rbAvailable.TabStop = true;
            this.rbAvailable.Text = "Available";
            this.rbAvailable.UseVisualStyleBackColor = true;
            this.rbAvailable.CheckedChanged += new System.EventHandler(this.rbAvailable_CheckedChanged);
            // 
            // rbCancelled
            // 
            this.rbCancelled.AutoSize = true;
            this.rbCancelled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbCancelled.Location = new System.Drawing.Point(230, 22);
            this.rbCancelled.Name = "rbCancelled";
            this.rbCancelled.Size = new System.Drawing.Size(117, 32);
            this.rbCancelled.TabIndex = 1;
            this.rbCancelled.TabStop = true;
            this.rbCancelled.Text = "Cancelled";
            this.rbCancelled.UseVisualStyleBackColor = true;
            this.rbCancelled.CheckedChanged += new System.EventHandler(this.rbCancelled_CheckedChanged);
            // 
            // rbFinished
            // 
            this.rbFinished.AutoSize = true;
            this.rbFinished.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbFinished.Location = new System.Drawing.Point(452, 22);
            this.rbFinished.Name = "rbFinished";
            this.rbFinished.Size = new System.Drawing.Size(105, 32);
            this.rbFinished.TabIndex = 2;
            this.rbFinished.TabStop = true;
            this.rbFinished.Text = "Finished";
            this.rbFinished.UseVisualStyleBackColor = true;
            this.rbFinished.CheckedChanged += new System.EventHandler(this.rbFinished_CheckedChanged);
            // 
            // rbPending
            // 
            this.rbPending.AutoSize = true;
            this.rbPending.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbPending.Location = new System.Drawing.Point(649, 22);
            this.rbPending.Name = "rbPending";
            this.rbPending.Size = new System.Drawing.Size(104, 32);
            this.rbPending.TabIndex = 3;
            this.rbPending.TabStop = true;
            this.rbPending.Text = "Pending";
            this.rbPending.UseVisualStyleBackColor = true;
            this.rbPending.CheckedChanged += new System.EventHandler(this.rbPending_CheckedChanged);
            // 
            // rbInProgress
            // 
            this.rbInProgress.AutoSize = true;
            this.rbInProgress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbInProgress.Location = new System.Drawing.Point(809, 22);
            this.rbInProgress.Name = "rbInProgress";
            this.rbInProgress.Size = new System.Drawing.Size(130, 32);
            this.rbInProgress.TabIndex = 4;
            this.rbInProgress.TabStop = true;
            this.rbInProgress.Text = "In progress";
            this.rbInProgress.UseVisualStyleBackColor = true;
            this.rbInProgress.CheckedChanged += new System.EventHandler(this.rbInProgress_CheckedChanged);
            // 
            // flowLayoutTournaments
            // 
            this.flowLayoutTournaments.AutoScroll = true;
            this.flowLayoutTournaments.BackColor = System.Drawing.Color.MediumAquamarine;
            this.flowLayoutTournaments.Location = new System.Drawing.Point(15, 144);
            this.flowLayoutTournaments.Name = "flowLayoutTournaments";
            this.flowLayoutTournaments.Size = new System.Drawing.Size(1051, 516);
            this.flowLayoutTournaments.TabIndex = 5;
            // 
            // btnSearchBySport
            // 
            this.btnSearchBySport.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnSearchBySport.FlatAppearance.BorderSize = 0;
            this.btnSearchBySport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchBySport.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSearchBySport.Location = new System.Drawing.Point(537, 90);
            this.btnSearchBySport.Name = "btnSearchBySport";
            this.btnSearchBySport.Size = new System.Drawing.Size(180, 33);
            this.btnSearchBySport.TabIndex = 7;
            this.btnSearchBySport.Text = "search by sport";
            this.btnSearchBySport.UseVisualStyleBackColor = false;
            this.btnSearchBySport.Click += new System.EventHandler(this.btnSearchBySport_Click);
            // 
            // cbSportType
            // 
            this.cbSportType.FormattingEnabled = true;
            this.cbSportType.Items.AddRange(new object[] {
            "Badminton",
            "Boxing"});
            this.cbSportType.Location = new System.Drawing.Point(246, 95);
            this.cbSportType.Name = "cbSportType";
            this.cbSportType.Size = new System.Drawing.Size(234, 28);
            this.cbSportType.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(940, 77);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 31);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Tournaments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbSportType);
            this.Controls.Add(this.btnSearchBySport);
            this.Controls.Add(this.flowLayoutTournaments);
            this.Controls.Add(this.rbInProgress);
            this.Controls.Add(this.rbPending);
            this.Controls.Add(this.rbFinished);
            this.Controls.Add(this.rbCancelled);
            this.Controls.Add(this.rbAvailable);
            this.Name = "Tournaments";
            this.Size = new System.Drawing.Size(1088, 695);
            this.Load += new System.EventHandler(this.Tournaments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton rbAvailable;
        private RadioButton rbCancelled;
        private RadioButton rbFinished;
        private RadioButton rbPending;
        private RadioButton rbInProgress;
        private FlowLayoutPanel flowLayoutTournaments;
        private Button btnSearchBySport;
        private ComboBox cbSportType;
        private Button btnRefresh;
    }
}
