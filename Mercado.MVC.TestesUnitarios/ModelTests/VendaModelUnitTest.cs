using Mercado.MVC.TestesUnitarios.Builder;
using Mercado.MVC.Validation.ErrorMessage;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mercado.MVC.TestesUnitarios.ModelTests
{
    public class VendaModelUnitTest
    {
        private readonly VendaValidation _validator;
        private readonly VendaModelBuilder _builder;
        public VendaModelUnitTest()
        {
            var provider = new ServiceCollection().AddScoped<VendaValidation>().BuildServiceProvider();
            _builder = new VendaModelBuilder();
            _validator = provider.GetService<VendaValidation>();
        }
       [Fact(DisplayName ="A classe deve ser válida")]
        public async Task ClasseValida()
        {
            var instancia = _builder.Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        #region Quantidade
        [Theory(DisplayName ="Quantidade válida")]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(100)]
        [InlineData(22)]
        [InlineData(55)]
        [InlineData(93)]
        [InlineData(16)]
        [InlineData(48)]
        [InlineData(57)]
        public async Task QuantidadeValida(double quantidade)
        {
            var instancia = _builder.With(x => x.Quantidade = quantidade).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }
        [Theory(DisplayName = "Quantidade Tamanho Máximo")]
        [InlineData(10000000000)]
        [InlineData(9999999999999)]
        [InlineData(111112424638687)]
        [InlineData(886768786868682473)]
        [InlineData(44737467374374364)]
        [InlineData(93664982688752848)]
        [InlineData(1000020099988)]
        [InlineData(646688727732)]
        [InlineData(11223444444444444)]
        public async Task QuantidadeInvalidaTamanhoMaximo(double quantidade)
        {
            var instancia = _builder.With(x => x.Quantidade = quantidade).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(VendaErrorMessages.QuantidadeMaxima));
        }

        [Theory(DisplayName = "Quantidade Tamanho Minimo")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        [InlineData(-6)]
        [InlineData(-7)]
        public async Task QuantidadeInvalidaTamanhoMinimo(double quantidade)
        {
            var instancia = _builder.With(x => x.Quantidade = quantidade).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(VendaErrorMessages.QuantidadeMinima));
        }
        [Fact(DisplayName = "Quantidade válida")]
        public async Task QuantidadeInvalidaNula()
        {
            var instancia = _builder.With(x => x.Quantidade = Convert.ToDouble(null)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(VendaErrorMessages.QuantidadeNula));
        }
        #endregion

        #region Valor
        [Theory(DisplayName ="Valor venda válido")]
        [InlineData(1000000000)]
        [InlineData(334992.99)]
        [InlineData(33.44)]
        [InlineData(299784.33)]
        [InlineData(97473.22)]
        [InlineData(86554.44)]
        [InlineData(95763.33)]
        [InlineData(2874.98)]
        [InlineData(112.77)]
        public async Task ValorVendaValido(decimal valor)
        {
            var instancia = _builder.With(x => x.ValorVenda = valor).Build();
            var validation =await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        
        [Theory(DisplayName = "ValorVenda Tamanho Máximo")]
        [InlineData(10000000000)]
        [InlineData(9999999999999)]
        [InlineData(111112424638687)]
        [InlineData(886768786868682473)]
        [InlineData(44737467374374364)]
        [InlineData(93664982688752848)]
        [InlineData(1000020099988)]
        [InlineData(646688727732)]
        [InlineData(11223444444444444)]
        public async Task ValorVendaInvalidaTamanhoMaximo(decimal valor)
        {
            var instancia = _builder.With(x => x.ValorVenda = valor).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(VendaErrorMessages.ValorVendaMaximo));
        }

        [Theory(DisplayName = "valor Venda Tamanho Minimo")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        [InlineData(-6)]
        [InlineData(-7)]
        public async Task ValorVendaInvalidaTamanhoMinimo(decimal valor)
        {
            var instancia = _builder.With(x => x.ValorVenda = valor).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(VendaErrorMessages.ValorMinimo));
        }

        [Fact(DisplayName ="Valor Venda Nulo")]
        public async Task ValorVendaInvalidaNula()
        {
            var instancia = _builder.With(x => x.ValorVenda = Convert.ToDecimal(null)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(VendaErrorMessages.ValorVendaNulo));
        }
        #endregion

    }
}
