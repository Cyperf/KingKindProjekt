using KingKindProjekt.Models;
using System.Diagnostics;

namespace KingKindProjekt.Services
{
    public class ItemService
    {
        Repository<Item> _items;
        JsonFileService<Item> _jsonFileService;
        SaleService _saleService;
        //public ItemService()
        //{
        //    _items = new Repository<Item>();
        //}

        public ItemService(JsonFileService<Item> JsonFileService, SaleService saleService)
        {
            _items = new Repository<Item>();
            _jsonFileService = JsonFileService;
            _saleService = saleService;
            //_items = JsonFileService.GetJsonItems();
            _items = new Repository<Item>();
            var items = JsonFileService.GetJsonItems();
            if (items == null)
            {
                AddMockData();
                //System.Diagnostics.Debug.WriteLine("---------------------" + _items.Items.Count + "----------------------------");
            }
            if (items != null)
                foreach (var item in items)
                {
                    _items.Create(item.Name, item);
                }
        }

        public string GetPrice (string itemName)
        {
            Item item = _items.Read(itemName);
            if (item == null)
                return 0.ToString();
            if (_saleService.IsOnSale(itemName))
                return _saleService.GetPrice(itemName);
            return item.Price.ToString()+" kr.";

        }
        public string GetPrice(Item item)
        {
            return GetPrice(item.Name);
        }

        public double GetPriceAsDouble(string itemName)
        {
            Item item = _items.Read(itemName);
            if (item == null)
                return 0;
            if (_saleService.IsOnSale(itemName))
                return _saleService.GetPriceAsDouble(itemName);
            return item.Price;

        }

        public double GetPriceAsDouble(Item item)
        {
            return GetPriceAsDouble(item.Name);
        }

        public IEnumerable<Item> Items
        {
            get { return _items.Items.Values; }
        }
        public IEnumerable<Item> GetItems(string seachWord)
        {
            List<Item> items = new List<Item>();
            if (seachWord != "")
            {
                seachWord = seachWord.ToLower();
                foreach (var item in _items.Items.Values)
                {
                    if (item.Name.ToLower().Contains(seachWord))
                    {
                        items.Add(item);
                    }
                }
            }
            return items;
        }
        public IEnumerable<Item> FilterBrands(string brandName)
        {
            List<Item> items = new List<Item>();
            if (brandName != "")
            {
                brandName = brandName.ToLower();
                foreach (var item in _items.Items.Values)
                {
                    if (item.Brand.ToLower().Contains(brandName))
                    {
                        items.Add(item);
                    }
                }
            }
            return items;
        }
        public void Create(Item item)
        {
            _items.Create(item.Name, item);
            _jsonFileService.SaveJsonItems(_items.Items.Values);
        }
        public Item? Read(Item item)
        {
            return _items.Read(item.Name);
        }
        public Item? Read(string item)
        {
            return _items.Read(item);
        }
        public void Update(Item item)
        {
            _items.Update(item.Name, item);
            _jsonFileService.SaveJsonItems(_items.Items.Values);
        }
        public void Delete(Item item)
        {

            Item itemToBeDeleted = _items.Delete(item.Name);
            if (itemToBeDeleted != null)
            {
                _jsonFileService.SaveJsonItems(_items.Items.Values);
            }
        }
        public IEnumerable<String> GetAllBrands()
        {
            List<string> brands = new List<string>();
            foreach (var item in Items)
            {
                string brand = item.Brand;
                if (!brands.Contains(brand))
                    brands.Add(brand);
            }
            brands.Sort();
            return brands;
        }

        private void AddMockData()
        {
            Create(new Item("Name", "Branded", ItemType.Razor, "Wow, this is the best razer I have ever tried!", 199.99d, "KindKindLogo.png"));
            Create(new Item("Hair gel", "Other brand", ItemType.Hairgel, "Just normal hair gel.", 99.99d, ""));
            Create(new Item("Gel'ler hair", "Super brand", ItemType.Hairgel, "Nice hair gel.", 119.99d, ""));
            Create(new Item("Expensives hairs    gel", "Branded", ItemType.Hairgel, "Most likely the best hair gel in excistence.", 1199.99d, ""));
            Create(new Item("Nasme", "Branded", ItemType.Razor, "Wow, this is the best razer I have ever tried!", 199.99d, "KindKindLogo.png"));
            Create(new Item("Hair gsel", "Other brand", ItemType.Hairgel, "Just normal hair gel.", 99.99d, ""));
            Create(new Item("Gel'ler hasir", "Super brand", ItemType.Hairgel, "Nice hair gel.", 119.99d, ""));
            Create(new Item("Expenssive hair gel", "Branded", ItemType.Hairgel, "Most likely the best hair gel in excistence.", 1199.99d, ""));
            Create(new Item("sName", "Branded", ItemType.Razor, "Wow, this is the best razer I have ever tried!", 199.99d, "KindKindLogo.png"));
            Create(new Item("Hsair gel", "Other brand", ItemType.Hairgel, "Just normal hair gel.", 99.99d, ""));
            Create(new Item("Gsel'ler hair", "Super brand", ItemType.Hairgel, "Nice hair gel.", 119.99d, ""));
            Create(new Item("Expensive hairs gel", "Branded", ItemType.Hairgel, "Most likely the best hair gel in excistence.", 1199.99d, ""));
            Create(new Item("Names", "Branded", ItemType.Razor, "Wow, this is the best razer I have ever tried!", 199.99d, "KindKindLogo.png"));
            Create(new Item("Hairs gel", "Other brand", ItemType.Hairgel, "Just normal hair gel.", 99.99d, ""));
            Create(new Item("Gel'ler hairs", "Super brand", ItemType.Hairgel, "Nice hair gel.", 119.99d, ""));
            Create(new Item("Expensive hair gels", "Branded", ItemType.Hairgel, "Most likely the best hair gel in excistence.", 1199.99d, ""));
        }
    }
}