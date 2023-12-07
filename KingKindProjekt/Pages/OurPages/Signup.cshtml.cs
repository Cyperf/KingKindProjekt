using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

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
        [Display(Name = "Address")]
        [BindProperty]
        public string Address { get; set; }

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
            _Account.Address = Address + ", " + PostNumber + " " + City;
            _Account.WantsNewsLetter = false;
            Debug.WriteLine("<--------------------------------->");
            Debug.WriteLine(_Account.Name);
            Debug.WriteLine(_Account.EMail);
            Debug.WriteLine(_Account.Password);
            Debug.WriteLine(_Account._PrivateOrCorporation);
            Debug.WriteLine(_Account._AccountType);
            Debug.WriteLine(_Account.CVR);
            Debug.WriteLine(_Account.Address);
            Debug.WriteLine(_Account.Country);
            Debug.WriteLine(_Account.PhoneNumber);
            Debug.WriteLine(_Account.WantsNewsLetter);
            Debug.WriteLine("Valid: " + ModelState.ToString());
            Debug.WriteLine("<--------------------------------->");
            if (!ValidateAccountDetails())//if(!ModelState.IsValid)
                return Page();

            // login automatically 
            _accountService.Create(_Account);
            if (_accountService.TryLogin(_Account.EMail, _Account.Password))
                return RedirectToPage("ViewProducts");
            return Page(); // could not login - ? (douplicate email... maybe)
        }

        private bool ValidateAccountDetails ()
        {
            if (_Account.Name.Length < 5)
                return false;
            if (_Account.EMail.Length < 4 || !_Account.EMail.Contains("@") || _Account.EMail.IndexOf("@") > _Account.EMail.Length - 3)
                return false;
            if (_Account.Password.Length < 5)
                return false;
            if (_Account.Address.Length < 5)
                return false;
            if (_Account.Country.Length < 3)
                return false;
            if (_Account.PhoneNumber.Length < 8)
                return false;
            return true;
        }
    }
}
