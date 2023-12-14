using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

// Lavet af Frederik

namespace KingKindProjekt.Pages.OurPages
{
    public class ConfirmDeletionModel : PageBase
    {
        AccountService _accountService;

        public ConfirmDeletionModel(AccountService accountService) : base(accountService)
        {
            _accountService = accountService;
        }
        public IActionResult OnPostGoBack()
        {
            return RedirectToPage("User");
        }
        public IActionResult OnPostDelete()
        {
            _accountService.Delete(AccountService.LoggedInAccount);
            AccountService.LoggedInAccount = null;
            return RedirectToPage("ViewProducts");
        }
        public void OnGet()
        {
        }
    }
}
