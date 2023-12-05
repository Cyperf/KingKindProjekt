using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages.OurPages
{
	public class DeleteItemModel : PageModel
	{
		private CartService _cartService;

		public DeleteItemModel(CartService cartService)
		{
			_cartService = cartService;
		}

		[BindProperty]
		public Models.Item Item { get; set; }


		public IActionResult OnGet(string name)
		{
			Item = _cartService.GetItem(name);
			if (Item == null)
				return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

			return Page();
		}

		public IActionResult OnPost(string name)
		{
			Models.Item deletedItem = _cartService.Delete(_cartService.GetItem(name));
			if (deletedItem == null)
				return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

			return RedirectToPage("GetAllItems");
		}
	}
}
