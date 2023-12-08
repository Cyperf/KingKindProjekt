using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace KingKindProjekt.Pages.OurPages
{
    public class InspectItemModel : PageBase
    {
        public Item item;
        CartService _cartService;
        private ItemService _itemService;
        public ItemService ItemService { get { return _itemService; } }
        public InspectItemModel (ItemService itemService, CartService cartService)
        {
            _itemService = itemService;
            _cartService = cartService;
            
        }
        public void OnGet(string ItemName, string createName = "", string deleteName = "")
        {
            item = _itemService.Read(ItemName);
            if (createName != "")
            {
                _cartService.Create(_itemService.Read(createName));
            }
            if (deleteName != "")
            {
                _cartService.Delete(_itemService.Read(deleteName).Name);
            }
        }
    }
}
