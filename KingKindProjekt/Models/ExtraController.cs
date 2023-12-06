using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KingKindProjekt.Models
{
    public class ExtraController : Controller
    {
        //[BindProperty]
        //string SearchString { get; set; } = "";
        //
        // GET: /Pages/
        public IActionResult Index()
        {
            Debug.WriteLine("ASFSaDSNALDMASPDSOPKDOPASMFLAÆ");
            return View();
        }
        //
        // POST: 
        public IActionResult SearchProducts(string SearchString)
        {
            Debug.WriteLine("ASFSaDSNALDMASPDSOPKDOPASMFLAÆ");
            return RedirectToPage("OurPages/ViewProducts", new { searchItems = SearchString });
        }
    }
}
