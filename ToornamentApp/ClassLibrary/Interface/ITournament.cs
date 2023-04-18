using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface ITournament
    {
        void CreateTournament(Tournament tournament);
        void DeleteTournament(int id);
        void UpdateTournament(Tournament tournament);
        Tournament GetTournamnetById(int id);
        List<Tournament> GetTournamentsByPlayerId(int id);
        void ChangeStatus(int id, TournamentStatus s);
        List<Tournament> GetTournamentsByStatus(TournamentStatus status);
        void SignInForTournament(int tournamentId, int playerId);
        bool IsSignedUp(int tournamentId, int playerId);
        int GetCountOfCurrent(int tournamentId);
        int GetCountOfGamesByTournamentId(int tournamentId);
        List<Tournament> GetAllAvailableTournamentsBySportId(int id);
    }
}
