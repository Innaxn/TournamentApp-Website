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
    public partial class ViewEmployees : UserControl
    {
        private static ViewEmployees _instance;
        public List<Employee> people = new List<Employee>();
        private Toornament t = new Toornament();

        public static ViewEmployees Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewEmployees();
                }
                return _instance;
            }
        }

        public ViewEmployees()
        {
            InitializeComponent();
            LoadCurrentPeople(EmployeeRole.ORGANIZER);
        }

        public void LoadCurrentPeople(EmployeeRole r)
        {
            flpEmployee.Controls.Clear();
            people = t.PersonServices.GetEmployeesByRole(r);

            foreach (Person item in people)
            {
                EmployeePV u = new EmployeePV(item);

                flpEmployee.Controls.Add(u);
            }
        }

        private void ViewEmployees_Load(object sender, EventArgs e)
        {
            LoadCurrentPeople(EmployeeRole.ORGANIZER);
        }

        private void flpEmployee_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
