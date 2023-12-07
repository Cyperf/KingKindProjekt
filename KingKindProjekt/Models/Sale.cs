namespace KingKindProjekt.Models
{
    public class Sale
    {
        public string ItemName;
        public double SalePrice;
        public DateOnly SaleDate;
        public Sale()
        {
            ItemName = "";
            SalePrice = 0;
            SaleDate = DateOnly.FromDateTime(DateTime.Now);
        }
        public Sale(string itemName, double salePrice)
        {
            ItemName = itemName;
            SalePrice = salePrice;
        }
    }
}
