// Lavet af Jeppe

namespace KingKindProjekt.Models
{
    public enum ItemType
    {
        NoItem,
        Razor,
        Hairgel,
        HairDye,

    }
    public class Item
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public ItemType Type { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PathToImage { get; set; }
        public Item()
        {
            Name = "No name given ";
            Brand = "No brand given";
            Type = ItemType.NoItem;
            Description = "No description given";
            Price = 0;
        }
        public Item(string name, string brand, ItemType type, string description, double price, string pathToImage)
        {
            Name = name;
            Brand = brand;
            Type = type;
            Description = description;
            Price = price;
            PathToImage = pathToImage;
        }
    }
}
