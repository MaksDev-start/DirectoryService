using DirectoryService.Application.Abstractions;
using DirectoryService.Contracts.Locations.DTOs;

namespace DirectoryService.Application.Locations.Features;

public record CreateLocationCommand(
    string Name,
    AdressDto Adress,
    string TimeZone) : ICommand;
