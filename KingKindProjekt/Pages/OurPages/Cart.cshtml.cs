using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace KingKindProjekt.Pages.OurPages
{
    public class CartModel : PageModel
    {
		public List<Item>? Items { get; set; }
		public List<string>? Name { get; set; }
        public List<double>? Price { get; set; } 
		public CartService? cartService { get; set; }

        public void OnGet(CartService cartService)
        {
            this.cartService = cartService;
            Items = cartService.items.ToList();




	   }
	}
}
