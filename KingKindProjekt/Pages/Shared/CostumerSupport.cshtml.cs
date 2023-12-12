using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingKindProjekt.Pages
{
    public class CostumerSupportModel :KingKindProjekt.Pages.OurPages.PageBase
    {
        private readonly ILogger<CostumerSupportModel> _logger;

        public CostumerSupportModel(ILogger<CostumerSupportModel> logger, KingKindProjekt.Services.AccountService accountService) : base(accountService)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
