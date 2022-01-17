using FluentValidation;
using Mercado.MVC.Models;
using Mercado.MVC.Models.Enum;
using Mercado.MVC.Validation.ErrorMessage;
using System;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class ClienteValidation : AbstractValidator<ClienteModel>
    {
        public ClienteValidation()
        {
            RuleFor(x => x.Razao_Social).NotEmpty().WithMessage(ClienteErrorMessages.RazaoSocialNula)
               .NotNull().WithMessage(ClienteErrorMessages.RazaoSocialNula)
               .MaximumLength(100).WithMessage(ClienteErrorMessages.RazaoSocialTamanhoMaximo)
               .MinimumLength(3).WithMessage(ClienteErrorMessages.RazaoSocialTamanhoMinimo);

            RuleFor(x => x.Nome_Fantasia).NotEmpty().WithMessage(ClienteErrorMessages.NomeFantasiaNulo)
                .NotNull().WithMessage(ClienteErrorMessages.NomeFantasiaNulo)
                .MaximumLength(100).WithMessage(ClienteErrorMessages.NomeFantasiaTamanhoMaximo)
                .MinimumLength(3).WithMessage(ClienteErrorMessages.NomeFantasiaTamanhoMinimo);

            RuleFor(x => x.Data_Nascimento).NotEmpty().WithMessage(ClienteErrorMessages.DataNascimentoNula)
                .NotNull().WithMessage(ClienteErrorMessages.DataNascimentoNula)
                .Must(x => x.GetType() == typeof(DateTime)).WithMessage(ClienteErrorMessages.DataNascimentoFormatoInvalido)
                .Must(IdadeMinima).WithMessage(ClienteErrorMessages.DataNascimentoIdadeMinima);

            RuleFor(x => x.RG).NotEmpty().WithMessage(ClienteErrorMessages.RGNulo)
                .NotNull().WithMessage(ClienteErrorMessages.RGNulo)
                .Length(12).WithMessage(ClienteErrorMessages.RGTamanho);

            RuleFor(x => x.CPF).NotEmpty().WithMessage(ClienteErrorMessages.CPFNulo)
               .NotNull().WithMessage(ClienteErrorMessages.CPFNulo)
               .Length(14).WithMessage(ClienteErrorMessages.CPFTamanho);

            RuleFor(x => x.CEP).NotEmpty().WithMessage(ClienteErrorMessages.CEPNulo)
               .NotNull().WithMessage(ClienteErrorMessages.CEPNulo)
               .Length(9).WithMessage(ClienteErrorMessages.CEPTamanho);

            RuleFor(x => x.Bairro).NotEmpty().WithMessage(ClienteErrorMessages.BairroNulo)
               .NotNull().WithMessage(ClienteErrorMessages.BairroNulo)
               .MaximumLength(100).WithMessage(ClienteErrorMessages.BairroTamanhoMaximo)
               .MinimumLength(3).WithMessage(ClienteErrorMessages.BairroTamanhoMinimo);

            RuleFor(x => x.Endereco).NotEmpty().WithMessage(ClienteErrorMessages.EnderecoNulo)
               .NotNull().WithMessage(ClienteErrorMessages.EnderecoNulo)
               .MaximumLength(100).WithMessage(ClienteErrorMessages.EnderecoTamanhoMaximo)
               .MinimumLength(5).WithMessage(ClienteErrorMessages.EnderecoTamanhoMinimo);

            RuleFor(x => x.NumeroCasa).NotEmpty().WithMessage(ClienteErrorMessages.NumeroNulo)
                .NotNull().WithMessage(ClienteErrorMessages.NumeroNulo)
                .MinimumLength(1).WithMessage(ClienteErrorMessages.NumeroTamanhoMaximo)
                .MaximumLength(6).WithMessage(ClienteErrorMessages.NumeroTamanhoMinimo);

            RuleFor(x => x.Uf).NotEmpty().WithMessage(ClienteErrorMessages.UFNula)
              .NotNull().WithMessage(ClienteErrorMessages.UFNula)
              .Must(x => x.GetType() == typeof(UnidadeFederalEnum)).WithMessage(ClienteErrorMessages.UFFormatoInvalido);

            RuleFor(x => x.Complemento)
                .MaximumLength(100).WithMessage(ClienteErrorMessages.ComplementoTamanhoMaximo)
                .MinimumLength(3).WithMessage(ClienteErrorMessages.ComplementoTamanhoMinimo);

            RuleFor(x => x.Telefone)
                .Length(13).WithMessage(ClienteErrorMessages.TelefoneTamanho);

            RuleFor(x => x.Celular).NotEmpty().WithMessage(ClienteErrorMessages.CelularNulo)
                .NotNull().WithMessage(ClienteErrorMessages.CelularNulo)
                .Length(14).WithMessage(ClienteErrorMessages.CelularTamanho);

            RuleFor(x => x.Whatsapp).NotEmpty().WithMessage(ClienteErrorMessages.WhatsappNulo)
               .NotNull().WithMessage(ClienteErrorMessages.WhatsappNulo)
               .Length(14).WithMessage(ClienteErrorMessages.WhatsappTamanho);

            RuleFor(x => x.Email).NotEmpty().WithMessage(ClienteErrorMessages.EmailNulo)
                .NotNull().WithMessage(ClienteErrorMessages.EmailNulo)
                .MaximumLength(100).WithMessage(ClienteErrorMessages.EmailTamanhoMaximo)
                .MinimumLength(7).WithMessage(ClienteErrorMessages.EmailTamanhoMinimo)
                .EmailAddress().WithMessage(ClienteErrorMessages.EmailFormato);

            RuleFor(x => x.Sexo).NotEmpty().WithMessage(ClienteErrorMessages.SexoNulo)
                .NotNull().WithMessage(ClienteErrorMessages.SexoNulo)
                .Must(x => x.GetType() == typeof(SexoEnum)).WithMessage(ClienteErrorMessages.SexoFormatoInvalido);

        }
        private static bool IdadeMinima(DateTime data)
        {
            return data <= DateTime.Today.AddYears(-18);
        }
    }
}
