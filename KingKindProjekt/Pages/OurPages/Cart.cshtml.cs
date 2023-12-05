using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
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
		public ItemService _itemService { get; set; }	
		public CartModel(CartService cartService, ItemService itemService)
		{
			this.cartService = cartService;
			_itemService = itemService;
			
			Items = cartService.items.ToList();
		}



		public IActionResult OnGet(string ItemName, string createName = "", string deleteName = "")
		{
			if (deleteName != "")
			{
				int amount = cartService.Delete(deleteName);

				if (amount == 0)
					return RedirectToPage("Cart");
			}

			if (createName != "")
				cartService.Create(_itemService.Read(createName));
				
			return Page();
		
			}
		
			
		}

		

	}

