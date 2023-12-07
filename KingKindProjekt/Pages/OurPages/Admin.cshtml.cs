using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages.OurPages
{
    public class AdminModel : PageModel
    {
        private AccountService accountService;

        public AdminModel(AccountService accountService)
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
