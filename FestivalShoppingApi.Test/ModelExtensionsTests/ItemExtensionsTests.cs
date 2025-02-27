using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.Models;
using FluentAssertions;

namespace FestivalShoppingApi.Test.ModelExtensionsTests;

public class ItemExtensionsTests
{
    [Fact]
    public void Item_ConvertToDto_CorrectlyWithAllProperties()
    {
        var categoryId = Guid.NewGuid();
        var testItem = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Test Item",
            Url = "https://example.com/item",
            Essential = true,
            CategoryId = categoryId,
            Category = new Category { CategoryId = categoryId, Name = "Test Category" }
        };

        var expectedDto = new ItemDto
        {
            ItemId = testItem.ItemId,
            Name = testItem.Name,
            Url = testItem.Url,
            Essential = testItem.Essential
        };

        var actualDto = testItem.ConvertToDto();

        actualDto.Should().BeEquivalentTo(expectedDto);
    }

    [Fact]
    public void Item_ConvertToDto_CorrectlyWithoutUrl()
    {
        var categoryId = Guid.NewGuid();
        var testItem = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Test Item Without URL",
            Essential = false,
            CategoryId = categoryId,
            Category = new Category { CategoryId = categoryId, Name = "Test Category" }
        };

        var expectedDto = new ItemDto
        {
            ItemId = testItem.ItemId,
            Name = testItem.Name,
            Url = null,
            Essential = testItem.Essential
        };

        var actualDto = testItem.ConvertToDto();

        actualDto.Should().BeEquivalentTo(expectedDto);
    }
}