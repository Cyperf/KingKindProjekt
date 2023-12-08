using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace KingKindProjekt.Pages.OurPages
{
    public class PageBase : PageModel
    {
        public AccountService _accountService;

        [BindProperty]
        public string SearchWord { get; set; }
        [BindProperty]
        public string NewsletterSignup { get; set; }

        public static string TryingToSearch = "";

        public PageBase(AccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnPostSearch ()
        {
            TryingToSearch = SearchWord;
            SearchWord = "";
            return RedirectToPage("/OurPages/ViewProducts");
        }

        public IActionResult OnPostNewsletterSignup()
        {
            if (NewsletterSignup == null || NewsletterSignup == "")
                return Page();
            Account acc = _accountService.Read(NewsletterSignup);

            if (acc != null)
            {
                acc.WantsNewsLetter = true;
                _accountService.Save();
            }
            NewsletterSignup = "";
            return Page();
        }
    }
}
