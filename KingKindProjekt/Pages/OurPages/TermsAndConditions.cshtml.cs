using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages.OurPages
{
    public class TermsAndConditionsModel : PageBase
    {
        public TermsAndConditionsModel(AccountService accountService) : base(accountService)
        {}

        public void OnGet()
        {
        }
    }
}
