using Mercado.MVC.TestesUnitarios.Builder;
using Mercado.MVC.Validation.ErrorMessage;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Mercado.MVC.TestesUnitarios.ModelTests
{
    public class EntregaFornecedorModelTests
    {
        private readonly EntregaFornecedorModelBuilder _builder;
        private readonly EntregaFornecedorValidation _validator;
        public EntregaFornecedorModelTests()
        {
            var provider = new ServiceCollection().AddScoped<EntregaFornecedorValidation>().BuildServiceProvider();
            _builder = new EntregaFornecedorModelBuilder();
            _validator = provider.GetService<EntregaFornecedorValidation>();
        }

        [Fact(DisplayName = "Classe válida")]
        public async Task ClasseValida()
        {
            var instancia = _builder.Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }

        #region Data Entrega
        [Theory(DisplayName = "Data Deve ser válida")]
        [InlineData("10/11/2000")]
        [InlineData("10/01/1950")]
        [InlineData("12/02/2005")]
        [InlineData("11/03/2020")]
        [InlineData("04/04/2000")]
        [InlineData("10/05/2000")]
        [InlineData("10/06/2000")]
        public async Task DataValida(string data)
        {
            var instancia = _builder.With(x => x.Data_Entrega = Convert.ToDateTime(data)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "Data Deve ser válida")]
        [InlineData("10/11/2555")]
        [InlineData("10/01/2050")]
        [InlineData("12/02/3000")]
        [InlineData("11/03/4000")]
        [InlineData("04/04/5000")]
        [InlineData("10/05/2999")]
        [InlineData("10/06/4023")]
        public async Task DataFutura(string data)
        {
            var instancia = _builder.With(x => x.Data_Entrega = Convert.ToDateTime(data)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(EntregaFornecedorErrorMessages.DataFutura));
        }

        [Fact(DisplayName = "Data não pode ser nula")]
        public async Task DataNula()
        {
            var instancia = _builder.With(x => x.Data_Entrega = Convert.ToDateTime(null)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(EntregaFornecedorErrorMessages.DataNula));

        }
        #endregion

        #region Quantidade
        [Theory(DisplayName = "Quantidade deve ser válida")]
        [InlineData(333)]
        [InlineData(1453)]
        [InlineData(982)]
        [InlineData(33)]
        [InlineData(44)]
        [InlineData(128)]
        [InlineData(443)]
        public async Task QuantidadeValida(double quantidade)
        {
            var instancia = _builder.With(x => x.Quantidade = quantidade).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }
        [Fact(DisplayName = "Quantidade não pode ser nula!")]
        public async Task QuantidadetNula()
        {
            var instancia = _builder.With(x => x.Quantidade = Convert.ToDouble(null)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(EntregaFornecedorErrorMessages.QuantidadeNula));
        }
        [Theory(DisplayName = "Quantidaed não deve ser válida")]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(-6)]
        [InlineData(-5)]
        [InlineData(-4)]
        [InlineData(-3)]
        [InlineData(-2)]
        public async Task QuantiDadeInvalida(double quantidade)
        {
            var instancia = _builder.With(x => x.Quantidade = quantidade).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(EntregaFornecedorErrorMessages.QuantidadeMinima));
        }
        #endregion

        #region Valor
        [Theory(DisplayName = "Valor deve ser válido!")]
        [InlineData(10)]
        [InlineData(294)]
        [InlineData(766)]
        [InlineData(4872)]
        [InlineData(765)]
        [InlineData(998)]
        [InlineData(465)]
        public async Task ValorValido(decimal valor)
        {
            var instancia = _builder.With(x => x.Valor_Unidade = valor).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }
        [Fact(DisplayName = "Valor não deve ser nulo!")]
        public async Task ValorNulo()
        {
            var instancia = _builder.With(x => x.Valor_Unidade = Convert.ToDecimal(null)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(EntregaFornecedorErrorMessages.Valor_UnidadeNulo));
        }
        [Theory(DisplayName = "Valor negativo inválido!!")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        public async Task QuantidadeNegativa(decimal valor)
        {
            var instancia = _builder.With(x => x.Valor_Unidade = valor).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(EntregaFornecedorErrorMessages.Valor_UnidadeMinimo));
        }
        #endregion
    }
}
