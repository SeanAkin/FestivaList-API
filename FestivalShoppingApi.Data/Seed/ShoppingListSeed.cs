using FestivalShoppingApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalShoppingApi.Data.Seed;

public static class ShoppingListSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var shoppingList = GetSeededShoppingList();
        
        modelBuilder.Entity<ShoppingList>().HasData(new ShoppingList
        {
            GuidId = shoppingList.GuidId,
            Name = shoppingList.Name
        });
        
        var categories = shoppingList.Categories.Select(category => new Category
        {
            CategoryId = category.CategoryId,
            Name = category.Name,
            ShoppingListId = shoppingList.GuidId
        }).ToArray();

        foreach (var category in categories)
        {
            modelBuilder.Entity<Category>().HasData(category);
        }
        
        var items = shoppingList.Categories
            .SelectMany(category => category.Items)
            .Select(item => new Item
            {
                ItemId = item.ItemId,
                Name = item.Name,
                Url = item.Url,
                Essential = item.Essential,
                ShoppingListId = item.ShoppingListId,
                CategoryId = item.CategoryId
            }).ToArray();

        foreach (var item in items)
        {
            modelBuilder.Entity<Item>().HasData(item);
        }
    }
    
    private static ShoppingList GetSeededShoppingList()
    {
        var shoppingListId = Guid.NewGuid();

        var shoppingList = new ShoppingList
        {
            GuidId = shoppingListId,
            Name = "Festival Shopping List",
            Categories = new List<Category>()
        };

        var category1 = new Category
        {
            CategoryId = Guid.NewGuid(),
            Name = "Camping Gear",
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            Items = new List<Item>()
        };

        var category2 = new Category
        {
            CategoryId = Guid.NewGuid(),
            Name = "Food & Drinks",
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            Items = new List<Item>()
        };

        var category3 = new Category
        {
            CategoryId = Guid.NewGuid(),
            Name = "Clothing",
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
        };

        var item1 = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Tent",
            Url = "https://example.com/tent",
            Essential = true,
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            CategoryId = category1.CategoryId,
            Category = category1
        };

        var item2 = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Sleeping Bag",
            Url = "https://example.com/sleeping-bag",
            Essential = true,
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            CategoryId = category1.CategoryId,
            Category = category1
        };

        var item3 = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Camping Stove",
            Url = "https://example.com/camping-stove",
            Essential = false,
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            CategoryId = category1.CategoryId,
            Category = category1
        };

        var item4 = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Water Bottles",
            Url = "https://example.com/water-bottles",
            Essential = true,
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            CategoryId = category2.CategoryId,
            Category = category2
        };

        var item5 = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Snacks",
            Url = "https://example.com/snacks",
            Essential = false,
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            CategoryId = category2.CategoryId,
            Category = category2
        };

        var item6 = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Canned Food",
            Url = "https://example.com/canned-food",
            Essential = true,
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            CategoryId = category2.CategoryId,
            Category = category2
        };

        var item7 = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Rain Jacket",
            Url = "https://example.com/rain-jacket",
            Essential = true,
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            CategoryId = category3.CategoryId,
            Category = category3
        };

        var item8 = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Hiking Boots",
            Url = "https://example.com/hiking-boots",
            Essential = true,
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            CategoryId = category3.CategoryId,
            Category = category3
        };

        var item9 = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Sunglasses",
            Url = "https://example.com/sunglasses",
            Essential = false,
            ShoppingListId = shoppingListId,
            ShoppingList = shoppingList,
            CategoryId = category3.CategoryId,
            Category = category3
        };

        category1.Items.AddRange(new[] { item1, item2, item3 });
        category2.Items.AddRange(new[] { item4, item5, item6 });
        category3.Items.AddRange(new[] { item7, item8, item9 });

        shoppingList.Categories.AddRange(new[] { category1, category2, category3 });

        return shoppingList;
    }
}