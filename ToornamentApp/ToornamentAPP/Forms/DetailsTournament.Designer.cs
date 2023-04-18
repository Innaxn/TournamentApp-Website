namespace ToornamentAPP.Forms
{
    partial class DetailsTournament
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lbPlayers = new System.Windows.Forms.ListBox();
            this.lblSignedPlayers = new System.Windows.Forms.Label();
            this.btnGenerateSchedule = new System.Windows.Forms.Button();
            this.cbPlayers = new System.Windows.Forms.ComboBox();
            this.btnShowGames = new System.Windows.Forms.Button();
            this.flowLayoutGames = new System.Windows.Forms.FlowLayoutPanel();
            this.lbGames = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(235, 135);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(50, 20);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "label1";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(23, 120);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(34, 20);
            this.lblMin.TabIndex = 1;
            this.lblMin.Text = "min";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(235, 86);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(62, 20);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(235, 46);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(34, 20);
            this.lblCity.TabIndex = 3;
            this.lblCity.Text = "City";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(23, 86);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(34, 20);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "end";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(23, 46);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(38, 20);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "start";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(20, 151);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(37, 20);
            this.lblMax.TabIndex = 6;
            this.lblMax.Text = "max";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 200);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 20);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";
            // 
            // lbPlayers
            // 
            this.lbPlayers.FormattingEnabled = true;
            this.lbPlayers.ItemHeight = 20;
            this.lbPlayers.Location = new System.Drawing.Point(578, 12);
            this.lbPlayers.Name = "lbPlayers";
            this.lbPlayers.Size = new System.Drawing.Size(472, 184);
            this.lbPlayers.TabIndex = 8;
            // 
            // lblSignedPlayers
            // 
            this.lblSignedPlayers.AutoSize = true;
            this.lblSignedPlayers.Location = new System.Drawing.Point(235, 200);
            this.lblSignedPlayers.Name = "lblSignedPlayers";
            this.lblSignedPlayers.Size = new System.Drawing.Size(50, 20);
            this.lblSignedPlayers.TabIndex = 9;
            this.lblSignedPlayers.Text = "label1";
            // 
            // btnGenerateSchedule
            // 
            this.btnGenerateSchedule.Location = new System.Drawing.Point(390, 261);
            this.btnGenerateSchedule.Name = "btnGenerateSchedule";
            this.btnGenerateSchedule.Size = new System.Drawing.Size(137, 51);
            this.btnGenerateSchedule.TabIndex = 10;
            this.btnGenerateSchedule.Text = "generate schedule";
            this.btnGenerateSchedule.UseVisualStyleBackColor = true;
            this.btnGenerateSchedule.Visible = false;
            this.btnGenerateSchedule.Click += new System.EventHandler(this.btnGenerateSchedule_Click);
            // 
            // cbPlayers
            // 
            this.cbPlayers.FormattingEnabled = true;
            this.cbPlayers.Location = new System.Drawing.Point(20, 343);
            this.cbPlayers.Name = "cbPlayers";
            this.cbPlayers.Size = new System.Drawing.Size(302, 28);
            this.cbPlayers.TabIndex = 11;
            this.cbPlayers.Visible = false;
            // 
            // btnShowGames
            // 
            this.btnShowGames.Location = new System.Drawing.Point(381, 331);
            this.btnShowGames.Name = "btnShowGames";
            this.btnShowGames.Size = new System.Drawing.Size(146, 51);
            this.btnShowGames.TabIndex = 12;
            this.btnShowGames.Text = "Show games";
            this.btnShowGames.UseVisualStyleBackColor = true;
            this.btnShowGames.Visible = false;
            this.btnShowGames.Click += new System.EventHandler(this.btnShowGames_Click);
            // 
            // flowLayoutGames
            // 
            this.flowLayoutGames.AutoScroll = true;
            this.flowLayoutGames.BackColor = System.Drawing.Color.MediumAquamarine;
            this.flowLayoutGames.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutGames.Location = new System.Drawing.Point(20, 434);
            this.flowLayoutGames.Name = "flowLayoutGames";
            this.flowLayoutGames.Size = new System.Drawing.Size(1030, 306);
            this.flowLayoutGames.TabIndex = 13;
            this.flowLayoutGames.Visible = false;
            // 
            // lbGames
            // 
            this.lbGames.FormattingEnabled = true;
            this.lbGames.ItemHeight = 20;
            this.lbGames.Location = new System.Drawing.Point(578, 212);
            this.lbGames.Name = "lbGames";
            this.lbGames.Size = new System.Drawing.Size(472, 184);
            this.lbGames.TabIndex = 14;
            this.lbGames.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Search games by player";
            // 
            // DetailsTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1071, 796);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbGames);
            this.Controls.Add(this.flowLayoutGames);
            this.Controls.Add(this.btnShowGames);
            this.Controls.Add(this.cbPlayers);
            this.Controls.Add(this.btnGenerateSchedule);
            this.Controls.Add(this.lblSignedPlayers);
            this.Controls.Add(this.lbPlayers);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblDescription);
            this.Name = "DetailsTournament";
            this.Text = "DetailsTournament";
            this.Load += new System.EventHandler(this.DetailsTournament_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDescription;
        private Label lblMin;
        private Label lblAddress;
        private Label lblCity;
        private Label lblEnd;
        private Label lblStart;
        private Label lblMax;
        private Label lblStatus;
        private ListBox lbPlayers;
        private Label lblSignedPlayers;
        private Button btnGenerateSchedule;
        private ComboBox cbPlayers;
        private Button btnShowGames;
        private FlowLayoutPanel flowLayoutGames;
        private ListBox lbGames;
        private Label label1;
    }
}