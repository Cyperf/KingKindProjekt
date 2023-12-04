using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages.OurPages
{
    public class ViewProductsModel : PageModel
    {
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

        public void OnGet()
        {
        }
    }
}
