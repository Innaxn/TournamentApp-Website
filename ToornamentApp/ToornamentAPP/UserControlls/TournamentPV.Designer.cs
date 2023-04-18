namespace ToornamentAPP.UserControlls
{
    partial class TournamentPV
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnMakeItCancelled = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.btnInProgress = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(39, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 28);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStartDate.Location = new System.Drawing.Point(39, 83);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 23);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "label2";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEndDate.Location = new System.Drawing.Point(39, 133);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 23);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "label3";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(747, 44);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(96, 49);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(630, 44);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 49);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(885, 44);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(96, 49);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnMakeItCancelled
            // 
            this.btnMakeItCancelled.Location = new System.Drawing.Point(885, 104);
            this.btnMakeItCancelled.Name = "btnMakeItCancelled";
            this.btnMakeItCancelled.Size = new System.Drawing.Size(96, 49);
            this.btnMakeItCancelled.TabIndex = 7;
            this.btnMakeItCancelled.Text = "Cancel it";
            this.btnMakeItCancelled.UseVisualStyleBackColor = true;
            this.btnMakeItCancelled.Visible = false;
            this.btnMakeItCancelled.Click += new System.EventHandler(this.btnMakeItCancelled_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblId.Location = new System.Drawing.Point(397, 25);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(59, 25);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "label2";
            // 
            // btnInProgress
            // 
            this.btnInProgress.Location = new System.Drawing.Point(747, 104);
            this.btnInProgress.Name = "btnInProgress";
            this.btnInProgress.Size = new System.Drawing.Size(96, 49);
            this.btnInProgress.TabIndex = 9;
            this.btnInProgress.Text = "In progress";
            this.btnInProgress.UseVisualStyleBackColor = true;
            this.btnInProgress.Visible = false;
            this.btnInProgress.Click += new System.EventHandler(this.btnInProgress_Click);
            // 
            // btnPending
            // 
            this.btnPending.Location = new System.Drawing.Point(630, 104);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(96, 49);
            this.btnPending.TabIndex = 10;
            this.btnPending.Text = "Pending";
            this.btnPending.UseVisualStyleBackColor = true;
            this.btnPending.Visible = false;
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLocation.Location = new System.Drawing.Point(397, 68);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(59, 25);
            this.lblLocation.TabIndex = 11;
            this.lblLocation.Text = "label2";
            // 
            // TournamentPV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnPending);
            this.Controls.Add(this.btnInProgress);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnMakeItCancelled);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblName);
            this.Name = "TournamentPV";
            this.Size = new System.Drawing.Size(1042, 167);
            this.Load += new System.EventHandler(this.TournamentPV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblName;
        private Label lblStartDate;
        private Label lblEndDate;
        private Button btnRemove;
        private Button btnUpdate;
        private Button btnDetails;
        private Button btnMakeItCancelled;
        private Label lblId;
        private Button btnInProgress;
        private Button btnPending;
        private Label lblLocation;
    }
}
