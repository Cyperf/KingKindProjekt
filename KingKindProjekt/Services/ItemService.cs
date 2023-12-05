using KingKindProjekt.Models;

namespace KingKindProjekt.Services
{
    public class ItemService
    {
        Repository<Item> _items;
        JsonFileService<Item> _jsonFileService;
        //public ItemService()
        //{
        //    _items = new Repository<Item>();
        //}

        public ItemService(JsonFileService<Item> JsonFileService)
        {
            _items = new Repository<Item>();
            _jsonFileService = JsonFileService;
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

        public IEnumerable<Item> Items
        {
            get { return _items.Items.Values; }
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

        private void AddMockData()
        {
            Create(new Item("Name", "Branded", ItemType.Razor, "Wow, this is the best razer I have ever tried!", 199.99d, "res/KindKindLogo.png"));
            Create(new Item("Hair gel", "Other brand", ItemType.Hairgel, "Just normal hair gel.", 99.99d, ""));
            Create(new Item("Gel'ler hair", "Super brand", ItemType.Hairgel, "Nice hair gel.", 119.99d, ""));
            Create(new Item("Expensive hair gel", "Branded", ItemType.Hairgel, "Most likely the best hair gel in excistence.", 1199.99d, ""));
        }
    }
}