using ClassLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ToornamentWeb.Pages
{
    public class RegisterModel : PageModel
    {
        public Toornament toornament {get; set;}
        public Person person;

        [BindProperty]
        [Required]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        public string LastName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please input a username.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Please input a username with atleast 6 characters.")]
        public string Username { get; set; }

        [BindProperty]
        [Required]
        [StringLength(6, ErrorMessage = "Please input a password with atleast 6 characters.")]
        public string Password { get; set; }

        [BindProperty]
        [Required]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string PhoneNumber { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            toornament = new Toornament();
            person = new Player();
            bool isUsernameTaken = toornament.PersonServices.IsUsernameTaken(Username);
            bool IsPhoneValid = person.IsValidPhone(PhoneNumber);
            bool IsEmailValid = person.IsEmailValid(Email);
            bool IsEmailTaken = toornament.PersonServices.IsEmailTaken(Email);
            if (ModelState.IsValid /*&& (user.Password == ConfirmPassword)*/)
            {
                Player p = new Player(FirstName, LastName, Password, Email, PhoneNumber, Username);
               // bool success = toornament.PersonServices.Registration(p);
                if (!IsPhoneValid)
                {
                    ModelState.AddModelError("Unique phone", "This phone is not correct, try again.");
                    return Page();
                }
                else if (isUsernameTaken)
                {
                    ModelState.AddModelError("Unique username", "This username is taken, try again.");
                    return Page();
                }
                else if (!IsEmailValid)
                {
                    ModelState.AddModelError("Unique email", "This email is not correct, try again.");
                    return Page();
                }
                else if(IsEmailTaken)
                {
                    ModelState.AddModelError("Unique emailaddress", "This email is taken, try again.");
                    return Page();
                }
                else
                {
                    toornament.PersonServices.Registration(p);
                    return RedirectToPage("Index");
                }
            }
            return Page();
        }

    }
}
