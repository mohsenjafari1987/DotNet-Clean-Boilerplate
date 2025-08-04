using MSN.Contract.Processes.Dtos;
using MSN.Contract.Processes.Queries;
using MSN.Contract.Processes.Responces;
using MSN.Domain.Models.Processes;
using MSN.Framework.Abstractions;
using FluentResults;

namespace MSN.Application.Process.Queries.Handlers
{
    public class GetProcessesHandler : IQueryHandler<GetProcessesQuery, Result<GetProcessesResponse>>
    {
        private readonly IProcessRepository _processRepository;

        public GetProcessesHandler(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }

            public async Task<Result<GetProcessesResponse>> Handle(GetProcessesQuery request, CancellationToken cancellationToken)
            {
                var processes = await _processRepository.GetAllProcessesAsync();
                var result = new Result<GetProcessesResponse>();

                var processDto = processes.Select(r => new ProcessDto
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    Created = r.Created               
                }).ToList();

                result.WithValue(new GetProcessesResponse(processDto));

                return result;
            }
    }
}