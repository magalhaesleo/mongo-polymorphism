
using MongoDB.Driver;

using Testcontainers.MongoDb;

namespace ProductsRegistrator.Tests;

public class MongoFixture : IAsyncLifetime
{
    private readonly MongoDbContainer _container = new MongoDbBuilder().Build();

    public MongoClient MongoClient => new(_container.GetConnectionString());

    public Task InitializeAsync() => _container.StartAsync();

    public Task DisposeAsync() => _container.DisposeAsync().AsTask();
}
