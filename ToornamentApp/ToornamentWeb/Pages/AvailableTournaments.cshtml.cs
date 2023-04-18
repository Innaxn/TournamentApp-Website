using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToornamentWeb.Pages
{
    public class AvailableTournamentsModel : PageModel
    {
        public Toornament toornament = new Toornament();
        public Person p = new Player();
        
        public List<Tournament> Tournaments { get; set; }
        
        public void OnGet()
        {
            Tournaments = toornament.TournamentServices.GetTournamentsByStatus(TournamentStatus.AVAILABLE);
        }
    }
}
