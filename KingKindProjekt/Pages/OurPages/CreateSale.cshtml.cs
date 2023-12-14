using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

// Lavet af Frederik

namespace KingKindProjekt.Pages.OurPages
{
    public class CreateSaleModel : PageBase
    {
        private SaleService _saleService { get; set; }
        private ItemService _itemService { get; set; }

        [BindProperty]
        public Item _Item { get; set; }
        [Display(Name = "Sale Price")]
        [BindProperty]
        public double salePrice { get; set; }
        [Display(Name = "Days of sale")]
        [BindProperty]
        public int days { get; set; }
        public CreateSaleModel(AccountService accountService, ItemService itemService, SaleService saleService) : base(accountService)
        {
            _itemService = itemService;
            _saleService = saleService;

            List<Models.Item> selectableItems = itemService.Items.ToList();
            ItemList = new SelectList(selectableItems, nameof(Models.Item.Name), nameof(Models.Item.Name));
        }

        public SelectList ItemList { get; set; }
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        public IActionResult OnGet()
        {
            if (!_accountService.IsLoggedIn() || AccountService.LoggedInAccount._AccountType != Models.AccountType.Admin)
                return RedirectToPage("ViewProducts");

            return Page();
        }
        public IActionResult OnPostSignup()
        {

            _saleService.Create(new Sale(_Item.Name, salePrice, today.AddDays(days)));

            return RedirectToPage("CreateSale");
        }
    }
}
