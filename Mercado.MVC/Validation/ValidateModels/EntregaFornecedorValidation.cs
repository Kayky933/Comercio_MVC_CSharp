using FluentValidation;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;
using System;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class EntregaFornecedorValidation : AbstractValidator<EntregaFornecedorModel>
    {
        public EntregaFornecedorValidation()
        {
            RuleFor(x => x.Data_Entrega).NotEmpty().WithMessage(EntregaFornecedorErrorMessages.DataNula)
                .NotNull().WithMessage(EntregaFornecedorErrorMessages.DataNula)
                .Must(DataFutura).WithMessage(EntregaFornecedorErrorMessages.DataFutura);

            RuleFor(x => x.Id_Fornecedor).NotEmpty().WithMessage(EntregaFornecedorErrorMessages.Id_FornecedorNulo)
                .NotNull().WithMessage(EntregaFornecedorErrorMessages.Id_FornecedorNulo)
                .Must(x => x.GetType() == typeof(Guid)).WithMessage(EntregaFornecedorErrorMessages.Id_FornecedorTipoInvalido);

            RuleFor(x => x.Id_Produto).NotEmpty().WithMessage(EntregaFornecedorErrorMessages.Id_ProdutoNulo)
                .NotNull().WithMessage(EntregaFornecedorErrorMessages.Id_ProdutoNulo)
                .Must(x => x.GetType() == typeof(Guid)).WithMessage(EntregaFornecedorErrorMessages.Id_ProdutoTipoInvalido);

            RuleFor(x => x.Quantidade).NotEmpty().WithMessage(EntregaFornecedorErrorMessages.QuantidadeNula)
                .NotNull().WithMessage(EntregaFornecedorErrorMessages.QuantidadeNula)
                .GreaterThanOrEqualTo(1).WithMessage(EntregaFornecedorErrorMessages.QuantidadeMinima)
                .LessThanOrEqualTo(1000000000).WithMessage(EntregaFornecedorErrorMessages.QuantidadeMaxima)
                .Must(x => x.GetType() == typeof(double)).WithMessage(EntregaFornecedorErrorMessages.QuantidadeTipoInvalido);

            RuleFor(x => x.Valor_Unidade).NotEmpty().WithMessage(EntregaFornecedorErrorMessages.Valor_UnidadeNulo)
                .NotNull().WithMessage(EntregaFornecedorErrorMessages.Valor_UnidadeNulo)
                .GreaterThanOrEqualTo(1).WithMessage(EntregaFornecedorErrorMessages.Valor_UnidadeMinimo)
                .LessThanOrEqualTo(1000000000).WithMessage(EntregaFornecedorErrorMessages.Valor_UnidadeMaximo)
                .Must(x => x.GetType() == typeof(decimal)).WithMessage(EntregaFornecedorErrorMessages.Valor_UnidadeTipoInvalido);
        }
        private static bool DataFutura(DateTime data)
        {
            return data <= DateTime.Now;
        }
    }
}
