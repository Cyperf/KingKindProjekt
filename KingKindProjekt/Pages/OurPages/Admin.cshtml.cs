using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;

// Lavet af Frederik

namespace KingKindProjekt.Pages.OurPages
{
    public class AdminModel : PageBase
    {
        private AccountService accountService;

        public AdminModel(AccountService accountService) : base(accountService)
        {
            this.accountService = accountService;
        }
        public IActionResult OnGet()
        {
            if (!accountService.IsLoggedIn() || AccountService.LoggedInAccount._AccountType != Models.AccountType.Admin)
                return RedirectToPage("ViewProducts");

            return default;
        }
    }
}
