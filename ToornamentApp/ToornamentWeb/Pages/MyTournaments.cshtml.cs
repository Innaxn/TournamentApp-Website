using ClassLibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToornamentWeb.Pages
{
    [Authorize]
    public class MyTournamentsModel : PageModel
    {
        public Toornament toornament = new Toornament();
        public Person p = new Player();

        public List<Tournament> Tournaments { get; set; }

        public void OnGet()
        {
            int id = Convert.ToInt32(User.FindFirst("id").Value);
            p = toornament.PersonServices.GetPersonById(id); 
            Tournaments = toornament.TournamentServices.GetTournamentsByPlayerId(id);
        }
    }
}
