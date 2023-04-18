using ClassLibrary.Entities;
using ClassLibrary.LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToornamentWeb.Pages
{
    public class ViewInfoPassedModel : PageModel
    {
        public Toornament toornament = new Toornament();
        public Leaderboard l = new Leaderboard();
        public Tournament t { get; set; }
        [BindProperty(Name = "tournamentid", SupportsGet = true)]
        public int tournamentid { get; set; }
        [BindProperty(Name = "playerId", SupportsGet = true)]
        public int playerId { get; set; }
        public int signedPlayers { get; set; }
        public Game game { get; set; }
        public List<Player> players { get; set; }
        public Player player { get; set; }
        public List<Game> games = new List<Game>();
        public Tuple<List<Player>, List<int>> leader { get; set; }
        public void OnGet()
        {
            t = toornament.TournamentServices.GetTournamentById(tournamentid);
            signedPlayers = toornament.TournamentServices.GetCountOfCurrent(tournamentid);
            players = toornament.PersonServices.GetSignedPlayersForTournament(tournamentid);
            List<int> wins = l.PlayerWins(tournamentid);
            leader = l.SortPosition(players, wins);
        }

        public void OnGetGamesByPlayer()
        {
            t = toornament.TournamentServices.GetTournamentById(tournamentid);
            players = toornament.PersonServices.GetSignedPlayersForTournament(tournamentid);
            //foreach (var p in players)
            //{
                games = toornament.GameServices.GetGamesByPlayerAndTournamentId(t, playerId);
            //}

            List<int> wins = l.PlayerWins(tournamentid);
            leader = l.SortPosition(players, wins);
        }
    

        public void OnPost()
        {
            t = toornament.TournamentServices.GetTournamentById(tournamentid);
            players = toornament.PersonServices.GetSignedPlayersForTournament(tournamentid);
            foreach (var p in players)
            {
                games = toornament.GameServices.GetGamesByPlayerAndTournamentId(t, p.Id);
            }
        }

        public int AddOne(int i)
        {
            return i+1;
        }
    }
}
