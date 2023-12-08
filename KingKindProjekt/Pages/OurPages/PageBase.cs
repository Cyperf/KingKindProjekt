using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace KingKindProjekt.Pages.OurPages
{
    public class PageBase : PageModel
    {
        [BindProperty]
        public string SearchWord { get; set; }
        [BindProperty]
        public string NewsletterSignup { get; set; }

        public static string TryingToSearch = "";

        private AccountService __accountService;

        public IActionResult OnPostSearch ()
        {
            TryingToSearch = SearchWord;
            SearchWord = "";
            return RedirectToPage("/OurPages/ViewProducts");
        }

        public IActionResult OnPostNewsletterSignup()
        {
            Debug.WriteLine("Test: " + NewsletterSignup);
            NewsletterSignup = "";
            return Page();
        }
    }
}
