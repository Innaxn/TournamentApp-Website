using ClassLibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToornamentWeb.Pages
{
    public class TournamentViewModel : PageModel
    {
        public Toornament toornament = new Toornament();
        public Person p = new Player();
        [BindProperty(Name = "tournamentid", SupportsGet = true)]
        public int tournamentid { get; set; }
        public bool isSigned;
        public int count { get; set; }
        public DateTime deadline { get; set; }
        public bool IsDeadlineReached = false;

        public Tournament t { get; set; }
        public void OnGet()
        {
            t = toornament.TournamentServices.GetTournamentById(tournamentid);
            count = toornament.TournamentServices.GetCountOfCurrent(tournamentid);
            if (User.Identity.IsAuthenticated)
            {
                int id = Convert.ToInt32(User.FindFirst("id").Value);
                p = toornament.PersonServices.GetPersonById(id);
                t = toornament.TournamentServices.GetTournamentById(tournamentid);
                isSigned = toornament.TournamentServices.IsSignedUp(tournamentid, id);
            }

            deadline = t.StartDate.AddDays(-7);
            if (deadline < DateTime.Now)
            {
                IsDeadlineReached = true;
            }
            
        }

        public IActionResult OnPost()
        {
            if(User.Identity.IsAuthenticated)
            {
                t = toornament.TournamentServices.GetTournamentById(tournamentid);

                int id = Convert.ToInt32(User.FindFirst("id").Value);
                p = toornament.PersonServices.GetPersonById(id);

                toornament.TournamentServices.SignInForTournament(tournamentid, id);
                return RedirectToPage("AvailableTournaments");
            }
            else
            {
                return RedirectToPage("Login");
            }
        }
    }
}
