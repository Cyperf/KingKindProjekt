using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KingKindProjekt.Pages.OurPages
{
    public class CreateItemModel : PageBase
    {
        public ItemService _itemService { get; set; }
        [BindProperty]
        public Item _Item { get; set; }

        [Display(Name = "Name")]
        [BindProperty]
        public string Name { get; set; }
        [Display(Name = "Brand")]
        [BindProperty]
        public string Brand { get; set; }
        [Display(Name = "ItemType")]
        [BindProperty]
        public ItemType ItemType { get; set; }
        [Display(Name = "Description")]
        [BindProperty]
        public string Description { get; set; }
        [Display(Name = "Price")]
        [BindProperty]
        public double Price { get; set; }
        [Display(Name = "PathToImage")]
        [BindProperty]
        public string PathToImage { get; set; }


        public CreateItemModel(ItemService itemService)
        {
            this._itemService = itemService;
        }
        public void OnGet()
        {

            

        }
    }
}
