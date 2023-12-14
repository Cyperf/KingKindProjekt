using Microsoft.AspNetCore.Mvc;

// Lavet af Jeppe

namespace KingKindProjekt.Models
{
    public class Coupon
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public double PercentOff { get; set; }
        [BindProperty]
        public DateOnly SaleDate { get; set; }
        public Coupon()
        {
            PercentOff = 0;
            SaleDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
        public Coupon(string name, double percentOff, DateOnly date)
        {
            Name = name;
            PercentOff = percentOff;
            SaleDate = date;
        }
    }
}
