using FluentValidation;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class CategoriaValidation : AbstractValidator<CategoriaModel>
    {
        public CategoriaValidation()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage(CategoriaErrorMessages.DescircaoCategoriaNula)
                .MaximumLength(100).WithMessage(CategoriaErrorMessages.TamanhoMaximoDescricao)
                .MinimumLength(3).WithMessage(CategoriaErrorMessages.TamanhiMinimoDescricao);
        }
    }
}
