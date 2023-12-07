using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages.OurPages
{
    public class AdminModel : PageModel
    {
        private AccountService accountService;

        public IActionResult OnGet(AccountService account)
        {
            this.accountService = account;
            if (!account.IsLoggedIn() || account.LoggedInAccount._AccountType != Models.AccountType.Admin) 
            return RedirectToPage("ViewProducts");

            return default;
        }
    }
}
