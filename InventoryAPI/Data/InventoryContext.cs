using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Inventory>()
                .HasData(new Inventory(1, "Test", "This inventory is a mock inventory just for test"));

            builder.Entity<Item>()
                .HasData(new List<Item>()
                {
                    new Item(1, "test", "this item is a mock item just for test", 50, 100, 150, 1),
                    new Item(2, "test", "this item is a mock item just for test", 50, 100, 150, 1),
                    new Item(3, "test", "this item is a mock item just for test", 50, 100, 150, 1),
                    new Item(4, "test", "this item is a mock item just for test", 50, 100, 150, 1),
                    new Item(5, "test", "this item is a mock item just for test", 50, 100, 150, 1),
                });
        }
    }
}
