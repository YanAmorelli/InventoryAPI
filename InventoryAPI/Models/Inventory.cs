namespace InventoryAPI.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string InventoryName { get; set; }
        public string InventoryDescription { get; set; }
        public virtual List<Item> Items { get; set; }

        public Inventory() { }
        
        public Inventory(int id, string inventoryName, string inventoryDescription)
        {
            Id = id;
            InventoryName = inventoryName;
            InventoryDescription = inventoryDescription;
        }
    }
}
