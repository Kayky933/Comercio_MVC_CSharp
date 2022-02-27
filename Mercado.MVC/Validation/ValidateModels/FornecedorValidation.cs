using FluentValidation;
using Mercado.MVC.Models;
using Mercado.MVC.Models.Enum;
using Mercado.MVC.Validation.ErrorMessage;
using System;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class FornecedorValidation : AbstractValidator<FornecedorModel>
    {
        public FornecedorValidation()
        {
            RuleFor(x => x.Razao_Social).NotEmpty().WithMessage(FornecedorErrorMessages.RazaoSocialNula)
                .NotNull().WithMessage(FornecedorErrorMessages.RazaoSocialNula)
                .MaximumLength(100).WithMessage(FornecedorErrorMessages.RazaoSocialTamanhoMaximo)
                .MinimumLength(3).WithMessage(FornecedorErrorMessages.RazaoSocialTamanhoMinimo);

            RuleFor(x => x.Nome_Fantasia).NotEmpty().WithMessage(FornecedorErrorMessages.NomeFantasiaNulo)
                .NotNull().WithMessage(FornecedorErrorMessages.NomeFantasiaNulo)
                .MaximumLength(100).WithMessage(FornecedorErrorMessages.NomeFantasiaTamanhoMaximo)
                .MinimumLength(3).WithMessage(FornecedorErrorMessages.NomeFantasiaTamanhoMinimo);

            RuleFor(x => x.Data_Nascimento).NotEmpty().WithMessage(FornecedorErrorMessages.Data_NascimentoNula)
                .NotNull().WithMessage(FornecedorErrorMessages.Data_NascimentoNula)
                .Must(x => x.GetType() == typeof(DateTime)).WithMessage(FornecedorErrorMessages.Data_NascimentoFormatoInvalido)
                .Must(IdadeMinima).WithMessage(FornecedorErrorMessages.Data_NascimentoIdadeMinima);

            RuleFor(x => x.RG).NotEmpty().WithMessage(FornecedorErrorMessages.RGNulo)
                .NotNull().WithMessage(FornecedorErrorMessages.RGNulo)
                .Length(12).WithMessage(FornecedorErrorMessages.RGTamanho);

            RuleFor(x => x.CNPJ).NotEmpty().WithMessage(FornecedorErrorMessages.CNPJNulo)
               .NotNull().WithMessage(FornecedorErrorMessages.CNPJNulo)
               .Length(19).WithMessage(FornecedorErrorMessages.CNPJTamanho);

            RuleFor(x => x.CEP).NotEmpty().WithMessage(FornecedorErrorMessages.CEPNulo)
               .NotNull().WithMessage(FornecedorErrorMessages.CEPNulo)
               .Length(9).WithMessage(FornecedorErrorMessages.CEPTamanho);

            RuleFor(x => x.Bairro).NotEmpty().WithMessage(FornecedorErrorMessages.BairroNulo)
               .NotNull().WithMessage(FornecedorErrorMessages.BairroNulo)
               .MaximumLength(100).WithMessage(FornecedorErrorMessages.BairroTamanhoMaximo)
               .MinimumLength(3).WithMessage(FornecedorErrorMessages.BairroTamanhoMinimo);

            RuleFor(x => x.Endereco).NotEmpty().WithMessage(FornecedorErrorMessages.EnderecoNulo)
               .NotNull().WithMessage(FornecedorErrorMessages.EnderecoNulo)
               .MaximumLength(100).WithMessage(FornecedorErrorMessages.EnderecoTamanhoMaximo)
               .MinimumLength(5).WithMessage(FornecedorErrorMessages.EnderecoTamanhoMinimo);

            RuleFor(x => x.Numero_Casa).NotEmpty().WithMessage(FornecedorErrorMessages.NumeroNulo)
                .NotNull().WithMessage(FornecedorErrorMessages.NumeroNulo)
                .MinimumLength(1).WithMessage(FornecedorErrorMessages.NumeroTamanhoMinimo)
                .MaximumLength(6).WithMessage(FornecedorErrorMessages.NumeroTamanhoMaximo);

            RuleFor(x => x.Uf).NotEmpty().WithMessage(FornecedorErrorMessages.UFNula)
              .NotNull().WithMessage(FornecedorErrorMessages.UFNula)
              .Must(x => x.GetType() == typeof(UnidadeFederalEnum)).WithMessage(FornecedorErrorMessages.UFFormatoInvalido);

            RuleFor(x => x.Complemento)
                .MaximumLength(100).WithMessage(FornecedorErrorMessages.ComplementoTamanhoMaximo)
                .MinimumLength(3).WithMessage(FornecedorErrorMessages.ComplementoTamanhoMinimo);

            RuleFor(x => x.Telefone)
                .Length(13).WithMessage(FornecedorErrorMessages.TelefoneTamanho);

            RuleFor(x => x.Celular).NotEmpty().WithMessage(FornecedorErrorMessages.CelularNulo)
                .NotNull().WithMessage(FornecedorErrorMessages.CelularNulo)
                .Length(14).WithMessage(FornecedorErrorMessages.CelularTamanho);

            RuleFor(x => x.Whatsapp).NotEmpty().WithMessage(FornecedorErrorMessages.WhatsappNulo)
               .NotNull().WithMessage(FornecedorErrorMessages.WhatsappNulo)
               .Length(14).WithMessage(FornecedorErrorMessages.WhatsappTamanho);

            RuleFor(x => x.Email).NotEmpty().WithMessage(FornecedorErrorMessages.EmailNulo)
                .NotNull().WithMessage(FornecedorErrorMessages.EmailNulo)
                .MaximumLength(100).WithMessage(FornecedorErrorMessages.EmailTamanhoMaximo)
                .MinimumLength(13).WithMessage(FornecedorErrorMessages.EmailTamanhoMinimo)
                .EmailAddress().WithMessage(FornecedorErrorMessages.EmailFormato);

            RuleFor(x => x.Sexo).NotEmpty().WithMessage(FornecedorErrorMessages.SexoNulo)
                .NotNull().WithMessage(FornecedorErrorMessages.SexoNulo)
                .Must(x => x.GetType() == typeof(GeneroEnum)).WithMessage(FornecedorErrorMessages.SexoFormatoInvalido);
        }
        private static bool IdadeMinima(DateTime data)
        {
            return data <= DateTime.Today.AddYears(-18);
        }
    }
}
