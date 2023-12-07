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
        public static string SearchProduct { get; set; }

        public List<Item> Items { get; set; }
        public List<string> Brands { get; set; }
        public ItemService itemService { get; set; }

        public ViewProductsModel(ItemService itemService)
        {
            this.itemService = itemService;
            Items = itemService.Items.ToList();
            // find brands
            Brands = new List<string>();
            foreach (var item in Items)
            {
                string brand = item.Brand;
                if (!Brands.Contains(brand))
                    Brands.Add(brand);
            }
            Brands.Sort();
            //for (int i = 0; i < 10; i++)
            //    Brands.Add("Test" + i);
        }

        public IActionResult OnGet(string searchItems = "", string searchBrands = "")
        {
            Debug.WriteLine("---------------------> " + searchItems + " : " + SearchProduct + " <----------------------------");
            if (searchItems != "")
            {
                for (int i  = 0; i < Items.Count; i++)
                {
                    if (!Items[i].Name.ToLower().Contains(searchItems.ToLower()))
                    {
                        Items.RemoveAt(i);
                        i--;
                    }
                }
            }
            if (searchBrands != "")
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (!Items[i].Brand.ToLower().Contains(searchItems.ToLower()))
                    {
                        Items.RemoveAt(i);
                        i--;
                    }
                }
            }
                return Page();
        }
    }
}
