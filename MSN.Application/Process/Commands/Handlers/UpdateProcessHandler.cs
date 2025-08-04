using MSN.Contract.Processes.Commands;
using MSN.Contract.Processes.Dtos;
using MSN.Contract.Processes.Responces;
using MSN.Domain.Interfaces;
using MSN.Domain.Models.Processes;
using MSN.Framework.Abstractions;
using FluentResults;

namespace MSN.Application.Process.Commands.Handlers
{
    public class UpdateProcessHandler : ICommandHandler<UpdateProcessCommand, FluentResults.Result<UpdateProcessResponse>>
    {
        private readonly IProcessRepository _processRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProcessHandler(IProcessRepository processRepository,IUnitOfWork unitOfWork)
        {
            _processRepository = processRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<UpdateProcessResponse>> Handle(UpdateProcessCommand request, CancellationToken cancellationToken)
        {
            var process = await _processRepository.FindById(request.Id);

            if (process == null)
            {
                return Result.Fail("Invalid process id");
            }

            process.ChangeTitle(request.Title);
            process.ChangeDescription(request.Description);

            await _unitOfWork.SaveChangesAsync();

            var result = new Result<UpdateProcessResponse>();

            var processDto = new ProcessDto
            {
                Id = process.Id,
                Title = process.Title,
                Description = process.Description,
                Created = process.Created
            };

            result.WithValue(new UpdateProcessResponse(processDto));

            return result;

        }
    }
}
