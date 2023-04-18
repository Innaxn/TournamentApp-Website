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
using ToornamentAPP.Forms;

namespace ToornamentAPP.UserControlls
{
    public partial class GamePV : UserControl
    {
        public Game holdGame;
        private static GamePV _instance;
        Toornament t;
        public static GamePV Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GamePV();
                }
                return _instance;
            }
        }
        public GamePV()
        {
            InitializeComponent();
            t = new Toornament();
        }

        public void SetForm(Game g, bool isPending)
        {
            //TODO--DISPLAY games properly   
            lblPlayerOne.Text = $"N1:{g.Player1.FirstName} {g.Player1.LastName}";
            lblPlayerTwo.Text = $"N2:{g.Player2.FirstName} {g.Player2.LastName}";

            if (g.Winner != null)
            {
                if (g is GameBoxing)
                {
                    GameBoxing boxing = (GameBoxing)g;
                    lblWinner.Text = $"Winner:{g.Winner} by {boxing.Way}";
                }
                else
                {
                    lblWinner.Text = $"Winner:{g.Winner}";
                }

                if (g.ParticipantOnePoints != null)
                {
                    lblOnePoints.Text = $"{g.ParticipantOnePoints}";
                    lblTwoPoints.Text = g.ParticipantTwoPoints.ToString();
                }
             
               btnResults.Visible = false;
            }
            else if (g.Winner == null)
            {
                lblOnePoints.Visible = false;
                lblTwoPoints.Visible = false;
                lblWinner.Visible = false;
            }

            holdGame = g;

            if (isPending)
            {
                btnResults.Visible = false;
            }
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            this.Hide();
            InputResults r = new InputResults(holdGame);
            r.ShowDialog();
            //Tournaments.Instance.LoadCurrentTournamnets(hol.Status);
        }
    }
}
