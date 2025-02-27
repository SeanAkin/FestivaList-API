using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.Models;
using FluentAssertions;

namespace FestivalShoppingApi.Test.ModelExtensionsTests;

public class ShoppingListExtensionsTests
{
    [Fact]
    public void ShoppingList_ConvertToDto_CorrectlyWithoutCategories()
    {
        var testShoppingList = new ShoppingList
        {
            GuidId = Guid.NewGuid(),
            Categories = []
        };

        var expectedDto = new ShoppingListDto
        {
            ShoppingListId = testShoppingList.GuidId,
            Categories = []
        };

        var actualDto = testShoppingList.ConvertToDto();

        actualDto.Should().BeEquivalentTo(expectedDto);
    }

    [Fact]
    public void ShoppingList_ConvertToDto_CorrectlyWithCategories()
    {
        var testShoppingList = new ShoppingList
        {
            GuidId = Guid.NewGuid(),
            Categories = new List<Category>
            {
                new()
                {
                    CategoryId = new Guid(),
                    Name = "Category 1",
                    Items = new List<Item>
                    {
                        new()
                        {
                            ItemId = Guid.NewGuid(),
                            Name = "Item 1",
                            Essential = true,
                            Url = "https://example.com/item1"
                        },
                        new()
                        {
                            ItemId = Guid.NewGuid(),
                            Name = "Item 2",
                            Essential = false,
                            Url = "https://example.com/item2"
                        }
                    }
                },
                new()
                {
                    CategoryId = new Guid(),
                    Name = "Category 2",
                    Items = []
                }
            }
        };

        var expectedDto = new ShoppingListDto
        {
            ShoppingListId = testShoppingList.GuidId,
            Categories = testShoppingList.Categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Items = c.Items.Select(i => new ItemDto
                {
                    ItemId = i.ItemId,
                    Name = i.Name,
                    Essential = i.Essential,
                    Url = i.Url
                }).ToList()
            }).ToList()
        };

        var actualDto = testShoppingList.ConvertToDto();

        actualDto.Should().BeEquivalentTo(expectedDto);
    }
}
