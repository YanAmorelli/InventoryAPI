using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data.ItemRepo
{
    public class ItemRepository : IItemRepository
    {
        private readonly InventoryContext _context;

        public ItemRepository(InventoryContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Item[]> GetItemsFromInventory(int inventoryId)
        {
            IQueryable<Item> query = _context.Items;
            
            query = query.AsNoTracking()
                         .OrderBy(items => items.Id)
                         .Where(item => item.InventoryId == inventoryId);
            
            return await query.ToArrayAsync();
        }

        public async Task<Item> GetItemFromInventoryById(int id)
        {
            IQueryable<Item> query = _context.Items;

            query = query.AsNoTracking()
                .OrderBy(items => items.Id)
                .Where(item => item.Id == id);

            return await query.FirstAsync();
        }
    }
}
