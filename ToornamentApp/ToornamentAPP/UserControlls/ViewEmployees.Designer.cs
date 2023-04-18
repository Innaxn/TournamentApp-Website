namespace ToornamentAPP.UserControlls
{
    partial class ViewEmployees
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
            this.flpEmployee = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpEmployee
            // 
            this.flpEmployee.AutoScroll = true;
            this.flpEmployee.BackColor = System.Drawing.Color.DarkCyan;
            this.flpEmployee.Location = new System.Drawing.Point(20, 79);
            this.flpEmployee.Name = "flpEmployee";
            this.flpEmployee.Size = new System.Drawing.Size(890, 507);
            this.flpEmployee.TabIndex = 0;
            this.flpEmployee.Paint += new System.Windows.Forms.PaintEventHandler(this.flpEmployee_Paint);
            // 
            // ViewEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpEmployee);
            this.Name = "ViewEmployees";
            this.Size = new System.Drawing.Size(958, 613);
            this.Load += new System.EventHandler(this.ViewEmployees_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flpEmployee;
    }
}
