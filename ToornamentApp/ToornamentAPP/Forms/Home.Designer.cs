namespace ToornamentAPP.Forms
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelEmployee = new System.Windows.Forms.Panel();
            this.btnViewAllEmployee = new System.Windows.Forms.Button();
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.panelTournament = new System.Windows.Forms.Panel();
            this.btnViewT = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnTournament = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelEmployee.SuspendLayout();
            this.panelTournament.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(205)))), ((int)(((byte)(198)))));
            this.panel1.Controls.Add(this.panelEmployee);
            this.panel1.Controls.Add(this.btnEmployee);
            this.panel1.Controls.Add(this.panelTournament);
            this.panel1.Controls.Add(this.btnTournament);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 717);
            this.panel1.TabIndex = 0;
            // 
            // panelEmployee
            // 
            this.panelEmployee.Controls.Add(this.btnViewAllEmployee);
            this.panelEmployee.Controls.Add(this.btnAddEmp);
            this.panelEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEmployee.Location = new System.Drawing.Point(0, 456);
            this.panelEmployee.Name = "panelEmployee";
            this.panelEmployee.Size = new System.Drawing.Size(213, 127);
            this.panelEmployee.TabIndex = 0;
            // 
            // btnViewAllEmployee
            // 
            this.btnViewAllEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(133)))));
            this.btnViewAllEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewAllEmployee.FlatAppearance.BorderSize = 0;
            this.btnViewAllEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAllEmployee.Location = new System.Drawing.Point(0, 65);
            this.btnViewAllEmployee.Name = "btnViewAllEmployee";
            this.btnViewAllEmployee.Size = new System.Drawing.Size(213, 62);
            this.btnViewAllEmployee.TabIndex = 2;
            this.btnViewAllEmployee.Text = "View employees";
            this.btnViewAllEmployee.UseVisualStyleBackColor = false;
            this.btnViewAllEmployee.Click += new System.EventHandler(this.btnViewAllEmployee_Click);
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(133)))));
            this.btnAddEmp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddEmp.FlatAppearance.BorderSize = 0;
            this.btnAddEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEmp.Location = new System.Drawing.Point(0, 0);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Size = new System.Drawing.Size(213, 65);
            this.btnAddEmp.TabIndex = 1;
            this.btnAddEmp.Text = "Add employee";
            this.btnAddEmp.UseVisualStyleBackColor = false;
            this.btnAddEmp.Click += new System.EventHandler(this.btnAddEmp_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(205)))), ((int)(((byte)(198)))));
            this.btnEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployee.FlatAppearance.BorderSize = 0;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.Location = new System.Drawing.Point(0, 383);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(213, 73);
            this.btnEmployee.TabIndex = 1;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // panelTournament
            // 
            this.panelTournament.Controls.Add(this.btnViewT);
            this.panelTournament.Controls.Add(this.btnCreate);
            this.panelTournament.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTournament.Location = new System.Drawing.Point(0, 249);
            this.panelTournament.Name = "panelTournament";
            this.panelTournament.Size = new System.Drawing.Size(213, 134);
            this.panelTournament.TabIndex = 0;
            // 
            // btnViewT
            // 
            this.btnViewT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(133)))));
            this.btnViewT.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewT.FlatAppearance.BorderSize = 0;
            this.btnViewT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewT.Location = new System.Drawing.Point(0, 65);
            this.btnViewT.Name = "btnViewT";
            this.btnViewT.Size = new System.Drawing.Size(213, 69);
            this.btnViewT.TabIndex = 1;
            this.btnViewT.Text = "View  tournaments";
            this.btnViewT.UseVisualStyleBackColor = false;
            this.btnViewT.Click += new System.EventHandler(this.btnViewT_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(133)))));
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(0, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(213, 65);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create tournament";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click_1);
            // 
            // btnTournament
            // 
            this.btnTournament.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(205)))), ((int)(((byte)(198)))));
            this.btnTournament.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTournament.FlatAppearance.BorderSize = 0;
            this.btnTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTournament.Location = new System.Drawing.Point(0, 183);
            this.btnTournament.Name = "btnTournament";
            this.btnTournament.Size = new System.Drawing.Size(213, 66);
            this.btnTournament.TabIndex = 0;
            this.btnTournament.Text = "Tournament";
            this.btnTournament.UseVisualStyleBackColor = false;
            this.btnTournament.Click += new System.EventHandler(this.btnTournament_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(213, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1157, 717);
            this.mainPanel.TabIndex = 1;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 717);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panelEmployee.ResumeLayout(false);
            this.panelTournament.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnTournament;
        private PictureBox pictureBox1;
        private Panel panelTournament;
        private Panel mainPanel;
        private Button btnViewT;
        private Button btnCreate;
        private Panel panelEmployee;
        private Button btnViewAllEmployee;
        private Button btnAddEmp;
        private Button btnEmployee;
    }
}