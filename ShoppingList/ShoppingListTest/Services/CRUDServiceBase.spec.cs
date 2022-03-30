using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;
using ShoppingList.Data;
using ShoppingList.Data.Entity;
using ShoppingList.Exceptions;
using ShoppingList.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingListTest;

public class CRUDServiceBaseTest
{
    Mock<ShoppingListContext> MockContext = new Mock<ShoppingListContext>();

    Mock<DbSet<Product>> MockDbSet = new Mock<DbSet<Product>>();

    private void Setup()
    {
        MockContext.Setup(c => c.Set<Product>()).Returns(MockDbSet.Object);
        MockDbSet.Setup(s => s.AsQueryable()).Returns(PRODUCTS.BuildMock());
    }

    // Create
    [Fact]
    public async Task Should_add_item_to_database_context()
    {
        // Arrange
        Setup();
        var SUT = GetService();

        // Act
        var result = await SUT.CreateAsync(PRODUCTS.First());

        // Assert
        Assert.True(result);
        MockDbSet.Verify(s => s.Add(It.IsAny<Product>()), Times.Once());
        MockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    // Read
    [Fact]
    public async Task Should_query_database_context_for_list_of_items()
    {
        // Arrange
        Setup();
        var SUT = GetService();

        // Act
        var results = await SUT.ListAsync();

        // Assert
        Assert.Equal(PRODUCTS, results);
    }

    [Fact]
    public async Task Should_query_database_for_item_with_id()
    {
        // Arrange
        Setup();
        var SUT = GetService();
        var expected = new Product()
        {
            Id = "61fad516-1684-4eb6-b2bf-334d37fb5a81",
            Name = "test product",
            Description = "test decription"
        };

        // Act
        var result = await SUT.GetByIdAsync("61fad516-1684-4eb6-b2bf-334d37fb5a81");

        // Assert
        Assert.Equal(expected.Id, result.Id);
        Assert.Equal(expected.Name, result.Name);
        Assert.Equal(expected.Description, result.Description);
    }

    [Fact]
    public async Task Should_throw_not_found_exception_when_no_item_in_database_context()
    {
        // Arrange
        Setup();
        var SUT = GetService();
        MockDbSet.Setup(s => s.AsQueryable()).Returns(new List<Product>().BuildMock());

        // Act/Assert
        await Assert.ThrowsAsync<ItemNotFoundException>(async () => await SUT.GetByIdAsync("not found"));
    }

    // Update
    [Fact]
    public async Task Should_throw_not_found_exception_when_no_item_in_database_context_when_updating_item()
    {
        // Arrange
        Setup();
        var SUT = GetService();
        var newProduct = new Product()
        {
            Id = "not found",
            Name = "test product change name",
            Description = "test decription"
        };
        MockDbSet.Setup(s => s.AsQueryable()).Returns(new List<Product>().BuildMock());

        // Act/Assert
        await Assert.ThrowsAsync<ItemNotFoundException>(async () => await SUT.UpdateAsync(newProduct));
    }

    [Fact]
    public async Task Should_save_updated_item_in_database()
    {
        // Arrange
        Setup();
        var SUT = GetService();
        var newProduct = new Product()
        {
            Id = "61fad516-1684-4eb6-b2bf-334d37fb5a81",
            Name = "test product change name",
            Description = "test decription"
        };

        // Act
        var result = await SUT.UpdateAsync(newProduct);

        // Assert
        Assert.True(result);
        MockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    // Delete
    [Fact]
    public async Task Should_delete_item_in_database()
    {
        // Arrange
        Setup();
        var SUT = GetService();

        // Act
        var result = await SUT.DeleteAsync(PRODUCTS.First().Id);

        // Assert
        Assert.True(result);
        MockDbSet.Verify(s => s.Remove(It.IsAny<Product>()), Times.Once());
        MockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task Should_throw_not_found_exception_when_no_item_in_database_context_when_deleting_item()
    {
        // Arrange
        Setup();
        var SUT = GetService();

        MockDbSet.Setup(s => s.AsQueryable()).Returns(new List<Product>().BuildMock());

        // Act/Assert
        await Assert.ThrowsAsync<ItemNotFoundException>(async () => await SUT.GetByIdAsync("not found"));
    }

    private TestingCRUDServiceBase GetService()
    {
        return new TestingCRUDServiceBase(new Logger<CRUDServiceBase<Product>>(new Mock<ILoggerFactory>().Object), MockContext.Object);
    }

    private IEnumerable<Product> PRODUCTS = new List<Product>()
    {
        new Product
        {
            Id = "61fad516-1684-4eb6-b2bf-334d37fb5a81",
            Name = "test product",
            Description = "test decription"
        },
        new Product
        {
            Id = "ae99ec58-6deb-42d1-92e8-8eb15540f7df",
            Name = "test product 2",
            Description = "test decription 2"
        }
    };
}

public class TestingCRUDServiceBase : CRUDServiceBase<Product>
{
    public TestingCRUDServiceBase(ILogger<CRUDServiceBase<Product>> logger, ShoppingListContext context) : base(logger, context)
    {
        _eagerFetch = false;
    }
}
