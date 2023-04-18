using ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IGame
    {
        void CreateGame(List<Game> games);
        List<Game> GetGamesByPlayerAndTournamentId(Tournament t, int playerId);
        //void InputResultsBadminton(Game game);
        //List<Game> GetGamesByTournamentId(int tournamentId);
        int CalculateWins(int playerId, int tournamentId);
        void InputResult(Game game);

    }
}
