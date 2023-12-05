using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Xml.Linq;

namespace KingKindProjekt.Pages.OurPages
{
    public class CartModel : PageModel
    {
		public List<Item>? Items { get; set; }
		public List<string>? Name { get; set; }
        public List<double>? Price { get; set; } 
		public CartService? cartService { get; set; }
        public int? Amount { get; set; }

        public CartModel(CartService cartService)
        {
            this.cartService = cartService;

			Items = cartService.items.ToList();
			//cartService.Delete(cartService.GetItem());
		}
		//public IActionResult OnGet()
		//{
		//	return Page();
		//}
		public IActionResult OnGet(string deleteName = "")
		{
			if (deleteName == "")
				return Page();
			cartService.Delete(deleteName);
			return Page();
		}

	}
}
