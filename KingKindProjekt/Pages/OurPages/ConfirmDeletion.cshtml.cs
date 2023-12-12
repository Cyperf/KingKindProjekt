using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace KingKindProjekt.Pages.OurPages
{
    public class ConfirmDeletionModel : PageBase
    {
        AccountService _accountService;

        public ConfirmDeletionModel(AccountService accountService) : base(accountService)
        {
        
        }
        public IActionResult OnPostGoBack()
        {
            Debug.WriteLine("I got this far..");
            return RedirectToPage("User");
        }
        public IActionResult OnPostDelete()
        {
            Debug.WriteLine("I got this far..");
            _accountService.Delete(AccountService.LoggedInAccount);
            AccountService.LoggedInAccount = null;
            return RedirectToPage("ViewProducts");
        }
        public void OnGet()
        {
            Debug.WriteLine("I got this far..");
        }
    }
}
