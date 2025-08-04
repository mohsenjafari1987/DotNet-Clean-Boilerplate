using MSN.Contract.Processes.Dtos;
using MSN.Contract.Processes.Queries;
using MSN.Contract.Processes.Responces;
using MSN.Domain.Models.Processes;
using MSN.Framework.Abstractions;
using FluentResults;

namespace MSN.Application.Process.Queries.Handlers
{
    public class GetProcessHandler : IQueryHandler<GetProcessQuery, Result<GetProcessResponse>>
    {
        private readonly IProcessRepository _processRepository;

        public GetProcessHandler(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }

        public async Task<Result<GetProcessResponse>> Handle(GetProcessQuery request, CancellationToken cancellationToken)
        {
            var processes = await _processRepository.GetProcessDetailAsync(request.processId);

            if (processes == null)
            {
                return Result.Fail("Invalid process id");
            }

            var result = new Result<GetProcessResponse>();

            var processDto = new ProcessDetailDto
            {
                Id = processes.Id,
                Title = processes.Title,
                Description = processes.Description,
                Created = processes.Created,
                CreatedBy = new UserDto
                {
                    Id = processes.CreatedBy.Id,
                    Title = processes.CreatedBy.Title,
                },
                departments = processes?.Departments.Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Title = d.Title,
                }).ToList(),
                Locations = processes?.Locations.Select(l => new LocationDto
                {
                    Id = l.Id,
                    Title = l.Title,
                }).ToList(),
                Resources = processes?.Resources.Select(r => new ResourceDto
                {
                    Id = r.Id,
                    Title = r.Title,
                }).ToList(),
                Roles = processes?.Roles.Select(r => new RoleDto
                {
                    Id = r.Id,
                    Title = r.Title,
                }).ToList()
            };

            result.WithValue(new GetProcessResponse(processDto));

            return result;
        }
    }
}