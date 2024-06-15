using MongoDB.Bson.Serialization;

namespace ProductsRegistrator;

public static class BsonClassMapping
{
    public static void Initialize()
    {
        BsonClassMap.RegisterClassMap<Product>(classMap =>
        {
            classMap.AutoMap();
            classMap.SetIsRootClass(true);
        });
        BsonClassMap.RegisterClassMap<Mouse>();
        BsonClassMap.RegisterClassMap<Smartphone>();
    }
}
