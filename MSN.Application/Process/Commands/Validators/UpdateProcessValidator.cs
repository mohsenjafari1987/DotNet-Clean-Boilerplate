using MSN.Contract.Processes.Commands;
using FluentValidation;

namespace MSN.Application.Process.Commands.Validators
{
    public class UpdateProcessValidator : AbstractValidator<UpdateProcessCommand>
    {
        public UpdateProcessValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("invalid id.")
                .WithMessage("Id is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must be less than 100 characters.");

            RuleFor(x => x.Description)                
                .MaximumLength(500).WithMessage("Description must be less than 500 characters.");
        }
    }
}
