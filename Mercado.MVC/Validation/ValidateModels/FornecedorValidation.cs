using FluentValidation;
using Mercado.MVC.Models;
using System;

namespace Mercado.MVC.Validation.ValidateModels
{
    public class FornecedorValidation : AbstractValidator<FornecedorModel>
    {
        public FornecedorValidation()
        {
            RuleFor(x => x.Razao_Social).NotEmpty().WithMessage("s")
                .NotNull().WithMessage("s")
                .MaximumLength(100).WithMessage("s")
                .MinimumLength(3).WithMessage("s");

            RuleFor(x => x.Nome_Fantasia).NotEmpty().WithMessage("s")
                .NotNull().WithMessage("s")
                .MaximumLength(100).WithMessage("s")
                .MinimumLength(3).WithMessage("s");

            RuleFor(x => x.Data_Nascimento).NotEmpty().WithMessage("s")
                .NotNull().WithMessage("s")
                .Must(x => x.GetType() == typeof(DateTime)).WithMessage("s");

            RuleFor(x => x.RG).NotEmpty().WithMessage("s")
                .NotNull().WithMessage("s")
                .Length(13).WithMessage("s");

            RuleFor(x => x.CNPJ).NotEmpty().WithMessage("s")
                .NotNull().WithMessage("s")
                .Length(18).WithMessage("s");

            RuleFor(x => x.Telefone).NotEmpty().WithMessage("s")
                .NotNull().WithMessage("s")
                .Length(13).WithMessage("s");

            RuleFor(x => x.Celular).NotEmpty().WithMessage("s")
                .NotNull().WithMessage("s")
                .Length(14).WithMessage("s");

            RuleFor(x => x.Whatsapp).NotEmpty().WithMessage("s")
               .NotNull().WithMessage("s")
               .Length(14).WithMessage("s");

            RuleFor(x => x.Email).NotEmpty().WithMessage("s")
               .NotNull().WithMessage("s")
               .EmailAddress().WithMessage("s")
               .MaximumLength(100).WithMessage("s")
               .MinimumLength(7).WithMessage("s");

            RuleFor(x => x.Ativo).NotEmpty().WithMessage("s")
               .NotNull().WithMessage("s")
               .Must(x => x.GetType() == typeof(bool)).WithMessage("s");

            RuleFor(x => x.DataCadastro).NotEmpty().WithMessage("s")
              .NotNull().WithMessage("s")
              .Must(x => x.GetType() == typeof(DateTime)).WithMessage("s");
        }
    }
}
