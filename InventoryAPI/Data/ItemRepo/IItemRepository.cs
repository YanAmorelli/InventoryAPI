using InventoryAPI.Models;

namespace InventoryAPI.Data.ItemRepo
{
    public interface IItemRepository
    {
        Task<Item[]> GetItemsFromInventory(int inventoryId);
        Task<Item> GetItemFromInventoryById(int id);

    }
}
