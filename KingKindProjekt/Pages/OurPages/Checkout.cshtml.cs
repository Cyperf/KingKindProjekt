using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KingKindProjekt.Services;
using System.Diagnostics;
using KingKindProjekt.Models;
using System.Security.Principal;

namespace KingKindProjekt.Pages.OurPages
{
    public class CheckoutModel : PageBase
    {
        CartService cartService { get; set; }
        ItemService itemService { get; set; }
        AccountService accountService { get; set; }
        CouponService _couponService;
		[BindProperty]
        public string currentReceipt { get; set; }
        public CheckoutModel(CartService cartService, AccountService accountService, ItemService itemService, CouponService couponService) : base(accountService)
        {
            this.cartService = cartService;
            this.accountService = accountService;
            this.itemService = itemService;
            _couponService = couponService;
		}
        public void OnGet(string appliedCoupon = "")
        {
            currentReceipt = "";
            if (cartService._cart.Items.Count>0)
            {
                currentReceipt = "---------------RECEIPT START---------------"+"\n";

				foreach (var item in cartService._cart.Items.Values)
                {
                    currentReceipt += "["+cartService._amount.Read(item.Name)+"]"+" "+item.Name + " "+item.Brand+" "+item.Type+" - "+itemService.GetPrice(item.Name)+"\n";
                }
                double price = cartService.CalculateTotalPriceWTax();
                if (appliedCoupon != null && appliedCoupon != "")
                {
                    currentReceipt += "Applied coupon: " + appliedCoupon + " which gave " + _couponService.GetCouponPercentOff(appliedCoupon) + "% off" + "\n";
                    price *= _couponService.GetCouponMultiplier(appliedCoupon);
				}
                currentReceipt += "Total price: " + price + "\n";
				currentReceipt += "Tax: " + (price * .2d) + "\n";
				currentReceipt += "---------------RECEIPT END---------------" + "\n";
				if (AccountService.LoggedInAccount != null)
                {
                    AccountService.LoggedInAccount.Receipts.Add(currentReceipt);
                    if (appliedCoupon != null && appliedCoupon != "")
                        AccountService.LoggedInAccount.UsedCoupons.Add(appliedCoupon);

				}
                accountService.Save();
            }

            cartService._amount.Items.Clear();
            cartService._cart.Items.Clear();
        }
    }
}
