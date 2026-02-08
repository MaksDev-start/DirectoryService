namespace DirectoryService.Contracts.Locations.DTOs;

public record CreateLocationRequest(
    string Name,
    AdressDto Adress,
    string TimeZone);