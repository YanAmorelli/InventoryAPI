using InventoryAPI.Models;

namespace InventoryAPI.Data.ItemRepo
{
    public interface IItemRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Item[]> GetItemsFromInventory(int inventoryId);
        Task<Item> GetItemFromInventoryById(int id);

    }
}
