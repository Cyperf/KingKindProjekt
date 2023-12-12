using KingKindProjekt.Models;

namespace KingKindProjekt.Services
{
    public class SaleService
    {
        Repository<Sale> _sales;
        JsonFileService<Sale> _jsonFileService;
        public SaleService(JsonFileService<Sale> jsonFileService)
        {
            _sales = new Repository<Sale>();
            _jsonFileService = jsonFileService;
            var sales = _jsonFileService.GetJsonItems();
            if (sales != null)
            {
                foreach (Sale sale in sales) { CreateWithoutSave(sale); }
            }
            else GetMockData();
        }

        public void CreateWithoutSave(Sale sale)
        {
            _sales.Create(sale.ItemName, sale);
        }
        public void Create(Sale sale)
        {
            if (_sales.Contains(sale.ItemName))
                return;
            _sales.Create(sale.ItemName, sale);
            _jsonFileService.SaveJsonItems(_sales.Items.Values);
        }

        public bool IsOnSale(string item)
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

        public void Delete(string item)
        {
            _sales.Delete(item);
            _jsonFileService.SaveJsonItems(_sales.Items.Values);
        }
        public string GetPrice(string item)
        {
            return _sales.Read(item).SalePrice.ToString() + " kr.";
        }
        public double GetPriceAsDouble(string item)
        {
            return _sales.Read(item).SalePrice;
        }

        private void GetMockData()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            Create(new Sale("Name", 10d, today.AddDays(1)));
            Create(new Sale("Hair gel", 10d, today.AddDays(2)));
        }
    }
}
