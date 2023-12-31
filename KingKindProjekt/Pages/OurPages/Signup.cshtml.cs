using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

// Lavet af Jeppe

namespace KingKindProjekt.Pages.OurPages
{
    public class SignupModel : PageBase
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
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept our terms and conditions, to create an account")]
        public bool AcceptTermsAndConditions { get; set; }
        [BindProperty]
        public string PasswordChecker { get; set; }



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
        [Display(Name = "Address")]
        [BindProperty]
        public string Address { get; set; }

        public SignupModel(AccountService accountService) : base(accountService)
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
            _Account.PhoneNumber = CountryCode + " " + PhoneNumber;
            _Account.Address = Address + ", " + PostNumber + " " + City;
            _Account.WantsNewsLetter = false;
            if (!ValidateAccountDetails())
                return Page();
            // login automatically 
            _accountService.Create(_Account);
            if (_accountService.TryLogin(_Account.EMail, _Account.Password))
                return RedirectToPage("ViewProducts");
            _Account.EMail = "";
            return Page(); // could not login - ? (douplicate email... maybe)
        }

        private bool ValidateAccountDetails()
        {
            if (_Account.Name == null || _Account.Name.Length < 5)
                return false;
            if (_Account.EMail==null || _Account.EMail.Length < 4 || !_Account.EMail.Contains("@") || _Account.EMail.IndexOf("@") > _Account.EMail.Length - 3)
                return false;
            if (_Account.Password == null || _Account.Password.Length < 5 || _Account.Password != PasswordChecker)
                return false;
            if (_Account.Address == null || _Account.Address.Length < 5)
                return false;
            if (_Account.Country == null || _Account.Country.Length < 3)
                return false;
            if (_Account.PhoneNumber == null || _Account.PhoneNumber.Length < 8)
                return false;
            if (!AcceptTermsAndConditions)
                return false;

            return true;
        }
    }
}
