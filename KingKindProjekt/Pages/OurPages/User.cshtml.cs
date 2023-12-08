using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages.OurPages
{
    public class UserModel : PageBase
    {

        Models.Account? account;

        public void OnGet()
        {
        }

        public string PrintReceipt(Models.Account account)
        {
            this.account = account;

            return account.Receipts.ToString();
        }



    }
}
