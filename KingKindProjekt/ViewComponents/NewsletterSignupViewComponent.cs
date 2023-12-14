using Microsoft.AspNetCore.Mvc;

namespace KingKindProjekt.ViewComponents
{
    public class NewsletterSignupViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("NewsletterSignupView.cshtml");
        }
    }
}
