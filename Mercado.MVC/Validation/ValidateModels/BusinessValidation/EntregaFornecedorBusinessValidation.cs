using FluentValidation;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;

namespace Mercado.MVC.Validation.ValidateModels.BusinessValidation
{
    public class EntregaFornecedorBusinessValidation : AbstractValidator<EntregaFornecedorModel>
    {
        public EntregaFornecedorBusinessValidation(IFornecedorRepository _fornecedorRepository, IProdutoRepository _produtoRepository)
        {
            RuleFor(x => x.Id_Fornecedor).Must(x => _fornecedorRepository.GetOneById(x) != null).WithMessage(EntregaFornecedorErrorMessages.Id_FornecedorNaoEncontrado);

            RuleFor(x => x.Id_Produto).Must(x => _produtoRepository.GetOneById(x) != null).WithMessage(EntregaFornecedorErrorMessages.Id_ProdutoNaoEncontrado);
        }
    }
}
