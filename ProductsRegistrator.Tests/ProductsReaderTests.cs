using MongoDB.Bson;
using MongoDB.Driver;

namespace ProductsRegistrator.Tests;

public class ProductsReaderTests : IClassFixture<MongoFixture>, IAsyncLifetime
{
    private readonly IMongoDatabase _database;
    private readonly ProductsReader _reader;

    public ProductsReaderTests(MongoFixture mongoFixture)
    {
        _database = mongoFixture.MongoClient.GetDatabase("ProductsDatabase");
        _reader = new ProductsReader(_database);
    }

    public async Task InitializeAsync()
    {
        Mouse mouse = new()
        {
            Id = ObjectId.GenerateNewId(),
            Color = "Red"
        };
        Smartphone smartphone = new()
        {
            Id = ObjectId.GenerateNewId(),
            Storage = "100GB"
        };
        Product[] products = [mouse, smartphone];
        await _database
            .GetCollection<Product>("products")
            .InsertManyAsync(products);
    }

    [Fact]
    public async Task Given_a_database_should_get_all_mouses()
    {
        // Arrange
        var reader = new ProductsReader(_database);

        // Act
        var result = await reader.GetMouses();

        // Assert
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task Given_a_database_should_get_all_smartphones()
    {
        // Arrange
        var reader = new ProductsReader(_database);

        // Act
        var result = await reader.GetSmartphones();

        // Assert
        Assert.NotEmpty(result);
    }

    public Task DisposeAsync() => Task.CompletedTask;
}
