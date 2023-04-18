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

namespace ToornamentAPP.UserControlls
{
    public partial class AddEmployee : UserControl
    {
        public Toornament t = new Toornament();
        private static AddEmployee _instance;
        public static AddEmployee Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AddEmployee();
                }
                return _instance;
            }
        }
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            EmployeeRole[] roles = new EmployeeRole[2];
            roles[0] = EmployeeRole.ADMIN;
            roles[1] = EmployeeRole.ORGANIZER;
            cbRole.DataSource = roles;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = tbFirstName.Text;
                string lname = tbLastName.Text;
                string email = tbEmail.Text;
                string password = tbPassword.Text;
                string phone = tbPhone.Text;
                EmployeeRole r = (EmployeeRole)cbRole.SelectedValue;

                try
                {
                    Person emp = new Employee(fname, lname, password, email, phone, r);
                    t.PersonServices.Registration(emp);
                    MessageBox.Show("Successfully added!");
                    ClearData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ClearData()
        {
            tbEmail.Text = "";
            tbPassword.Text = "";
            tbLastName.Text = "";
            tbFirstName.Text = "";
            tbPhone.Text = "";
        }
    }
}
