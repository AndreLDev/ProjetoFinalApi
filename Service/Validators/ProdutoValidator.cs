using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator() 
        {

            RuleFor(c => c.Desciption)
                .NotEmpty().WithMessage("Please enter the Desciption.")
                .NotNull().WithMessage("Please enter the Desciption.");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Please enter the Price.")
                .NotNull().WithMessage("Please enter the Price.");

            RuleFor(c => c.Stock)
                .NotEmpty().WithMessage("Please enter the Stock.")
                .NotNull().WithMessage("Please enter the Stock.");

            RuleFor(c => c.MinStock)
                .NotEmpty().WithMessage("Please enter the MinStock.")
                .NotNull().WithMessage("Please enter the MinStock.");

        }
    }
}
