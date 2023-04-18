using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class GameBadminton:Game
    {
        public GameBadminton(int id, int idTournament, Player player1, Player player2):base(id, idTournament, player1, player2)
        {
        }

        public GameBadminton(int idTournament, Player player1, Player player2):base(idTournament, player1,player2)
        {
        }
        public GameBadminton():base() { }
        public GameBadminton(int id, int idTournament, Player player1, Player player2, int pointsOne, int pointsTwo, Player winner) : base(id, idTournament, player1, player2, pointsOne, pointsTwo, winner)
        {
        }

        public GameBadminton(int id, int idTournament, Player player1, Player player2, int pointsOne, int pointsTwo) : base(id, idTournament, player1, player2, pointsOne, pointsTwo)
        {
        }

        

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
    }
}
