using Microsoft.AspNetCore.Mvc;

namespace KingKindProjekt.ViewComponents
{
    public class LogOutViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("NewsletterSignupView.cshtml");
        }
    }
}
