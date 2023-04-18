namespace ToornamentAPP.UserControlls
{
    partial class GamePV
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
            this.btnResults = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlayerOne = new System.Windows.Forms.Label();
            this.lblPlayerTwo = new System.Windows.Forms.Label();
            this.lblOnePoints = new System.Windows.Forms.Label();
            this.lblTwoPoints = new System.Windows.Forms.Label();
            this.lblWinner = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnResults
            // 
            this.btnResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(205)))), ((int)(((byte)(198)))));
            this.btnResults.FlatAppearance.BorderSize = 0;
            this.btnResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResults.Location = new System.Drawing.Point(71, 192);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(149, 34);
            this.btnResults.TabIndex = 0;
            this.btnResults.Text = "Results";
            this.btnResults.UseVisualStyleBackColor = false;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(99, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game";
            // 
            // lblPlayerOne
            // 
            this.lblPlayerOne.AutoSize = true;
            this.lblPlayerOne.Location = new System.Drawing.Point(3, 68);
            this.lblPlayerOne.Name = "lblPlayerOne";
            this.lblPlayerOne.Size = new System.Drawing.Size(75, 20);
            this.lblPlayerOne.TabIndex = 2;
            this.lblPlayerOne.Text = "playerone";
            // 
            // lblPlayerTwo
            // 
            this.lblPlayerTwo.AutoSize = true;
            this.lblPlayerTwo.Location = new System.Drawing.Point(3, 126);
            this.lblPlayerTwo.Name = "lblPlayerTwo";
            this.lblPlayerTwo.Size = new System.Drawing.Size(75, 20);
            this.lblPlayerTwo.TabIndex = 3;
            this.lblPlayerTwo.Text = "playertwo";
            // 
            // lblOnePoints
            // 
            this.lblOnePoints.AutoSize = true;
            this.lblOnePoints.Location = new System.Drawing.Point(209, 68);
            this.lblOnePoints.Name = "lblOnePoints";
            this.lblOnePoints.Size = new System.Drawing.Size(50, 20);
            this.lblOnePoints.TabIndex = 4;
            this.lblOnePoints.Text = "label4";
            // 
            // lblTwoPoints
            // 
            this.lblTwoPoints.AutoSize = true;
            this.lblTwoPoints.Location = new System.Drawing.Point(209, 126);
            this.lblTwoPoints.Name = "lblTwoPoints";
            this.lblTwoPoints.Size = new System.Drawing.Size(50, 20);
            this.lblTwoPoints.TabIndex = 5;
            this.lblTwoPoints.Text = "label5";
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Location = new System.Drawing.Point(43, 31);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(50, 20);
            this.lblWinner.TabIndex = 6;
            this.lblWinner.Text = "label2";
            // 
            // GamePV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.lblTwoPoints);
            this.Controls.Add(this.lblOnePoints);
            this.Controls.Add(this.lblPlayerTwo);
            this.Controls.Add(this.lblPlayerOne);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnResults);
            this.Name = "GamePV";
            this.Size = new System.Drawing.Size(314, 247);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnResults;
        private Label label1;
        private Label lblPlayerOne;
        private Label lblPlayerTwo;
        private Label lblOnePoints;
        private Label lblTwoPoints;
        private Label lblWinner;
    }
}
