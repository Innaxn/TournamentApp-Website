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

namespace ToornamentAPP.Forms
{
    public partial class Login : Form
    {
        public Toornament t;
        public Login()
        {
            InitializeComponent();
            t = new Toornament();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            Person person = t.PersonServices.Login(email, password);

            if (person != null)
            {
                    this.Hide();
                    Home h = new Home(person);
                    h.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }
    }
}
