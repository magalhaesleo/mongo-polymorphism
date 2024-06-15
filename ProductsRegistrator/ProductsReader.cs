using MongoDB.Driver;

namespace ProductsRegistrator;

public class ProductsReader(IMongoDatabase database)
{
    public Task<Product> Get()
    {
        var productsCollection = database.GetCollection<Product>("products");
        return productsCollection
            .Find(FilterDefinition<Product>.Empty)
            .FirstOrDefaultAsync();
    }
}
