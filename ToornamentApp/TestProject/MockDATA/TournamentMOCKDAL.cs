using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MockDATA
{
    public class TournamentMOCKDAL : ITournament
    {
        static DateTime n = new DateTime(2023, 6, 1);
        static DateTime r = new DateTime(2023, 6, 29);
        static DateTime start = new DateTime(2023, 5, 5);
        static DateTime end = new DateTime(2023, 8, 8);
        static ISportType _sport = new Badminton();
        TournamentRoundRobin actual = new TournamentRoundRobin(2, _sport, "descr", n, r, 3, 5, "eindhoven", "adres", TournamentStatus.AVAILABLE);
        TournamentRoundRobin actual2 = new TournamentRoundRobin(3, _sport, "descri", n, r, 5, 10, "eindhoven", "adres", TournamentStatus.AVAILABLE);
        TournamentRoundRobin checkifInprogressError = new TournamentRoundRobin(7, _sport, "des", start, end, 2, 10, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
        public void ChangeStatus(int id, TournamentStatus s)
        {
            
        }

        public void CreateTournament(Tournament tournament)
        {

        }

        public void DeleteTournament(int id)
        {

        }

        public List<Tournament> GetAllAvailableTournamentsBySportId(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfCurrent(int tournamentId)
        {
            if (tournamentId == 9)
            {
                return 3;
            }
            else if (tournamentId == 11)
            {
                return 5;
            }
            return 0;
        }

        public int GetCountOfGamesByTournamentId(int tournamentId)
        {
            if (tournamentId == 5)
            {
                return 5;
            }
            return 0;
        }

        public List<Tournament> GetTournamentsByPlayerId(int id)
        {
            List<Tournament> tournaments = new List<Tournament>();
            if (id == 6)
            {
                tournaments.Add(actual);
                tournaments.Add(actual2);

                return tournaments;
            }
            return tournaments;
        }

        public List<Tournament> GetTournamentsByStatus(TournamentStatus status)
        {
            List<Tournament> tournaments = new List<Tournament>();
            if (status is TournamentStatus.AVAILABLE)
            {
                tournaments.Add(actual);
                tournaments.Add(actual2);

                return tournaments;
            }
            return tournaments;
        }

        public Tournament GetTournamnetById(int id)
        {
            DateTime startDate = new DateTime(2023, 5, 5);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();
            TournamentRoundRobin tournament = new TournamentRoundRobin(9, _sport, "des", startDate, endDate, 3, 10, "ssss", "Rotterdam", TournamentStatus.AVAILABLE); 
            if (id == 2)
            {
                return actual;
            }
            else if (id == 9)
            {
                return tournament;
            }else if (id == 7)
            {
                return checkifInprogressError;
            }
            TournamentRoundRobin t = new TournamentRoundRobin();
            return t;
        }

        public bool IsSignedUp(int tournamentId, int playerId)
        {
            if (tournamentId == 2 && playerId == 2)
            {
                return true;
            }
            return false;
        }

        public void SignInForTournament(int tournamentId, int playerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateTournament(Tournament tournament)
        {
            throw new NotImplementedException();
        }
    }
}
