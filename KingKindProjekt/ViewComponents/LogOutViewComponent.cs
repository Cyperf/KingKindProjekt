using Microsoft.AspNetCore.Mvc;

// Lavet af Jeppe

namespace KingKindProjekt.ViewComponents
{
    public class LogOutViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LogOutView.cshtml");
        }
    }
}
