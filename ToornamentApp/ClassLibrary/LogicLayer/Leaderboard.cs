using ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.LogicLayer
{
    public class Leaderboard
    {
        public Toornament t = new Toornament();
        public Tuple<List<Player>, List<int>> playerPositions = new Tuple<List<Player>, List<int>>(new List<Player>(), new List<int>());


        //1.calculate wins per player in tournament
        public List<int> PlayerWins(int tournamentId)
        {
            List<int> playerWins = new List<int>();
            List<Player> players = t.PersonServices.GetSignedPlayersForTournament(tournamentId);
            foreach (var item in players)
            {
                playerWins.Add(t.GameServices.CalculateWins(item.Id, tournamentId)); //refactor if have time / opens many cons
            }
            return playerWins;
        }

        //2.bubble sort 
        public Tuple<List<Player>, List<int>> SortPosition(List<Player> players, List<int> wins)
        {
            for (int i = 0; i < wins.Count - 1; i++)
            {
                for (int j = 0; j < wins.Count - i - 1; j++)
                {

                    if (wins[j] < wins[j + 1])
                    {
                        int tempwin = wins[j];
                        wins[j] = wins[j + 1];
                        wins[j + 1] = tempwin;

                        Player tempPlayer = players[j];
                        players[j] = players[j + 1];
                        players[j + 1] = tempPlayer;
                    }
                }
            }
            return playerPositions = Tuple.Create(players, wins);
        }
    }
}



