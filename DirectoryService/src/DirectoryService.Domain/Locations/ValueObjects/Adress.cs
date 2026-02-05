using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;

namespace DirectoryService.Domain.Locations.ValueObjects;

public sealed record Adress
{
    
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
                () => country.Length >= LengthConstants.MINLENGTH3 &&
                      country.Length <= LengthConstants.MAXLENGTH50,
                "Country  must be 2-50 characters.")
            .Ensure(
                () => !string.IsNullOrWhiteSpace(city),
                "City is required")
            .Ensure(
                () => city.Length >= LengthConstants.MINLENGTH3 &&
                      city.Length <= LengthConstants.MAXLENGTH50,
                "City  must be 2-50 characters.")
            .Ensure(
                () => !string.IsNullOrWhiteSpace(street),
                "Street is required")
            .Ensure(
                () => street.Length >= LengthConstants.MINLENGTH3 &&
                      street.Length <= LengthConstants.MAXLENGTH50,
                "Street  must be 2-50 characters.")
            .Map(() => new Adress(country, city, street, houseNumber));

    }
}