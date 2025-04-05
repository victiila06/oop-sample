namespace ACME.OOP.Shared.Domain.Model.ValueObjects;

public record Address
{
    public string Street { get; init; }
    public string Number { get; init; }
    public string City { get; init; }
    
    public string StateOrRegion { get; init; }
    public string PostalCode { get; init; }
    public string Country { get; init; }

    public Address(
        string street,
        string number,
        string city,
        string postalCode,
        string? stateOrRegion,
        string country)

    {
        if(string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be null or empty", nameof(street));
        if(string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Street cannot be null or empty", nameof(number));
        if(string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be null or empty", nameof(city));
        if(string.IsNullOrWhiteSpace(stateOrRegion))
            throw new ArgumentException("StateOrRegion cannot be null or empty", nameof(stateOrRegion));
        
        if(string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("PostalCode cannot be null or empty", nameof(postalCode));
        if(string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be null or empty", nameof(country));
            
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
        
    }
}