using MSN.Contract.Processes.Responces;
using MSN.Framework.Abstractions;

namespace MSN.Contract.Processes.Commands;

public record UpdateProcessCommand(int Id, string Title, string? Description) : ICommand<FluentResults.Result<UpdateProcessResponse>>;