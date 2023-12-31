﻿namespace KingKindProjekt.Pages
{
    public class PrivacyModel : KingKindProjekt.Pages.OurPages.PageBase
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger, KingKindProjekt.Services.AccountService accountService) : base(accountService)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}