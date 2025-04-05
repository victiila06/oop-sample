namespace ACME.OOP.SCM.Domain.Model.ValueObjects;

public record SupplierID
{
    public string Identifier { get; init; }

    public SupplierID(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            throw new ArgumentException("Supplier ID cannot be null or empty", nameof(identifier));

        identifier = identifier;
    }
}