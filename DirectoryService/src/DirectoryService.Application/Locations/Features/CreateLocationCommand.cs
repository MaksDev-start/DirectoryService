using DirectoryService.Application.Abstractions;
using DirectoryService.Contracts.Locations.DTOs;

namespace DirectoryService.Application.Locations.Features;

public record CreateLocationCommand(CreateLocationDto LocationDto) : ICommand;
