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
    public partial class Tournaments : UserControl
    {
        private static Tournaments _instance;
        public List<Tournament> tournamnets = new List<Tournament>();
        private Toornament t = new Toornament();

        public static Tournaments Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Tournaments();
                }
                return _instance;
            }
        }
        public Tournaments()
        {
            InitializeComponent();
        }

        public void LoadCurrentTournamnets(TournamentStatus s)
        {
            flowLayoutTournaments.Controls.Clear();
            tournamnets = t.TournamentServices.GetTournamentsByStatus(s);

            foreach (TournamentRoundRobin item in tournamnets)
            {
                TournamentPV u = new TournamentPV(item);

                flowLayoutTournaments.Controls.Add(u);
            }
        }

        public void StatusChange()
        {
            if (rbAvailable.Checked)
            {
                LoadCurrentTournamnets(TournamentStatus.AVAILABLE);
            }
            else if (rbCancelled.Checked)
            {
                LoadCurrentTournamnets(TournamentStatus.CANCELLED);
            }
            else if (rbFinished.Checked)
            {
                LoadCurrentTournamnets(TournamentStatus.FINISHED);
            }
            else if (rbInProgress.Checked)
            {
                LoadCurrentTournamnets(TournamentStatus.INPROGRESS);
            }
            else if (rbPending.Checked)
            {
                LoadCurrentTournamnets(TournamentStatus.PENDING);
            }
        }
        private void Tournaments_Load(object sender, EventArgs e)
        {
            //t.TournamentServices.CheckIfPending_Cancelled();
            t.TournamentServices.CheckIfFinished();
            StatusChange();
        }

        private void rbCancelled_CheckedChanged(object sender, EventArgs e)
        {
            StatusChange();
        }

        private void rbFinished_CheckedChanged(object sender, EventArgs e)
        {
            StatusChange();
        }

        private void rbPending_CheckedChanged(object sender, EventArgs e)
        {
            StatusChange();
        }

        private void rbInProgress_CheckedChanged(object sender, EventArgs e)
        {
            StatusChange();
        }

        private void rbAvailable_CheckedChanged(object sender, EventArgs e)
        {
            StatusChange();
        }

        private void btnSearchBySport_Click(object sender, EventArgs e)
        {
            List<Tournament> tournaments;
            if (cbSportType.SelectedIndex == 0)
            {
                tournaments = t.TournamentServices.GetAllAvailableTournamentsBySportId(1);
                flowLayoutTournaments.Controls.Clear();

                foreach (var item in tournaments)
                {
                    TournamentPV t = new TournamentPV(item);

                    flowLayoutTournaments.Controls.Add(t);
                }
            }
            else if (cbSportType.SelectedIndex == 1)
            {
                tournaments = t.TournamentServices.GetAllAvailableTournamentsBySportId(2);
                flowLayoutTournaments.Controls.Clear();

                foreach (var item in tournaments)
                {
                    TournamentPV t = new TournamentPV(item);

                    flowLayoutTournaments.Controls.Add(t);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //t.TournamentServices.CheckIfPending_Cancelled();
            t.TournamentServices.CheckIfFinished();
        }
    }
}
