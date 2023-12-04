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
            if (_items == null)
                _items = new Repository<Item>();
            var items = JsonFileService.GetJsonItems();
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
            //_jsonFileService.SaveJsonItems(_items.Items.Values);
        }
        public Item? Read(Item item)
        {
            return _items.Read(item.Name);
        }
        public void Update(Item item)
        {
            _items.Update(item.Name, item);
            //_jsonFileService.SaveJsonItems(_items.Items.Values);
        }
        public void Delete(Item item)
        {

            Item itemToBeDeleted = _items.Delete(item.Name);
            if (itemToBeDeleted != null)
            {
                //_jsonFileService.SaveJsonItems(_items.Items.Values);
            }
        }
    }
}