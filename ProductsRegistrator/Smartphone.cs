namespace ProductsRegistrator;

public record Smartphone : Product
{
    public required string Storage { get; init; }
}
