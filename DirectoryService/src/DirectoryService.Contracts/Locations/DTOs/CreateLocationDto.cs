namespace DirectoryService.Contracts.Locations.DTOs;

public record CreateLocationDto(
    string Name,
    AdressDto Adress,
    string TimeZone);