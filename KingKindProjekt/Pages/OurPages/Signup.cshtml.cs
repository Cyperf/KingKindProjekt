using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KingKindProjekt.Pages.OurPages
{
    public class SignupModel : PageModel
    {
        private AccountService _accountService;
        [BindProperty]
        public Account _Account { get; set; }
        [Display(Name = "First name")]
        [BindProperty]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [BindProperty]
        public string LastName { get; set; }
        [Display(Name = "Country code")]
        [BindProperty]
        public int CountryCode { get; set; }
        [Display(Name = "Phone number")]
        [BindProperty]
        public int PhoneNumber { get; set; }
        [Display(Name = "Accept")]
        [BindProperty]
        public bool AcceptTermsAndConditions { get; set; }



        // extra
        [Display(Name = "Extra info")]
        [BindProperty]
        public string ExtraInfo { get; set; }
        [Display(Name = "Post number")]
        [BindProperty]
        public int PostNumber { get; set; }
        [Display(Name = "City")]
        [BindProperty]
        public string City { get; set; }

        public SignupModel (AccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostSignup()
        {
            _Account.Name = FirstName + " " + LastName;
            _Account.PhoneNumber = "+" + CountryCode + " " + PhoneNumber;
            if (!ModelState.IsValid)
                return Page();

            // login automatically 
            _accountService.Create(_Account);
            if (_accountService.TryLogin(_Account.EMail, _Account.Password))
                return RedirectToPage("ViewProducts");
            return Page(); // could not login - ? (douplicate email... maybe)
        }
    }
}
