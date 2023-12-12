using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace KingKindProjekt.Pages.OurPages
{
    public class CartModel : PageBase
    {
        CouponService _couponService;
        [BindProperty]
        public string CurrentlyAppliedCoupon { get; private set; }
        [BindProperty]
        public string CouponToApply { get; set; }

        public List<Item>? Items { get; set; }
        public List<string>? Name { get; set; }
        public List<double>? Price { get; set; }
        public CartService? cartService { get; set; }
        public int? Amount { get; set; }
        public ItemService _itemService { get; set; }

        public CartModel(CartService cartService, ItemService itemService, AccountService accountService, CouponService couponService) : base(accountService)
        {
            this.cartService = cartService;
            _itemService = itemService;

            Items = cartService.items.ToList();
            _couponService = couponService;

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
        public IActionResult OnPostApplyCoupon()
        {
            if (CouponToApply == null) return Page();
            if (_couponService.IsThisCouponValid(CouponToApply))
            {
                CurrentlyAppliedCoupon = CouponToApply;
            }
            return Page();
        }

        public string CouponPercentOff()
        { return _couponService.GetCouponPercentOff(CurrentlyAppliedCoupon).ToString("0"); }
        public double GetPriceMultiplier()
        {
            if (CurrentlyAppliedCoupon == null) return 1;
            return _couponService.GetCouponMultiplier(CurrentlyAppliedCoupon);
        }
    }
}

