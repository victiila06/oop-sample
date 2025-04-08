namespace ACME.OOP.Procurement.Domain.Model.ValueObjects;

public record ProductId
{
    public Guid Id { get; init; }
     /// <summary>
     /// Constructor to create a ProductId with a specidic Guid.
     /// </summary>
     /// <param name="id"></param>
     /// <exception cref="ArgumentException"></exception>
    public ProductId(Guid id)
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Product ID cannot be empty.", nameof(id));
        Id = id;
    }
    
    /// <summary>
    /// Generates a new ProductId.
    /// </summary>
    /// <returns>A new ProductId instance with a </returns>
    public static ProductId New() => new(Guid.NewGuid());
}