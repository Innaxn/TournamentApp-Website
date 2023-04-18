using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.LogicLayer
{
    public class TournamentServices
    {
        private ITournament itournament;
        public TournamentServices(ITournament dalTournament)
        {
            itournament = dalTournament;
        }
        public void CreateTournament(Tournament tournament)
        {
            if (!tournament.IsDateCorrect() && !tournament.IsAmountOfPlayersCorrect())
            {
                throw new IncorrectAmountAndDates();
            }
            else if (!tournament.IsAmountOfPlayersCorrect())
            {
                throw new IsAmountOfPlayersIncorrect();
            }
            else if (!tournament.IsDateCorrect())
            {
                throw new IncorectDateException(DateTime.Now, tournament.StartDate);
            }
            else
            {
                itournament.CreateTournament(tournament);
            }
        }

        public void DeleteTournament(int id)
        {
            try
            {
                itournament.DeleteTournament(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTournament(Tournament tournament)
        {
            if (!tournament.IsDateCorrectForUpdate() && !tournament.IsAmountOfPlayersCorrect() /*&& !IsStatusNotAvailable(tournament)*/ && IsAmountOfSignedPlayersBiggerThanUpdate(tournament))
            {
                throw new IncorrectAmountAndDates();
            }
            else if (!tournament.IsAmountOfPlayersCorrect())
            {
                throw new IsAmountOfPlayersIncorrect();
            }
            else if (!tournament.IsDateCorrectForUpdate())
            {
                throw new IncorrectDateUpdate(tournament.StartDate, tournament.EndDate);
            }
            else if (IsAmountOfSignedPlayersBiggerThanUpdate(tournament))
            {
                int count = GetCountOfCurrent(tournament.Id);
                throw new IncorrectAmountOfSignedPlayers(count);
            }
            else
            {
                itournament.UpdateTournament(tournament);
            }
        }
        public Tournament GetTournamentById(int id)
        {
            return itournament.GetTournamnetById(id);
        }

        public List<Tournament> GetTournamentsByPlayerId(int id)
        {
            List<Tournament> t = itournament.GetTournamentsByPlayerId(id);
            return t;
        }

        public List<Tournament> GetTournamentsByStatus(TournamentStatus s)
        {
            List<Tournament> t = itournament.GetTournamentsByStatus(s);
            return t;
        }
        public List<Tournament> GetAllAvailableTournamentsBySportId(int id)
        {
            List<Tournament> t = itournament.GetAllAvailableTournamentsBySportId(id);
            return t;
        }

        public void ChangeStatus(int id, TournamentStatus s)
        {
            itournament.ChangeStatus(id, s);
        }


        public bool IsAmountOfSignedPlayersBiggerThanUpdate(Tournament t)
        {
            int count = GetCountOfCurrent(t.Id);
            if (count > t.MaxParticipants || count > t.MinParticipants)
            {
                return true;
            }
            return false;
        }

        public void SignInForTournament(int tournamentId, int playerId)
        {
            itournament.SignInForTournament(tournamentId, playerId);
        }

        public bool IsSignedUp(int tournamentId, int playerId)
        {
            if (itournament.IsSignedUp(tournamentId, playerId))
            {
                return true;
            }
            return false;
        }
        public int GetCountOfCurrent(int tournamentId)
        {
            int count = itournament.GetCountOfCurrent(tournamentId);
            return count;
        }

        public int GetCountOfGamesByTournamentId(int tournamentId)
        {
            int count = itournament.GetCountOfGamesByTournamentId(tournamentId);
            return count;
        }

        public void CheckIfPending(Tournament tournament) //buton gotovo
        {
            int current = GetCountOfCurrent(tournament.Id);
            int days = tournament.CalculateDateDifference();
            if ((tournament.MaxParticipants == current && DateTime.Now < tournament.StartDate) /*|| (tournament.MinParticipants <= current && days <= 7*/)
            {
                ChangeStatus(tournament.Id, TournamentStatus.PENDING);
            }
            else
            {
                throw new PedingException();
            }
        }

        public void CheckIfFinished() //automatic when you run the app/makes check
        {
            List<Tournament> tournaments = itournament.GetTournamentsByStatus(TournamentStatus.INPROGRESS);
            foreach (var item in tournaments)
            {
                if (item.EndDate <= DateTime.Now)
                {
                    ChangeStatus(item.Id, TournamentStatus.FINISHED);
                }
            }
        }

        public void CheckIfInprogress(Tournament tournament) //button
        {
            int current = GetCountOfCurrent(tournament.Id);
            if (tournament.StartDate < DateTime.Now && current >= tournament.MinParticipants)
            {
                ChangeStatus(tournament.Id, TournamentStatus.INPROGRESS);
            }
            else
            {
                throw new InprogressNotPossible();
            }
        }

        public bool IsCountGamesExisting(int id)
        {
            int count = GetCountOfGamesByTournamentId(id);
            if (count <= 0)
            {
                return false;
            }
            return true;
        }

        public void GenerateCreateGamesRoundRobin(Tournament t)
        {
            Toornament toornament = new Toornament();
            List<Game> games = new List<Game>();
            bool check = IsCountGamesExisting(t.Id);
            if (check)
            {
                throw new GenerateGamesError();
            }
            else
            {
                List<Player> players = toornament.PersonServices.GetSignedPlayersForTournament(t.Id);
                games = t.GenerateGames(players);
                toornament.GameServices.CreateGames(games);
            }
        }
    }
}
