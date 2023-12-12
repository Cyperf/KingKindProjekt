using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace KingKindProjekt.Pages.OurPages
{
    public class CreateItemModel : PageBase
    {

        private AccountService _accountService;
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
            _accountService = accountService;

        }
        public IActionResult OnGet()
        {
            if (!_accountService.IsLoggedIn() || AccountService.LoggedInAccount._AccountType != Models.AccountType.Admin)
                return RedirectToPage("ViewProducts");

            return default;
        }

        public IActionResult OnPostAdd()
        {
            _Item.Name = Name;
            _Item.Brand = Brand;
            _Item.Type = ItemType;
            _Item.Description = Description;
            _Item.Price = Price;
            _Item.PathToImage = PathToImage;



            _itemService.Create(_Item);
            Debug.WriteLine(PathToImage);

            return Page();
        }
    }
}
