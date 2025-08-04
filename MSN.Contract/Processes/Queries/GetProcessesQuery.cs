using MSN.Contract.Processes.Responces;
using MSN.Framework.Abstractions;

namespace MSN.Contract.Processes.Queries;

public record GetProcessesQuery : IQuery<FluentResults.Result<GetProcessesResponse>>;