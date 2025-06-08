using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace FestivalShoppingApi.Data;

public class FestivalShoppingContext(DbContextOptions<FestivalShoppingContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<Shopper> Shoppers { get; set; }
    public DbSet<ItemStatus> ItemStatuses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder
            .Entity<ItemStatus>()
            .Property(p => p.Status)
            .HasConversion<string>();

        ShoppingListSeed.Seed(modelBuilder);
    }
}