using MongoDB.Driver;

namespace ProductsRegistrator;

public class ProductsReader(IMongoDatabase database)
{
    public Task<List<Mouse>> GetMouses()
    {
        return database
            .GetCollection<Product>("products")
            .OfType<Mouse>()
            .Find(FilterDefinition<Mouse>.Empty)
            .ToListAsync();
    }

    public Task<List<Smartphone>> GetSmartphones()
    {
        return database
            .GetCollection<Product>("products")
            .OfType<Smartphone>()
            .Find(FilterDefinition<Smartphone>.Empty)
            .ToListAsync();
    }
}
