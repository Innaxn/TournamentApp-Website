using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToornamentWeb.Pages
{
    public class PassedModel : PageModel
    {
        public Toornament toornament = new Toornament();
        public IEnumerable<Tournament> Tournaments { get; set; }
        public int signed { get; set; }

        public void OnGet()
        {
            Tournaments = toornament.TournamentServices.GetTournamentsByStatus(TournamentStatus.FINISHED);
            foreach (var item in Tournaments)
            {
                signed = toornament.TournamentServices.GetCountOfCurrent(item.Id);
            }
           
        }
    }
}
