using ClassLibrary.emunerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class GameBoxing : Game
    {
        private WayOfWinning way;
        public WayOfWinning Way { get { return way; } set { way = value; } }


        public GameBoxing(int id, int idTournament, Player player1, Player player2, int pointsOne, int pointsTwo, Player winner, WayOfWinning way) : base(id, idTournament, player1, player2, pointsOne, pointsTwo, winner)
        {
            this.way = way;
        }

        public GameBoxing(int id, int idTournament, Player player1, Player player2) : base(id, idTournament, player1, player2)
        {
        }

        public GameBoxing(int idTournament, Player player1, Player player2) : base(idTournament, player1, player2)
        {
        }
        public GameBoxing() : base() { }

        public GameBoxing(int id, int idTournament, Player player1, Player player2, int pointsOne, int pointsTwo) : base(id, idTournament, player1, player2, pointsOne, pointsTwo)
        {
        }

        //public override bool ValidateScore(int scoreOne, int scoreTwo)
        //{
        //    if (scoreOne != scoreTwo && scoreOne > 0 && scoreTwo > 0 && scoreTwo <= 120 && scoreOne <= 120)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public override void SetGameWinnerByPoints()
        {
            if (ParticipantOnePoints > ParticipantTwoPoints)
            {
                Winner = Player1;
            }
            else
            {
                Winner = Player2;
            }
        }

        public void SetGameWinnerTKO_KO(Player player, WayOfWinning way)
        {
            this.way = way;
            this.Winner = player;
        }
    }
}
