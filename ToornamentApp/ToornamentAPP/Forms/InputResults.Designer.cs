namespace ToornamentAPP.Forms
{
    partial class InputResults
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
            this.btnSubmitResults = new System.Windows.Forms.Button();
            this.tbPlayerOne = new System.Windows.Forms.TextBox();
            this.tbPlayerTwo = new System.Windows.Forms.TextBox();
            this.lblPlayerOne = new System.Windows.Forms.Label();
            this.lblPlayerTwo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbKOPlayerOne = new System.Windows.Forms.RadioButton();
            this.rbKOPlayerTwo = new System.Windows.Forms.RadioButton();
            this.rbTKOPlayerOne = new System.Windows.Forms.RadioButton();
            this.rbTKOPlayerTwo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnSubmitResults
            // 
            this.btnSubmitResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(205)))), ((int)(((byte)(198)))));
            this.btnSubmitResults.FlatAppearance.BorderSize = 0;
            this.btnSubmitResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitResults.Location = new System.Drawing.Point(240, 240);
            this.btnSubmitResults.Name = "btnSubmitResults";
            this.btnSubmitResults.Size = new System.Drawing.Size(158, 50);
            this.btnSubmitResults.TabIndex = 0;
            this.btnSubmitResults.Text = "Submit results";
            this.btnSubmitResults.UseVisualStyleBackColor = false;
            this.btnSubmitResults.Click += new System.EventHandler(this.btnSubmitResults_Click);
            // 
            // tbPlayerOne
            // 
            this.tbPlayerOne.Location = new System.Drawing.Point(161, 82);
            this.tbPlayerOne.Multiline = true;
            this.tbPlayerOne.Name = "tbPlayerOne";
            this.tbPlayerOne.Size = new System.Drawing.Size(285, 35);
            this.tbPlayerOne.TabIndex = 1;
            // 
            // tbPlayerTwo
            // 
            this.tbPlayerTwo.Location = new System.Drawing.Point(161, 156);
            this.tbPlayerTwo.Multiline = true;
            this.tbPlayerTwo.Name = "tbPlayerTwo";
            this.tbPlayerTwo.Size = new System.Drawing.Size(285, 35);
            this.tbPlayerTwo.TabIndex = 2;
            // 
            // lblPlayerOne
            // 
            this.lblPlayerOne.AutoSize = true;
            this.lblPlayerOne.Location = new System.Drawing.Point(2, 84);
            this.lblPlayerOne.Name = "lblPlayerOne";
            this.lblPlayerOne.Size = new System.Drawing.Size(50, 20);
            this.lblPlayerOne.TabIndex = 3;
            this.lblPlayerOne.Text = "label1";
            // 
            // lblPlayerTwo
            // 
            this.lblPlayerTwo.AutoSize = true;
            this.lblPlayerTwo.Location = new System.Drawing.Point(2, 164);
            this.lblPlayerTwo.Name = "lblPlayerTwo";
            this.lblPlayerTwo.Size = new System.Drawing.Size(50, 20);
            this.lblPlayerTwo.TabIndex = 4;
            this.lblPlayerTwo.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(268, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Results";
            // 
            // rbKOPlayerOne
            // 
            this.rbKOPlayerOne.AutoSize = true;
            this.rbKOPlayerOne.Location = new System.Drawing.Point(490, 82);
            this.rbKOPlayerOne.Name = "rbKOPlayerOne";
            this.rbKOPlayerOne.Size = new System.Drawing.Size(49, 24);
            this.rbKOPlayerOne.TabIndex = 6;
            this.rbKOPlayerOne.TabStop = true;
            this.rbKOPlayerOne.Text = "KO";
            this.rbKOPlayerOne.UseVisualStyleBackColor = true;
            this.rbKOPlayerOne.CheckedChanged += new System.EventHandler(this.rbKOPlayerOne_CheckedChanged);
            // 
            // rbKOPlayerTwo
            // 
            this.rbKOPlayerTwo.AutoSize = true;
            this.rbKOPlayerTwo.Location = new System.Drawing.Point(490, 162);
            this.rbKOPlayerTwo.Name = "rbKOPlayerTwo";
            this.rbKOPlayerTwo.Size = new System.Drawing.Size(49, 24);
            this.rbKOPlayerTwo.TabIndex = 7;
            this.rbKOPlayerTwo.TabStop = true;
            this.rbKOPlayerTwo.Text = "KO";
            this.rbKOPlayerTwo.UseVisualStyleBackColor = true;
            this.rbKOPlayerTwo.CheckedChanged += new System.EventHandler(this.rbKOPlayerTwo_CheckedChanged);
            // 
            // rbTKOPlayerOne
            // 
            this.rbTKOPlayerOne.AutoSize = true;
            this.rbTKOPlayerOne.Location = new System.Drawing.Point(587, 82);
            this.rbTKOPlayerOne.Name = "rbTKOPlayerOne";
            this.rbTKOPlayerOne.Size = new System.Drawing.Size(57, 24);
            this.rbTKOPlayerOne.TabIndex = 8;
            this.rbTKOPlayerOne.TabStop = true;
            this.rbTKOPlayerOne.Text = "TKO";
            this.rbTKOPlayerOne.UseVisualStyleBackColor = true;
            this.rbTKOPlayerOne.CheckedChanged += new System.EventHandler(this.rbTKOPlayerOne_CheckedChanged);
            // 
            // rbTKOPlayerTwo
            // 
            this.rbTKOPlayerTwo.AutoSize = true;
            this.rbTKOPlayerTwo.Location = new System.Drawing.Point(587, 164);
            this.rbTKOPlayerTwo.Name = "rbTKOPlayerTwo";
            this.rbTKOPlayerTwo.Size = new System.Drawing.Size(57, 24);
            this.rbTKOPlayerTwo.TabIndex = 9;
            this.rbTKOPlayerTwo.TabStop = true;
            this.rbTKOPlayerTwo.Text = "TKO";
            this.rbTKOPlayerTwo.UseVisualStyleBackColor = true;
            this.rbTKOPlayerTwo.CheckedChanged += new System.EventHandler(this.rbTKOPlayerTwo_CheckedChanged);
            // 
            // InputResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(666, 314);
            this.Controls.Add(this.rbTKOPlayerTwo);
            this.Controls.Add(this.rbTKOPlayerOne);
            this.Controls.Add(this.rbKOPlayerTwo);
            this.Controls.Add(this.rbKOPlayerOne);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPlayerTwo);
            this.Controls.Add(this.lblPlayerOne);
            this.Controls.Add(this.tbPlayerTwo);
            this.Controls.Add(this.tbPlayerOne);
            this.Controls.Add(this.btnSubmitResults);
            this.Name = "InputResults";
            this.Text = "InputResults";
            this.Load += new System.EventHandler(this.InputResults_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSubmitResults;
        private TextBox tbPlayerOne;
        private TextBox tbPlayerTwo;
        private Label lblPlayerOne;
        private Label lblPlayerTwo;
        private Label label3;
        private RadioButton rbKOPlayerOne;
        private RadioButton rbKOPlayerTwo;
        private RadioButton rbTKOPlayerOne;
        private RadioButton rbTKOPlayerTwo;
    }
}