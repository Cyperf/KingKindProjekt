using KingKindProjekt.Models;

namespace KingKindProjekt.Services
{
    public class ItemService
    {
        Repository<Item> items;

        public ItemService ()
        {
            items = new Repository<Item> ();
        }

        public IEnumerable<Item> Items
        {
            get { return items.Items.Values; }
        }
        public void Create(Item item)
        {
            items.Create(item.Name, item);
        }
        public Item? Read(Item item)
        {
             return items.Read(item.Name);
        }
        public void Update(Item item)
        {
            items.Update(item.Name, item);
        }
        public void Delete(Item item)
        {
            items.Delete(item.Name);
        }
    }
}
