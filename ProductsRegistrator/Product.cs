using MongoDB.Bson;

namespace ProductsRegistrator;

public abstract record Product
{
    public ObjectId Id { get; init; }
}
