using ClassLibrary.emunerators;
using ClassLibrary.Entities;
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

namespace ToornamentAPP.Forms
{
    public partial class InputResults : Form
    {
        Game gameholder;
        Toornament toornament = new Toornament();
        Tournament tr;
        public InputResults(Game g)
        {
            InitializeComponent();
            SetInfo(g);
        }

        public void SetInfo(Game g)
        {
            gameholder = g;
            lblPlayerOne.Text = $"N1:{g.Player1.FirstName} {g.Player1.LastName}";
            lblPlayerTwo.Text = $"N2:{g.Player2.FirstName} {g.Player2.LastName}";
        }

        private void btnSubmitResults_Click(object sender, EventArgs e)
        {
            bool IsRbChecked = true;
            if (!String.IsNullOrEmpty(tbPlayerOne.Text) && !String.IsNullOrEmpty(tbPlayerTwo.Text))
            {
                string scoreone = tbPlayerOne.Text;
                string scoretwo = tbPlayerTwo.Text;
                int Scoreone;
                int Scoretwo;
                bool isNumberValid = int.TryParse(scoreone, out Scoreone);
                bool isNumberValidTwo = int.TryParse(scoretwo, out Scoretwo);
                if (isNumberValid | isNumberValidTwo)
                {
                    gameholder.ParticipantOnePoints = Scoreone;
                    gameholder.ParticipantTwoPoints = Scoretwo;
                    IsRbChecked = false;
                }
                else
                {
                    MessageBox.Show("Invalid input, try again");
                    return;
                }
            }
           
            tr = toornament.TournamentServices.GetTournamentById(gameholder.IdTournament);
            int counter = 0;

            if (gameholder is GameBoxing)
            {
                if (rbKOPlayerOne.Checked)
                {
                    counter = 1;
                }
                else if (rbTKOPlayerOne.Checked)
                {
                    counter = 2;
                }
                else if (rbKOPlayerTwo.Checked)
                {
                    counter = 3;
                }
                else if (rbTKOPlayerTwo.Checked)
                {
                    counter = 4;
                }

                if (IsRbChecked)
                {
                    toornament.GameServices.ValidateWinnerForBoxing(gameholder, counter);
                }
            }

            try
            {
                toornament.GameServices.ValidateScoreForAGame(tr, gameholder); 
                MessageBox.Show("Successfully added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InputResults_Load(object sender, EventArgs e)
        {
            tr = toornament.TournamentServices.GetTournamentById(gameholder.IdTournament);
            if (tr.SportType is Badminton)
            {
                rbKOPlayerOne.Visible = false;
                rbKOPlayerTwo.Visible = false;
                rbTKOPlayerOne.Visible = false;
                rbTKOPlayerTwo.Visible = false;
            }
        }

        private void rbKOPlayerOne_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKOPlayerOne.Checked)
            {
                tbPlayerOne.Enabled = false;
                tbPlayerTwo.Enabled = false;
            }
        }

        private void rbTKOPlayerOne_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTKOPlayerOne.Checked)
            {
                tbPlayerOne.Enabled = false;
                tbPlayerTwo.Enabled = false;
            }
        }

        private void rbKOPlayerTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTKOPlayerTwo.Checked)
            {
                tbPlayerOne.Enabled = false;
                tbPlayerTwo.Enabled = false;
            }
        }

        private void rbTKOPlayerTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTKOPlayerTwo.Checked)
            {
                tbPlayerOne.Enabled = false;
                tbPlayerTwo.Enabled = false;
            }
        }
    }
}
