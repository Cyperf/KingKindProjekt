
// Lavet af Jeppe

namespace KingKindProjekt.Services
{
    public class Repository<T>
    {
        public Dictionary<string, T> Items { get; private set; }

        public Repository()
        {
            Items = new Dictionary<string, T>();
        }

        public void Create(string id, T item)
        {
            if (Items.ContainsKey(id))
                return;
            Items.Add(id, item);
        }
        public T? Read(string id)
        {
            if (Items.ContainsKey(id))
                return Items[id];
            return default;
        }
        public void Update(string id, T item)
        {
            if (Items.ContainsKey(id))
                Items[id] = item;
        }
        public T Delete(string id)
        {
            if (Items.ContainsKey(id))
            {
                T i = Items[id];
                Items.Remove(id);
                return i;
            }
            return default;
        }
        public bool Contains(string id)
        {
            return Items.ContainsKey(id);
        }
    }
}
