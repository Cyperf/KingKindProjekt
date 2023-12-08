using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace KingKindProjekt.Pages.OurPages
{
    public class ViewProductsModel : PageModel
    {
        [BindProperty]
        public static string SearchProduct { get; set; } = "";

        public List<Item> Items { get; set; }
        public List<string> Brands { get; set; }
        public ItemService itemService { get; set; }

        public ViewProductsModel(ItemService itemService)
        {
            this.itemService = itemService;
            Items = itemService.Items.ToList();
            Brands = itemService.GetAllBrands().ToList();
        }

        public IActionResult OnGet(string searchItems = "", string searchBrands = "")
        {
            Debug.WriteLine("---------------------> " + searchBrands + " : " + " <----------------------------");
            if (searchItems != "")
                Items = itemService.GetItems(searchItems).ToList();
            else if (searchBrands != "")
                Items = itemService.FilterBrands(searchBrands).ToList();
            return Page();
        }
    }
}
