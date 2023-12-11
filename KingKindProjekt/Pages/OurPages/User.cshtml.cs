using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages.OurPages
{
    public class UserModel : PageBase
    {

        Models.Account? account;

        public UserModel(AccountService accountService) : base(accountService) { }

        public IActionResult OnGet()
        {
            if (AccountService.LoggedInAccount == null)
                return RedirectToPage("ViewProducts");
            return Page();
        }

        public string PrintReceipt(Models.Account account)
        {
            this.account = account;

            return account.Receipts.ToString();
        }



    }
}
