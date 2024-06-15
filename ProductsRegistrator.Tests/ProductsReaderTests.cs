using MongoDB.Bson;

namespace ProductsRegistrator.Tests;

public class ProductsReaderTests(MongoFixture mongoFixture) : IClassFixture<MongoFixture>
{
    [Fact]
    public async Task Test1()
    {
        // Arrange
        var client = mongoFixture.MongoClient;
        var database = client.GetDatabase("ProductsDatabase");
        var mouse = new Mouse
        {
            Id = ObjectId.GenerateNewId(),
            Color = "Red"
        };
        await database.GetCollection<Product>("products").InsertOneAsync(mouse);
        var reader = new ProductsReader(database);

        // Act
        var result = await reader.Get();

        // Assert
        Assert.Equal(mouse, result);
    }
}
