using FluentValidation;
using Mercado.MVC.Models;
using Mercado.MVC.Validation.ErrorMessage;
using System;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class UsuarioValidation : AbstractValidator<UsuarioModel>
    {
        public UsuarioValidation()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage(UsuarioErrorMessages.NomeNulo)
                .NotNull().WithMessage(UsuarioErrorMessages.NomeNulo)
                .MaximumLength(100).WithMessage(UsuarioErrorMessages.NomeTamanhoMaximo)
                .MinimumLength(3).WithMessage(UsuarioErrorMessages.NomeTamanhoMinimo);

            RuleFor(x => x.Email).NotEmpty().WithMessage(UsuarioErrorMessages.EmailNulo)
                .NotNull().WithMessage(UsuarioErrorMessages.EmailNulo)
                .MaximumLength(100).WithMessage(UsuarioErrorMessages.EmailTamanhoMaximo)
                .MinimumLength(13).WithMessage(UsuarioErrorMessages.EmailTamanhoMinimo)
                .EmailAddress().WithMessage(UsuarioErrorMessages.EmailFormato);

            RuleFor(x => x.Senha).NotEmpty().WithMessage(UsuarioErrorMessages.SenhaNula)
                .NotNull().WithMessage(UsuarioErrorMessages.SenhaNula)
                .MinimumLength(8).WithMessage(UsuarioErrorMessages.SenhaTamanhoMinimo)
                .MaximumLength(80).WithMessage(UsuarioErrorMessages.SenhaTamanhoMaximo);

            RuleFor(x => x.Data_Nascimento).NotEmpty().WithMessage(UsuarioErrorMessages.Data_NascimentoNula)
               .NotNull().WithMessage(UsuarioErrorMessages.Data_NascimentoNula)
               .Must(x => x.GetType() == typeof(DateTime)).WithMessage(UsuarioErrorMessages.Data_NascimentoFormatoInvalido)
               .Must(IdadeMinima).WithMessage(UsuarioErrorMessages.Data_NascimentoIdadeMinima);

        }
        private static bool IdadeMinima(DateTime data)
        {
            return data <= DateTime.Today.AddYears(-18);
        }
    }
}
