using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;

// Lavet af Frederik

namespace KingKindProjekt.Pages.OurPages
{
    public class UserModel : PageBase
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


        public IActionResult OnGet()
        {
            if (AccountService.LoggedInAccount == null)
                return RedirectToPage("ViewProducts");
            string s = AccountService.LoggedInAccount.PhoneNumber;
            string countryCode = AccountService.LoggedInAccount.PhoneNumber;
            for (int i = s.Length - 1; i > 0; i--) // remove country code from phone number
                if (s[i] == ' ')
                {
                    countryCode = s.Substring(0, i);
                    s = s.Substring(i, s.Length - i);

                }
            CountryCode = int.Parse(countryCode);
            PhoneNumber = int.Parse(s);
            if (AccountService.LoggedInAccount == null)
                return RedirectToPage("ViewProducts");
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            _Account.EMail = AccountService.LoggedInAccount.EMail;
            _Account.PhoneNumber = PhoneNumber.ToString();
            _Account.Address = Address;
            _Account.WantsNewsLetter = false;
            if (!ValidateAccountDetails())
                return Page();
            AccountService.LoggedInAccount.Name = _Account.Name;
            AccountService.LoggedInAccount.PhoneNumber = _Account.PhoneNumber;
            AccountService.LoggedInAccount.Address = _Account.Address;
            AccountService.LoggedInAccount.Password = _Account.Password;
            AccountService.LoggedInAccount.CVR = _Account.CVR;
            AccountService.LoggedInAccount.Country = _Account.Country;

            _accountService.Update(AccountService.LoggedInAccount);

            if (_accountService.TryLogin(_Account.EMail, _Account.Password))
                return RedirectToPage("ViewProducts");
            return Page(); // could not login - ? (douplicate email... maybe)
        }

        public IActionResult OnPostDelete()
        {
            return RedirectToPage("ConfirmDeletion");
        }

        private bool ValidateAccountDetails()
        {
            if (_Account.Name.Length < 5)
                return false;
            if (_Account.EMail.Length < 4 || !_Account.EMail.Contains("@") || _Account.EMail.IndexOf("@") > _Account.EMail.Length - 3)
                return false;
            if (_Account.Password.Length < 5 || _Account.Password != PasswordChecker)
                return false;
            if (_Account.Address.Length < 5)
                return false;
            if (_Account.Country.Length < 3)
                return false;
            if (_Account.PhoneNumber.Length < 8)
                return false;
            return true;
        }


        Models.Account? account;

        public UserModel(AccountService accountService) : base(accountService)
        {
            _accountService = accountService;
            _Account = AccountService.LoggedInAccount;

        }



        public string PrintReceipt(Models.Account account)
        {
            this.account = account;

            return account.Receipts.ToString();
        }



    }
}
