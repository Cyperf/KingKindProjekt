using KingKindProjekt.Models;

namespace KingKindProjekt.Services
{
    public class SaleService
    {
        Repository<Sale> _sales;
        JsonFileService<Sale> _jsonFileService;
        public SaleService (JsonFileService<Sale> jsonFileService)
        {
            _sales = new Repository<Sale>();
            _jsonFileService = jsonFileService;
        }

        public void Create (Sale sale)
        {
            if (_sales.Contains(sale.ItemName))
                return;
            _sales.Create(sale.ItemName, sale);
            _jsonFileService.SaveJsonItems(_sales.Items.Values);
        }

        public bool IsOnSale (string item)
        {
            bool b = false;
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            // check if the sale is still up
            if (_sales.Contains(item))
            {
                if (currentDate.CompareTo(_sales.Read(item).SaleDate) > 0)
                    Delete(item);
                else
                    b = true;
            }
            return b;
        }

        public void Delete (string item)
        {
            _sales.Delete(item);
            _jsonFileService.SaveJsonItems(_sales.Items.Values);
        }
        public double GetPrice(string item)
        {
            return _sales.Read(item).SalePrice;
        }
    }
}
