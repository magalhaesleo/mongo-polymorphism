using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsRegistrator;

[BsonKnownTypes(typeof(Mouse), typeof(Smartphone))]
public abstract record Product
{
    public required ObjectId Id { get; init; }
}
