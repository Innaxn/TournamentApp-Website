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
    public partial class DetailsTournament : Form
    {
        Tournament t;
        Toornament toornament = new();
        List<Game> games = new List<Game>();
        bool isPending;

        public DetailsTournament(Tournament t)
        {
            InitializeComponent();
            this.t = t;
            SetValue(t);
            if (t.Status == TournamentStatus.INPROGRESS)
            {
                btnGenerateSchedule.Visible = true;
                flowLayoutGames.Visible = true;
                cbPlayers.Visible = true;
                btnShowGames.Visible = true;
                lbGames.Visible = true;
            }
            else if (t.Status == TournamentStatus.FINISHED)
            {
                flowLayoutGames.Visible = true;
                cbPlayers.Visible = true;
                btnShowGames.Visible = true;
                lbGames.Visible = true;
            }
            else if (t.Status == TournamentStatus.PENDING)
            {
                btnGenerateSchedule.Visible = true;
                flowLayoutGames.Visible = true;
                cbPlayers.Visible = true;
                btnShowGames.Visible = true;
                lbGames.Visible = true;

                isPending = true;
            }

            
        }
        private void DetailsTournament_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            cbPlayers.DataSource = toornament.PersonServices.GetSignedPlayersForTournament(t.Id);
            cbPlayers.DisplayMember = "Name";
        }

        public void SetValue(Tournament t)
        {
            lblAddress.Text = $"Address: {t.Address}";
            lblCity.Text = $"City: {t.City}";
            lblMax.Text = $"Max: {t.MaxParticipants}";
            lblMin.Text = $"Min: {t.MinParticipants}";
            lblDescription.Text = $"Description: { t.Description}";
            lblEnd.Text = $"End date: {t.EndDate.ToShortDateString()}";
            lblStart.Text = $"Start date: {t.StartDate.ToShortDateString()}";
            lblStatus.Text = $"Status: {t.Status}";

            lblDescription.MaximumSize = new Size(400, 0);
            int count = toornament.TournamentServices.GetCountOfCurrent(t.Id);
            lblSignedPlayers.Text = $"Players in the tournamnet: {count}";
            foreach (var item in toornament.PersonServices.GetSignedPlayersForTournament(t.Id))
            {
                lbPlayers.Items.Add(item);
            }

            
            //bool check = IsCountGamesExisting();
            //if (check)
            //{
            //    foreach (var item in toornament.TournamentServices.)
            //    {
            //        lbGames.Items.Add(item);
            //    }
            //}
        }

        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                toornament.TournamentServices.GenerateCreateGamesRoundRobin(t);
                //lbGames.DataSource = toornament.GameServices.GetGamesByTournamentId(t.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadGames()
        {
            flowLayoutGames.Controls.Clear();
            Player p = (Player)cbPlayers.SelectedItem;
            games = toornament.GameServices.GetGamesByPlayerAndTournamentId(t, p.Id);


            foreach (Game item in games)
            {
                GamePV g = new GamePV();
                g.SetForm(item, isPending);

                flowLayoutGames.Controls.Add(g);
            }
        }
        private void btnShowGames_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGames();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
