using Microsoft.AspNetCore.Mvc;

namespace KingKindProjekt.Models
{


    public class Sale
    {


        [BindProperty]
        public string ItemName { get; set; }
        [BindProperty]
        public double SalePrice { get; set; }
        [BindProperty]
        public DateOnly SaleDate { get; set; }
        public Sale()
        {
            ItemName = "";
            SalePrice = 0;
            SaleDate = DateOnly.FromDateTime(DateTime.Now);
        }
        public Sale(string itemName, double salePrice, DateOnly date)
        {
            ItemName = itemName;
            SalePrice = salePrice;
            SaleDate = date;
        }
    }
}
