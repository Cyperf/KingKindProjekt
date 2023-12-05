using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages.OurPages
{
    public class InspectItemModel : PageModel
    {
        public Item item;
        ItemService _itemService;
        public InspectItemModel (ItemService itemService)
        {
            _itemService = itemService;
            
        }
        public void OnGet(string ItemName)
        {
            item = _itemService.Read(ItemName);
        }
    }
}
