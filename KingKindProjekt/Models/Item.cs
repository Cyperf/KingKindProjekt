﻿
namespace KingKindProjekt.Models
{
    public IWEB
    public enum ItemType
    {
        NoItem,
        Razor,
        Hairgel,
    }
    public class Item
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public ItemType Type { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string PathToImage { get; set; }
        public Item()
        {
            Name = "No name given";
            Brand = "No brand given";
            Type = ItemType.NoItem;
            Description = "No description given";
            Price = 0;
        }
        public Item(string name, string brand, ItemType type, string description, float price, string pathToImage)
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
