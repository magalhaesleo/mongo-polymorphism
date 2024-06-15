
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

using System.Diagnostics;

using Testcontainers.MongoDb;

namespace ProductsRegistrator.Tests;

public class MongoFixture : IAsyncLifetime
{
    private readonly MongoDbContainer _container = new MongoDbBuilder().Build();

    public MongoClient GetMongoClient()
    {
        var settings = MongoClientSettings.FromConnectionString(_container.GetConnectionString());
        settings.ClusterConfigurator = buillder => buillder.Subscribe<CommandStartedEvent>(e => Debug.WriteLine("{0} - {1}", e.CommandName, e.Command.ToJson()));
        return new MongoClient(settings);
    }

    public Task InitializeAsync() => _container.StartAsync();

    public Task DisposeAsync() => _container.DisposeAsync().AsTask();
}
