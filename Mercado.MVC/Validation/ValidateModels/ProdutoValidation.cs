using FluentValidation;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class ProdutoValidation : AbstractValidator<ProdutoModel>
    {
        public ProdutoValidation(ICategoriaRepository _repository, bool editado)
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage(ProdutoErrorMessages.DescircaoProdutoNula)
                .NotNull().WithMessage(ProdutoErrorMessages.DescircaoProdutoNula)
                .MaximumLength(100).WithMessage(ProdutoErrorMessages.TamanhoMaximoDescricao)
                .MinimumLength(3).WithMessage(ProdutoErrorMessages.TamanhiMinimoDescricao);

            RuleFor(x => x.PrecoUnidade).NotEmpty().WithMessage(ProdutoErrorMessages.PrecoNulo)
                .NotNull().WithMessage(ProdutoErrorMessages.PrecoNulo)
                .GreaterThanOrEqualTo(0.99M).WithMessage(ProdutoErrorMessages.PrecoMinimo)
                .Must(x => x.GetType() == typeof(decimal)).WithMessage(ProdutoErrorMessages.PrecoFormatoInvalido);

            RuleFor(x => x.IdCategoria).NotEmpty().WithMessage(ProdutoErrorMessages.IdCategoriaNulo)
                .NotNull().WithMessage(ProdutoErrorMessages.IdCategoriaNulo)
                .Must(x => _repository.GetOneById(x) != null).WithMessage(ProdutoErrorMessages.IdCategoriaInexistente);

            RuleFor(x => x.UnidadeDeMedida).NotEmpty().WithMessage(ProdutoErrorMessages.UnidadeMedidaNula)
                .NotNull().WithMessage(ProdutoErrorMessages.UnidadeMedidaNula)
                .Must(x => x.GetType() == typeof(UnidadeMedidaEnum)).WithMessage(ProdutoErrorMessages.UnidadeMedidaFormatoInvalido)
                .Must(x => x > 0).WithMessage(ProdutoErrorMessages.UnidadeMedidaSelecionar);

            if (!editado)
                RuleFor(x => x.QuantidadeProduto).NotEmpty().WithMessage(ProdutoErrorMessages.QuantidadeProdNula)
                    .NotNull().WithMessage(ProdutoErrorMessages.QuantidadeProdNula)
                    .Must(x => x.GetType() == typeof(double)).WithMessage(ProdutoErrorMessages.QuantidadeProdFormatoInvalido)
                    .GreaterThanOrEqualTo(1).WithMessage(ProdutoErrorMessages.QuantidadeProdMinima);
        }
    }
}
