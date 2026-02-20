using CSharpFunctionalExtensions;
using DirectoryService.Domain.Locations;
using DirectoryService.Shared;

namespace DirectoryService.Application.Abstractions;

public interface ICommandHandler<TResponse, in TCommand> 
    where TCommand : ICommand
{
    Task<Result<TResponse, Error>> Handle(TCommand request, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<UnitResult<Error>> Handle(TCommand request, CancellationToken cancellationToken);
}