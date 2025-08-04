using MSN.Contract.Processes.Responces;
using MSN.Framework.Abstractions;

namespace MSN.Contract.Processes.Queries;

public record GetProcessQuery(int processId) : IQuery<FluentResults.Result<GetProcessResponse>>;