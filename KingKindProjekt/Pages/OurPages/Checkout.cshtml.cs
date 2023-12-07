using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KingKindProjekt.Services;
using System.Diagnostics;
using KingKindProjekt.Models;

namespace KingKindProjekt.Pages.OurPages
{
    public class CheckoutModel : PageModel
    {
        CartService cartService { get; set; }
        public CheckoutModel(CartService cartService)
        {
            this.cartService = cartService;
        }
        public void OnGet()
        {
            if (AccountService.LoggedInAccount != null)
            {
                Account account = new Account();
                foreach (var item in cartService._cart.Items)
                {
                 account.Receipts.Add(item.Value.Name.ToString()+" "+);
                 Debug.WriteLine(account);
                }
                
            }
            cartService._amount.Items.Clear();
            cartService._cart.Items.Clear();
        }
    }
}
