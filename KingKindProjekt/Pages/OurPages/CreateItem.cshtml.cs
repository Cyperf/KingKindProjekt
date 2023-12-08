using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Security.Principal;

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


        public CreateItemModel(ItemService itemService, AccountService accountService) : base(accountService)
        {
            _itemService = itemService;
            
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostSignup()
        {
            _Item.Name = Name;
            _Item.Brand = Brand;
            _Item.Type = ItemType;
            _Item.Description = Description;
            _Item.Price = Price;
            _Item.PathToImage = PathToImage;



            _itemService.Create(_Item);

            return Page();
        }
    }
}
