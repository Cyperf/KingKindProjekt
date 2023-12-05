using KingKindProjekt.Models;

namespace KingKindProjekt.Services
{
    public class CartService : ICartService
    {
		public double TotalPrice;
        public IEnumerable<Models.Item> items { get { return _cart.Items.Values; } }

        public Repository<Item> _cart;
        public Repository<int> _amount;

        private List<Item> _carts;
		
		public CartService ()
        {
            _cart = new Repository<Item> ();
			_amount = new Repository<int>();
		}
		
		public void Create(Item item)
        {
           
                _cart.Create(item.Name, item);
            if (_amount.Contains(item.Name))
                _amount.Update(item.Name, _amount.Read(item.Name) + 1);
            else _amount.Create(item.Name, 1);


		}

        public Item? Read(Item item, string name)
        {
            return _cart.Read(item.Name);   
        }
       
        public void Delete(Item item)
        {
            _cart.Delete(item.Name);
        }

		public Item GetItem(string name)
		{
			
			foreach (Item item in _carts)
			{
				if (item.Name == name)
					return item;
			}

			return null;
		}
		public List<Item> GetItems(string name) { return _carts; }
        

		public void CalculateTotalPrice()
		{
			foreach(Item item in _cart.Items.Values)
			{
				TotalPrice = TotalPrice + item.Price;
			}
		}

	}
}
