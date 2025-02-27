using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.Models;
using FluentAssertions;

namespace FestivalShoppingApi.Test.ModelExtensionsTests;

public class CategoryExtensionsTests
{
    [Fact]
    public void Category_ConvertToDto_CorrectlyWithoutItems()
    {
        var testCategory = new Category
        {
            CategoryId = Guid.NewGuid(),
            Name = "Test Category",
        };

        var expectedDto = new CategoryDto
        {
            CategoryId = testCategory.CategoryId,
            Name = testCategory.Name,
            Items = []
        };

        var actualDto = testCategory.ConvertToDto();

        actualDto.Should().BeEquivalentTo(expectedDto);
    }

    [Fact]
    public void Category_ConvertToDto_CorrectlyWithItems()
    {
        var testCategory = new Category
        {
            CategoryId = Guid.NewGuid(),
            Name = "Test Category",
            Items =
            [
                new Item
                {
                    ItemId = Guid.NewGuid(),
                    Name = "Item 1",
                    Essential = true,
                    Url = "https://example.com/item1",
                },

                new Item
                {
                    ItemId = Guid.NewGuid(),
                    Name = "Item 2",
                    Essential = false,
                    Url = "https://example.com/item2",
                }
            ]
        };

        var expectedDto = new CategoryDto
        {
            CategoryId = testCategory.CategoryId,
            Name = testCategory.Name,
            Items = testCategory.Items.Select(item => new ItemDto
            {
                ItemId = item.ItemId,
                Name = item.Name,
                Essential = item.Essential,
                Url = item.Url
            }).ToList()
        };

        var actualDto = testCategory.ConvertToDto();

        actualDto.Should().BeEquivalentTo(expectedDto);
    }
}