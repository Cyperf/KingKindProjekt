using Microsoft.AspNetCore.Mvc;
namespace KingKindProjekt.ViewComponents
{
    public class SearchViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SearchView.cshtml");
        }
    }
}
