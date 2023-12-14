using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KingKindProjekt.Pages.OurPages
{
    public class CreateCouponModel : PageBase
    {

        private CouponService _couponService;

        [Display(Name = "Name of coupon")]
        [BindProperty]
        public string name { get; set; }
        [Display(Name = "How many % Off")]
        [BindProperty]
        public int couponPercent { get; set; }
        [Display(Name = "Days of sale")]
        [BindProperty]
        public int days { get; set; }
        public CreateCouponModel(AccountService accountService, CouponService couponService) : base(accountService)
        {
            _couponService = couponService;

        }

        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        public IActionResult OnGet()
        {
            if (!_accountService.IsLoggedIn() || AccountService.LoggedInAccount._AccountType != Models.AccountType.Admin)
                return RedirectToPage("ViewProducts");

            return default;
        }
        public IActionResult OnPostCreate()
        {

            _couponService.Create(new Coupon(name, couponPercent, today.AddDays(days)));

            return RedirectToPage("CreateSale");
        }
       
    }
}
