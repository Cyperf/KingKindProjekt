using KingKindProjekt.Models;

namespace KingKindProjekt.Services
{
    public class CartService
    {
		public double TotalPrice;
        public IEnumerable<Models.Item> items { get { return _cart.Items.Values; } }

        public Repository<Item> _cart;
        public CartService ()
        {
            _cart = new Repository<Item> ();
        }
		
		public void Create(Item item)
        {
            _cart.Create(item.Name, item);
        }
        public Item? Read(Item item)
        {
             return _cart.Read(item.Name);
        }
        public void Update(Item item)
        {
            _cart.Update(item.Name, item);
        }
        public void Delete(Item item)
        {
            _cart.Delete(item.Name);
        } 

		public void CalculateTotalPrice()
		{
			foreach(Item item in _cart.Items.Values)
			{
				TotalPrice = TotalPrice + item.Price;
			}
		}

	}
}
