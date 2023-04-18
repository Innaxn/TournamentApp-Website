using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToornamentAPP.UserControlls;

namespace ToornamentAPP.Forms
{
    public partial class Home : Form
    {
        private static Home _instance = null;
        public Person cUser = new Employee();
        public static Home Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }
        public Home(Person employee)
        {
            InitializeComponent();
            HideSubmenus();
            cUser = employee;
        }
        //public Home()
        //{
        //    InitializeComponent();
        //    HideSubmenus();
            
        //}
        private void HideSubmenus()
        {
            panelTournament.Visible = false;
            panelEmployee.Visible = false;
        }
        private void HideSubMenu()
        {
            if (panelTournament.Visible == true)
            {
                panelTournament.Visible = false;
            }
            if (panelEmployee.Visible == true)
            {
                panelEmployee.Visible = false;
            }
        }

        private void ShowSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                HideSubMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private void btnTournament_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelTournament);
        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(Create.Instance))
            {
                mainPanel.Controls.Add(Create.Instance);
                Create.Instance.Dock = DockStyle.Fill;
                Create.Instance.BringToFront();
            }
            else
                Create.Instance.BringToFront();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (((Employee)cUser).Role == EmployeeRole.ORGANIZER)
            {
                panelEmployee.Hide();
                btnEmployee.Hide();
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelEmployee);
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(AddEmployee.Instance))
            {
                mainPanel.Controls.Add(AddEmployee.Instance);
                AddEmployee.Instance.Dock = DockStyle.Fill;
                AddEmployee.Instance.BringToFront();
            }
            else
                AddEmployee.Instance.BringToFront();
        }

        private void btnViewAllEmployee_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(ViewEmployees.Instance))
            {
                mainPanel.Controls.Add(ViewEmployees.Instance);
                ViewEmployees.Instance.Dock = DockStyle.Fill;
                ViewEmployees.Instance.BringToFront();
            }
            else
                ViewEmployees.Instance.BringToFront();
                ViewEmployees.Instance.LoadCurrentPeople(EmployeeRole.ORGANIZER);
        }

        private void btnViewT_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(Tournaments.Instance))
            {
                mainPanel.Controls.Add(Tournaments.Instance);
                Tournaments.Instance.Dock = DockStyle.Fill;
                Tournaments.Instance.BringToFront();
                Tournaments.Instance.StatusChange();
            }
            else
                Tournaments.Instance.BringToFront();
        }
    }
}
