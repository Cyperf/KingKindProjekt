using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace KingKindProjekt.Pages.OurPages
{
    public class PageBase : PageModel
    {
        [BindProperty]
        public string SearchWord { get; set; }

        public static string TryingToSearch = "";

        public IActionResult OnPostSearch ()
        {
            TryingToSearch = SearchWord;
            SearchWord = "";
            return RedirectToPage("/OurPages/ViewProducts");
        }
    }
}
