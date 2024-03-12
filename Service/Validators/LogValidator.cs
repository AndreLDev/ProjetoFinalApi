using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class LogValidator : AbstractValidator<Log>
    {
        public LogValidator() 
        {
            RuleFor(c => c.CodeRobot)
                .NotEmpty().WithMessage("Please enter the CodeRobot.")
                .NotNull().WithMessage("Please enter the CodeRobot.");

            RuleFor(c => c.UserRobot)
                .NotEmpty().WithMessage("Please enter the UserRobot.")
                .NotNull().WithMessage("Please enter the UserRobot.");

            RuleFor(c => c.DateLog)
                .NotEmpty().WithMessage("Please enter the DateLog.")
                .NotNull().WithMessage("Please enter the DateLog.");

            RuleFor(c => c.Stage)
                .NotEmpty().WithMessage("Please enter the Stage.")
                .NotNull().WithMessage("Please enter the Stage.");

            RuleFor(c => c.InformationLog)
                .NotEmpty().WithMessage("Please enter the InformationLog.")
                .NotNull().WithMessage("Please enter the InformationLog.");

            RuleFor(c => c.IdProduto)
                .NotEmpty().WithMessage("Please enter the IdProduto.")
                .NotNull().WithMessage("Please enter the IdProduto.");
        }   
    }
}
