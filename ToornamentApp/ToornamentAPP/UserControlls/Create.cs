using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToornamentAPP.Forms;

namespace ToornamentAPP.UserControlls
{
    public partial class Create : UserControl
    {
        private static Create _instance;
        public Toornament toornament = new Toornament();
        public TournamentRoundRobin t = new TournamentRoundRobin();
        ISportType sportType;

        public static Create Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Create();
                }
                return _instance;
            }
        }
        public Create()
        {
            InitializeComponent();
            //userdal = new UserManager();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = startDate.Value;
                DateTime end = endDate.Value;
                string description = tbDescription.Text;
                string min = tbmin.Text;
                string max = tbmax.Text;
                int numberone;
                int numbertwo;
                bool isNumberValid = int.TryParse(min, out numberone);
                bool isNumberValidTwo = int.TryParse(max, out numbertwo);
                if (isNumberValid | isNumberValidTwo)
                {
                    int minimum = numberone;
                    int maximum = numbertwo;
                }
                else
                {
                    MessageBox.Show("Invalid input for min and max players, try again");
                    return;
                }
                string city = tbCity.Text;
                string address = tbAddress.Text;
                TournamentStatus status = TournamentStatus.AVAILABLE;
                // TODO - OO - Refactor to be more open/closed
                sportType = t.IdentifySportType(cbSport.SelectedIndex);
                //if (cbSport.SelectedIndex == 0)
                //{
                //    //SportId = 1;
                //    sportType =
                //    sportType = new Badminton();
                //}
                //else if (cbSport.SelectedIndex == 1)
                //{
                //    sportType = new Boxing();
                //}

                try
                {
                    t = new TournamentRoundRobin(sportType, description, start, end, numberone, numbertwo, city, address, status);
                    toornament.TournamentServices.CreateTournament(t);
                    MessageBox.Show(this, "Sucessfully created", "Added",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message);
                }
                ClearData();
            }
            catch (Exception)
            {
                MessageBox.Show("Please follow the correct format!");
            }
        }

        private void ClearData()
        {
            tbAddress.Clear();
            tbCity.Clear();
            tbDescription.Clear();
            tbmax.Clear();
            tbmin.Clear();
            startDate.Value = DateTime.Now;
            endDate.Value = DateTime.Now;
        }
    }
}
