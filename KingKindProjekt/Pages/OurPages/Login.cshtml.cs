using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;

// Lavet af Jeppe

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

        public IActionResult OnPostLogin()
        {
            if (EMail == null || Password == null)
                return Page();
            if (_accountService.TryLogin(EMail, Password))
                return RedirectToPage("ViewProducts"); 
            return Page(); // could not login
        }
    }
}
