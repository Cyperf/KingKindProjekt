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
    }
}
