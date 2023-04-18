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
    public partial class EmployeePV : UserControl
    {
        public Person holdPerson;
        private static EmployeePV _instance;
        Toornament t;
        public static EmployeePV Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeePV(null);
                }
                return _instance;
            }
        }

        public EmployeePV(Person p)
        {
            InitializeComponent();
            holdPerson = p;
            SetForm(p);
            t = new Toornament();
        }

        public void SetForm(Person p)
        {
            lblEmail.Text = $"Email: {p.Email}";
            lblName.Text = $"Name:  {p.FirstName} {p.LastName}";
            lblPhone.Text = p.Phone;

            holdPerson = p;
        }

        private void EmployeePV_Load(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You are going to delete this person! Are you sure you want to delete it?", "Delete user", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                t.PersonServices.DeletePerson(holdPerson);
                ViewEmployees.Instance.LoadCurrentPeople(EmployeeRole.ORGANIZER);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            ViewEmployees.Instance.LoadCurrentPeople(EmployeeRole.ORGANIZER);
        }
    }
}
