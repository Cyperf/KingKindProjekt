namespace KingKindProjekt.Services
{
    public class Repository<t>
    {
        public Dictionary<string, t> Items { get; private set; }

        public Repository()
        {
            Items = new Dictionary<string, t>();
        }

        public void Create(string id, t item)
        {
            if (Items.ContainsKey(id))
                return;
            Items.Add(id, item);
        }
        public t? Read(string id)
        {
            if (Items.ContainsKey(id))
                return Items[id];
            return default;
        }
        public void Update(string id, t item)
        {
            if (Items.ContainsKey(id))
                Items[id] = item;
        }
        public void Delete(string id)
        {
            if (Items.ContainsKey(id))
                Items.Remove(id);
        }
    }
}
