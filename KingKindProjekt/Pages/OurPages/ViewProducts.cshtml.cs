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
        [BindProperty]
        public string tempSearch { get; set; } = "";

        public List<Item> Items { get; set; }
        public List<string> Brands { get; set; }
        public ItemService itemService { get; set; }

        public ViewProductsModel(ItemService itemService)
        {
            this.itemService = itemService;
            Brands = itemService.GetAllBrands().ToList();
            //for (int i = 0; i < 10; i++)
            //    Brands.Add("Test" + i);
        }

        public IActionResult OnGet(string searchItems = "", string searchBrands = "")
        {
            Debug.WriteLine("---------------------> " + searchItems + " : " + SearchProduct + " <----------------------------");
            if (searchItems != "")
                Items = itemService.GetItems(searchItems).ToList();
            else if (searchBrands != "")
                Items = itemService.FilterBrands(searchBrands).ToList();
            else
                Items = itemService.Items.ToList();
            //{
            //    for (int i = 0; i < Items.Count; i++)
            //    {
            //        if (!Items[i].Brand.ToLower().Contains(searchItems.ToLower()))
            //        {
            //            Items.RemoveAt(i);
            //            i--;
            //        }
            //    }
            //}
            return Page();
        }
    }
}
