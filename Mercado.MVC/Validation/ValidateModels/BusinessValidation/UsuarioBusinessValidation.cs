using FluentValidation;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;

namespace Mercado.MVC.Validation.ValidateModels.BusinessValidation
{
    public class UsuarioBusinessValidation : AbstractValidator<UsuarioModel>
    {
        public UsuarioBusinessValidation(IUsuarioRepository _usuarioRepository)
        {
            When(x => _usuarioRepository.GetByEmail(x.Email)?.Id != x.Id, () =>
            {
                RuleFor(x => x.Email).Must(email => _usuarioRepository.GetByEmail(email) == null).WithMessage(UsuarioErrorMessages.EmailJaCadastrado);
            });
        }
    }
}
