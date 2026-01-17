using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations.ValueObjets;

public sealed record Adress
{
    private const int MAX_LENGTH = 50;
    private const int MIN_LENGTH = 3;
    
    private Adress(
        string country,
        string city,
        string street,
        int? houseNumber = null)
    {
        Country = country;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }
    
    public string Country { get; }

    public string City { get; }

    public string Street { get; }

    public int? HouseNumber { get; }

    public static Result<Adress> Create(
        string country,
        string city, 
        string street, 
        int? houseNumber = null)
    {
        return Result.Success()
            .Ensure(
                () => !string.IsNullOrWhiteSpace(country),
                "Country is required")
            .Ensure(
                () => country.Length >= MIN_LENGTH &&
                      country.Length <= MAX_LENGTH,
                "Country  must be 2-50 characters.")
            .Ensure(
                () => !string.IsNullOrWhiteSpace(city),
                "City is required")
            .Ensure(
                () => city.Length >= MIN_LENGTH &&
                      city.Length <= MAX_LENGTH,
                "City  must be 2-50 characters.")
            .Ensure(
                () => !string.IsNullOrWhiteSpace(street),
                "Street is required")
            .Ensure(
                () => street.Length >= MIN_LENGTH &&
                      street.Length <= MAX_LENGTH,
                "Street  must be 2-50 characters.")
            .Map(() => new Adress(country, city, street, houseNumber));

    }
}