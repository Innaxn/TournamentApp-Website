using ClassLibrary.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ToornamentWeb.Pages
{
    public class LoginModel : PageModel
    {
        public Toornament toornament { get; set; }
        [BindProperty]
        [Required]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            toornament = new Toornament();
            Person player = toornament.PersonServices.Login(Email, Password);

            if (ModelState.IsValid && player != null && player is Player)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("id", Convert.ToString(player.Id)));
                //claims.Add(new Claim("id", Convert.ToString(player.Username)));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return RedirectToPage("MyTournaments");
            }
            else
            {
                ModelState.AddModelError("Invalid", "This email or password are not correct, try again.");
                return Page();

            }
        }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
