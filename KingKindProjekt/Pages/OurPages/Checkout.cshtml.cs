using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KingKindProjekt.Services;
using System.Diagnostics;
using KingKindProjekt.Models;
using System.Security.Principal;

namespace KingKindProjekt.Pages.OurPages
{
    public class CheckoutModel : PageModel
    {
        CartService cartService { get; set; }
        AccountService accountService { get; set; }
        [BindProperty]
        public string currentReceipt { get; set; }
        public CheckoutModel(CartService cartService, AccountService accountService)
        {
            this.cartService = cartService;
            this.accountService = accountService;
        }
        public void OnGet()
        {
            currentReceipt = "";
            if (cartService._cart.Items.Count>0)
            {

                foreach (var item in cartService._cart.Items.Values)
                {
                    currentReceipt += item.Name+" "+item.Brand+" "+cartService.GetPrice(item.Name)+" "+item.Type+" "+cartService._amount.Read(item.Name) +"\n";
                }
                if (AccountService.LoggedInAccount != null)
                    AccountService.LoggedInAccount.Receipts.Add(currentReceipt);
                accountService.Save();
            }

            cartService._amount.Items.Clear();
            cartService._cart.Items.Clear();
        }
    }
}
