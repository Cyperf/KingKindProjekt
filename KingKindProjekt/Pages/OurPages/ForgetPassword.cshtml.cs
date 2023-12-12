using KingKindProjekt.Services;

namespace KingKindProjekt.Pages.OurPages
{
    public class ForgetPassword : PageBase
    {
        public ForgetPassword(AccountService accountService) : base(accountService)
        {
        }

        public void OnGet()
        {
        }
    }
}
