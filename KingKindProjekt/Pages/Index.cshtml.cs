﻿using KingKindProjekt.Models;
using KingKindProjekt.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace KingKindProjekt.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		
		public IndexModel(ILogger<IndexModel> logger)
		{
			
			_logger = logger;
		}

		public IActionResult OnGet()
        {
			return RedirectToPage("OurPages/ViewProducts");
		}
	}
}