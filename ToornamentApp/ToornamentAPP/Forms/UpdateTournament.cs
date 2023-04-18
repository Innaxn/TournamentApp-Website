using ClassLibrary.Entities;
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
    public partial class UpdateTournament : Form
    {
        Tournament tournamentHolder;
        Toornament toornament = new();
        public UpdateTournament(Tournament t)
        {
            InitializeComponent();
            SetValues(t);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = startDate.Value;
                DateTime end = endDate.Value;
                string description = tbDescription.Text;
                int min = Convert.ToInt32(tbMin.Text);
                int max = Convert.ToInt32(tbMax.Text);
                string city = tbCity.Text;
                string address = tbAddress.Text;

                TournamentRoundRobin updatedTournament;
                updatedTournament = new TournamentRoundRobin(tournamentHolder.Id, tournamentHolder.SportType, description, start, end, min, max, city, address, tournamentHolder.Status);
                try
                {
                    toornament.TournamentServices.UpdateTournament(updatedTournament);
                    MessageBox.Show(this, "Sucessfully updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please follow the correct format!");
            }
        }

        public void SetValues(Tournament t)
        {
            tournamentHolder = t;

            tbAddress.Text = t.Address;
            tbCity.Text = t.City;
            tbDescription.Text = t.Description;
            tbMax.Text = t.MaxParticipants.ToString();
            tbMin.Text = t.MinParticipants.ToString();
            startDate.Value = t.StartDate;
            endDate.Value = t.EndDate;
            lblSport.Text = t.SportType.GetName();
        }
        private void ClearData()
        {
            tbAddress.Clear();
            tbCity.Clear();
            tbDescription.Clear();
            tbMax.Clear();
            tbMin.Clear();
            startDate.Value = DateTime.Now;
            endDate.Value = DateTime.Now;
        }

        private void UpdateTournament_Load(object sender, EventArgs e)
        {
        }
    }
}
