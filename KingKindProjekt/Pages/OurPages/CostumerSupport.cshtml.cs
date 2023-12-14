using KingKindProjekt.Models;
using Microsoft.AspNetCore.Mvc;

// Lavet af Jeppe

namespace KingKindProjekt.Pages.OurPages
{
    public class CostumerSupportModel : PageBase
    {
        private readonly ILogger<CostumerSupportModel> _logger;

        public CostumerSupportModel(ILogger<CostumerSupportModel> logger, Services.AccountService accountService) : base(accountService)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPostSendMessage ()
		{
			ViewData["AlertMessage"] = "Your message has been sent. Thank you for you feedback :D";

			return Page();
		}
    }
}
