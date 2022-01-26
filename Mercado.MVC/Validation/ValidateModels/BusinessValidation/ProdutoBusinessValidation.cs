using FluentValidation;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;

namespace Mercado.MVC.Validation.ValidateModels.BusinessValidation
{
    public class ProdutoBusinessValidation : AbstractValidator<ProdutoModel>
    {

        public ProdutoBusinessValidation(ICategoriaRepository _repository)
        {

            RuleFor(x => x.IdCategoria).NotEmpty().WithMessage(ProdutoErrorMessages.IdCategoriaNulo)
                .NotNull().WithMessage(ProdutoErrorMessages.IdCategoriaNulo)
                .Must(x => _repository.GetOneById(x) != null).WithMessage(ProdutoErrorMessages.IdCategoriaInexistente);
           
        }
    }
}
