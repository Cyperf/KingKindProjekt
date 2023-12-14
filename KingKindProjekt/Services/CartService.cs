using KingKindProjekt.Models;

// Lavet af Frederik

namespace KingKindProjekt.Services
{
    public class CartService
    {
        public double TotalPrice;
        public bool Coupon = false;
        public IEnumerable<Models.Item> items { get { return _cart.Items.Values; } }

        public Repository<Item> _cart;
        public Repository<int> _amount;
        ItemService _itemService;


        public CartService(ItemService itemService)
        {
            _cart = new Repository<Item>();
            _amount = new Repository<int>();
            _itemService = itemService;

        }

        public double GetPrice(string itemName)
        {
            return _itemService.GetPriceAsDouble(itemName);
        }

        public double GetPrice(Item item)
        {
            return GetPrice(item.Name);
        }

        public void Create(Item? item)
        {
            if (item == null)
                return;
            _cart.Create(item.Name, item);
            if (_amount.Contains(item.Name))
                _amount.Update(item.Name, _amount.Read(item.Name) + 1);
            else _amount.Create(item.Name, 1);
        }

        public Item? Read(Item item, string name)
        {
            return _cart.Read(item.Name);
        }

        public Item Delete(Item item)
        {
            return _cart.Delete(item.Name);
        }
        public int Delete(string name)
        {
            int amount = _amount.Read(name) - 1;
            _amount.Update(name, amount);
            if (amount <= 0)
            {
                _amount.Delete(name);
                _cart.Delete(name);
                return 0;
            }
            return amount;

        }

        public Item GetItem(string name)
        {

            foreach (Item item in _cart.Items.Values)
            {
                if (item.Name == name)
                    return item;
            }

            return null;
        }
        public List<Item> GetItems(string name) { return _cart.Items.Values.ToList(); }


        public double CalculateTotalPriceExTax()
        {
            TotalPrice = 0;
            foreach (Item item in _cart.Items.Values)
            {
                TotalPrice = TotalPrice + GetPrice(item.Name) * _amount.Read(item.Name);

            }
            return TotalPrice;

        }
        public double CalculateTotalPriceWTax()
        {

            return CalculateTotalPriceExTax() * 1.25;

        }

        public void couponApply()
        {
            Coupon = true;
        }

    }
}
