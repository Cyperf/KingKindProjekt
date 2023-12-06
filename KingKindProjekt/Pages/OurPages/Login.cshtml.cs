using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages.OurPages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        string EMail { get; set; }
        [BindProperty]
        string Password { get; set; }
        public LoginModel()
        {
            EMail = "";
            Password = "";
        }
        public void OnPostLogin()
        {

        }
    }
}
