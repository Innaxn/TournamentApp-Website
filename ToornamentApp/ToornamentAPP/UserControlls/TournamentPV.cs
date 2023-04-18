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
using ToornamentAPP.Forms;

namespace ToornamentAPP.UserControlls
{
    public partial class TournamentPV : UserControl
    {
        public Tournament holdTournament;
        private static TournamentPV _instance;
        Toornament t;
        public static TournamentPV Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TournamentPV(null);
                }
                return _instance;
            }
        }
        public TournamentPV(Tournament tour)
        {
            InitializeComponent();
            holdTournament = tour;
            SetForm(tour);
            t = new Toornament();
            if (holdTournament.Status == TournamentStatus.AVAILABLE)
            {
                btnMakeItCancelled.Visible = true;
                btnUpdate.Visible = true;
                btnInProgress.Visible = true;
                btnPending.Visible = true;
            }
            else if (holdTournament.Status == TournamentStatus.PENDING)
            {
                btnInProgress.Visible = true;
            }
        }

        public void SetForm(Tournament t)
        {
            lblEndDate.Text = $"End date: {t.EndDate.ToShortDateString()}";
            lblStartDate.Text = $"Start date: {t.StartDate.ToShortDateString()}";
            lblName.Text = $"Tournament: {t.SportType.GetName()}";
            lblId.Text = $"Id of tournament: {t.Id}";
            lblLocation.Text = $"Location: {t.City}";
            holdTournament = t;
        }
        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You are going to delete this tournamnet! Are you sure you want to delete it?", "Delete user", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                t.TournamentServices.DeleteTournament(holdTournament.Id);
                foreach (var item in Tournaments.Instance.tournamnets.ToList())
                {
                    t.TournamentServices.DeleteTournament(holdTournament.Id);
                    if (item == holdTournament)
                    {
                        Tournaments.Instance.tournamnets.Remove(item);
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            Tournaments.Instance.LoadCurrentTournamnets(holdTournament.Status);
        }

        private void btnMakeItCancelled_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You are going to change the status of this tournamnet! Are you sure you want to do it?", "Cancell", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                t.TournamentServices.ChangeStatus(holdTournament.Id, TournamentStatus.CANCELLED);
                MessageBox.Show("Successfully changed status to cancelled");
                Tournaments.Instance.LoadCurrentTournamnets(holdTournament.Status);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            Tournaments.Instance.LoadCurrentTournamnets(holdTournament.Status);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            DetailsTournament d = new DetailsTournament(holdTournament);
            d.ShowDialog();
            Tournaments.Instance.LoadCurrentTournamnets(holdTournament.Status);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateTournament t = new UpdateTournament(holdTournament);
            t.ShowDialog();
            Tournaments.Instance.LoadCurrentTournamnets(holdTournament.Status);
        }

        private void TournamentPV_Load(object sender, EventArgs e)
        {

        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You are going to change the status of this tournamnet! Are you sure you want to do it?", "Cancel", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    t.TournamentServices.CheckIfPending(holdTournament);
                    MessageBox.Show("Successfully changed status to pending");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Tournaments.Instance.LoadCurrentTournamnets(holdTournament.Status);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            Tournaments.Instance.LoadCurrentTournamnets(holdTournament.Status);
        }

        private void btnInProgress_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You are going to change the status of this tournamnet! Are you sure you want to do it?", "Cancell", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    t.TournamentServices.CheckIfInprogress(holdTournament);
                    MessageBox.Show("Successfully changed status to inprogress");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Tournaments.Instance.LoadCurrentTournamnets(holdTournament.Status);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            Tournaments.Instance.LoadCurrentTournamnets(holdTournament.Status);
        }
    }
}
