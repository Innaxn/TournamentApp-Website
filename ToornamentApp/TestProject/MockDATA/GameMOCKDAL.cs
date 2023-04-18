using ClassLibrary.Entities;
using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MockDATA
{
    public class GameMOCKDAL : IGame
    {
        static Player player1 = new Player(1, "sharenda", "peeters", "5422", "sharen@gmail.com", "0656263315", "sherry6");
        static Player player2 = new Player(2, "ivana", "nedelkova", "5422", "ivana@gmail.com", "0689563314", "innaxn");
        //static TournamentRoundRobin t = new TournamentRoundRobin(1);

        Game game1 = new GameBadminton(1, 1, player1, player2);
        Game game2 = new GameBoxing(2, 1, player1, player2);
        public int CalculateWins(int playerId, int tournamentId)
        {
            if (playerId == 1 && tournamentId == 1)
            {
                return 3;
            }
            else if (playerId == 7 && tournamentId == 1)
            {
                return 4;
            }
            return -1;
        }

        public void CreateGame(List<Game> games)
        {

        }

        public List<Game> GetGamesByPlayerAndTournamentId(Tournament t, int playerId)
        {
            List<Game> games = new List<Game>();
            if (t.Id == 1 && playerId == 1)
            {
                games.Add(game1);
                games.Add(game2);
                return games;
            }
            else if(t.Id == 1 && playerId == 2)
            {
                games.Add(game1);
                return games;
            }
            return games;
        }

        public List<Game> GetGamesByTournamentId(int tournamentId)
        {
            List<Game> games = new List<Game>();
            if (tournamentId == 1)
            {
                games.Add(game1);
                games.Add(game2);
                return games;
            }
            return games;
        }

        public void InputResult(Game game)
        {

            

        }

    }
}
