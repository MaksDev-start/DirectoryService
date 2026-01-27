namespace DirectoryService.Contracts.Locations.DTOs;

public record AdressDto(
    string Country,
    string City,
    string Street,
    int? HouseNumber);