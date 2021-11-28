namespace InventoryAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }


        public Item() { }

        public Item(int id, string name, string description, int quantity, int buyPrice, int sellPrice, int inventoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Quantity = quantity;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            InventoryId = inventoryId;
        }
    }
}
