using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;
using DirectoryService.Shared;

namespace DirectoryService.Domain.Locations.ValueObjects;

public sealed record Address
{
    private Address(
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

    public static Result<Address, Error> Create(
        string country,
        string city,
        string street,
        int? houseNumber = null)
    {
        if (string.IsNullOrWhiteSpace(country))
            return GeneralErrors.ValueIsRequired("Country is required");
        if (country.Length < LengthConstants.MINLENGTH3 &&
            country.Length > LengthConstants.MAXLENGTH50)
            return GeneralErrors.ValueIsInvalid("Country  must be 3-50 characters.");
        
        if (string.IsNullOrWhiteSpace(city))
            return GeneralErrors.ValueIsRequired("City is required");
        if (city.Length < LengthConstants.MINLENGTH3 &&
            city.Length > LengthConstants.MAXLENGTH50)
            return GeneralErrors.ValueIsInvalid("City  must be 2-50 characters.");

        if (string.IsNullOrWhiteSpace(street))
            return GeneralErrors.ValueIsRequired("Street is required");
        if (street.Length < LengthConstants.MINLENGTH3 &&
            street.Length > LengthConstants.MAXLENGTH50)
            return GeneralErrors.ValueIsInvalid("Street  must be 2-50 characters.");

        if (houseNumber.HasValue && houseNumber.Value < 0)
            return GeneralErrors.ValueIsInvalid("HouseNumber must be greater than zero.");

        return new Address(country, city, street, houseNumber);
    }
}