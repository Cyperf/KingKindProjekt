using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages.OurPages
{
    public class ViewProductsModel : PageModel
    {
        public List<string> Brands { get; set; }
        public ItemService itemService { get; set; }

        public void OnGet(ItemService itemService)
        {
            Brands = new List<string>();
            for (int i = 0; i < 10; i++)
                Brands.Add("Test" + i);
            this.itemService = itemService;
        }
    }
}
