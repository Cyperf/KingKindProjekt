using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
namespace KingKindProjekt.ViewComponents
{
    public class SearchViewComponent : ViewComponent
    {
        [BindProperty]
        public string SearchProduct { get; set; }
        private SearchProductService _service;
        public SearchViewComponent(SearchProductService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _service.SearchAsync();
            return View("SearchView.cshtml");
            //return View("/Pages/OurPages/Components/Search/SearchView.cshtml");
        }
    }
}
