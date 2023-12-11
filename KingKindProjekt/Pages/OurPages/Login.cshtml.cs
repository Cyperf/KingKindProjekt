using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace KingKindProjekt.Pages.OurPages
{
    public class LoginModel : PageBase
    {

        [BindProperty]
        public string EMail { get; set; }
        [BindProperty]
        public string Password { get; set; }

        AccountService _accountService;
        public LoginModel(AccountService accountService) : base(accountService)
        {
            _accountService = accountService;
        }
        //void OnGet ()
        //{
        //    EMail = "";
        //    Password = "";
        //}
        public IActionResult OnPostLogin()
        {
            //Debug.WriteLine("Onpost: " + EMail + " : " + Password);
            if (EMail == null  || Password == null)
                return Page();
            //Debug.WriteLine("dasklfnasklnskdmsafmakfls");
            if (_accountService.TryLogin(EMail, Password))
                return RedirectToPage("ViewProducts"); // should be look at account stuff
            return Page(); // could not login
        }
    }
}
