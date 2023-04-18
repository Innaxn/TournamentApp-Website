using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public abstract class Game
    {
        private int id;
        private int idTournament; //int id!!
        private Player player1;
        private Player player2;
        private int participantOnePoints;
        private int participantTwoPoints;
        private Player winner;
        //private Player ko;
        //private Player tko;

        public int Id { get { return id; }}
        public int IdTournament { get { return idTournament; }}
        public int ParticipantOnePoints { get { return participantOnePoints; } set { participantOnePoints = value; } }
        public int ParticipantTwoPoints { get { return participantTwoPoints; } set { participantTwoPoints = value; } }
        public Player Player1 { get { return player1; } set { player1 = value; } }
        public Player Player2 { get { return player2; } set { player2 = value; } }
        public Player Winner { get { return winner; }set { winner = value; } }
        //public Player KO { get { return ko; } set { ko = value; } }
        //public Player TKO { get { return tko; } set { tko = value; } }

        public Game(int id, int idTournament, Player player1, Player player2)
        {
            this.id = id;
            this.idTournament = idTournament;
            this.player1 = player1;
            this.player2 = player2;
        }

        public Game(int idTournament, Player player1, Player player2)
        {
            this.idTournament = idTournament;
            this.player1 = player1;
            this.player2 = player2;
        }
        public Game(){}

        public Game(int id, int idTournament, Player player1, Player player2, int pointsOne, int pointsTwo, Player winner)
        {
            this.id = id;
            this.idTournament = idTournament;
            this.player1 = player1;
            this.player2 = player2;
            this.ParticipantOnePoints = pointsOne;
            this.ParticipantTwoPoints = pointsTwo;
            this.winner = winner;
        }

        public Game(int id, int idTournament, Player player1, Player player2, int pointsOne, int pointsTwo)
        {
            this.id = id;
            this.idTournament = idTournament;
            this.player1 = player1;
            this.player2 = player2;
            this.ParticipantOnePoints = pointsOne;
            this.ParticipantTwoPoints = pointsTwo;
        }

        public override string ToString()
        {
            return $"Game: player: {player1.FirstName}---against player:{player2.FirstName}";
        }

       //public abstract bool ValidateScore(int scoreOne, int scoreTwo);
       public abstract void SetGameWinnerByPoints();
    }
}
