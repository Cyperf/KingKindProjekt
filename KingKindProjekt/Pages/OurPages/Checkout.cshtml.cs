using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KingKindProjekt.Services;

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
            cartService._cart.Items.Clear();
        }
    }
}
