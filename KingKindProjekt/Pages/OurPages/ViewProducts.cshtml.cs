using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KingKindProjekt.Pages.OurPages
{
    public class ViewProductsModel : PageBase
    {
        [BindProperty]
        public ItemType filterItemType { get; set; } = ItemType.NoItem;

		public List<Item> Items { get; set; }
        public List<string> Brands { get; set; }
        public ItemService itemService { get; set; }

        public ViewProductsModel(ItemService itemService, AccountService accountService) : base(accountService)
        {
            this.itemService = itemService;
            Items = itemService.Items.ToList();
            Brands = itemService.GetAllBrands().ToList();
        }

        public IActionResult OnGet(string searchItems = "", string searchBrands = "")
        {
            searchItems = PageBase.TryingToSearch;
            PageBase.TryingToSearch = "";
			if (searchItems == null)
                searchItems = "";
            if (searchItems != "")
                Items = itemService.GetItems(searchItems).ToList();
            if (searchBrands != "")
                Items = itemService.FilterBrands(searchBrands).ToList();

			return Page();
        }
		public IActionResult OnPostFilterItemsByType()
        {
            Debug.WriteLine("bbb: " + filterItemType);
            if (filterItemType != ItemType.NoItem)
                Items = itemService.GetItems(filterItemType).ToList();
            return Page();
		}
	}
}
