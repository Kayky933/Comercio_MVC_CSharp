using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models.Enum;
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
    public class ProdutoModelUnitTests
    {
        private readonly ProdutoValidation _validator;
        private readonly ProdutoModelBuilder _builder;
        public ProdutoModelUnitTests()
        {
            var provider = new ServiceCollection().AddScoped<ProdutoValidation>().BuildServiceProvider();
            _builder = new ProdutoModelBuilder();
            _validator = provider.GetService<ProdutoValidation>();
        }

        [Fact(DisplayName = "Classe Válida")]
        public async Task ClasseValida()
        {
            var instancia = _builder.Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        #region Descrição

        [Fact(DisplayName = "Descrcição Nula")]
        public async Task DescricaoNula()
        {
            var instancia = _builder.With(x => x.Descricao = "").Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.DescircaoProdutoNula));
        }

        [Theory(DisplayName = "Descrição Tamanho mínimo")]
        [InlineData("GG")]
        [InlineData("jk")]
        [InlineData("ka")]
        [InlineData("je")]
        public async Task DescricaoTamanhoMinimo(string descricao)
        {
            var instance = _builder.With(x => x.Descricao = descricao).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.TamanhiMinimoDescricao));
        }

        [Fact(DisplayName = "Descrição tamanho máximo")]
        public async Task DescricaoTamanhoMaximo()
        {
            var descricaoTamanho = "A".PadLeft(101, 'A');
            var instance = _builder.With(x => x.Descricao = descricaoTamanho).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.TamanhoMaximoDescricao));
        }
        #endregion

        #region Preço
        [Theory(DisplayName = "PrecoUnidade válido")]
        [InlineData(12.00)]
        [InlineData(13.00)]
        [InlineData(14.00)]
        [InlineData(1.00)]
        [InlineData(400.00)]
        [InlineData(300.00)]
        [InlineData(57.00)]
        public async Task PrecoUnidadeValido(decimal preco)
        {
            var instance = _builder.With(x => x.PrecoUnidade = preco).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "PrecoUnidade inválido")]
        [InlineData(00.98)]
        [InlineData(00.97)]
        [InlineData(00.96)]
        [InlineData(00.95)]
        [InlineData(00.94)]
        [InlineData(00.93)]
        [InlineData(00.92)]
        [InlineData(00.91)]
        public async Task PrecoUnidadeInvalido(decimal preco)
        {
            var instance = _builder.With(x => x.PrecoUnidade = preco).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.PrecoMinimo));
        }
        [Fact(DisplayName = "Preço Nula inválida")]
        public async Task PrecoUnidadeNula()
        {
            var instance = _builder.With(x => x.PrecoUnidade = Convert.ToDecimal(null)).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.PrecoNulo));
        }
        #endregion

        #region Quantidade
        [Theory(DisplayName = "Quantidade inválido")]
        [InlineData(0)]
        [InlineData(00.00)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        [InlineData(-6)]
        public async Task QuantidadeInvalido(double quantidade)
        {
            var instance = _builder.With(x => x.QuantidadeProduto = quantidade).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.QuantidadeProdMinima));
        }

        [Theory(DisplayName = "Quantidade válida")]
        [InlineData(1.00)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4.00)]
        [InlineData(200.11)]
        [InlineData(2.99)]
        [InlineData(1.46)]
        [InlineData(5.66)]
        public async Task QuantidadeValida(double quantidade)
        {
            var instance = _builder.With(x => x.QuantidadeProduto = quantidade).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
        [Fact(DisplayName = "Quantidade Nula")]
        public async Task QuantidadeNula()
        {
            var instancia = _builder.With(x => x.QuantidadeProduto = Convert.ToDouble(null)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.QuantidadeProdNula));
        }
        #endregion

        #region Unidade de Medida
        [Theory(DisplayName = "Unidade de medida válida")]
        [InlineData(UnidadeMedidaEnum.Unidade)]
        [InlineData(UnidadeMedidaEnum.Duzia)]
        [InlineData(UnidadeMedidaEnum.Gramas)]
        [InlineData(UnidadeMedidaEnum.Kg)]
        [InlineData(UnidadeMedidaEnum.Litros)]
        [InlineData(UnidadeMedidaEnum.Metro)]
        [InlineData(UnidadeMedidaEnum.Saco)]
        public async Task UnidadeMedidaValida(UnidadeMedidaEnum unidade)
        {
            var instancia = _builder.With(x => x.UnidadeDeMedida = unidade).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        [Fact(DisplayName = "Unidade de Medida selecione")]
        public async Task UnidadeMedidaSelecione()
        {
            var instancia = _builder.With(x => x.UnidadeDeMedida = UnidadeMedidaEnum.Selecione).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.UnidadeMedidaSelecionar));
        }

        [Fact(DisplayName = "Unidade de Medida nula")]
        public async Task UnidadeMedidaNula()
        {
            var instancia = _builder.With(x => x.UnidadeDeMedida = UnidadeMedidaEnum.Selecione).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ProdutoErrorMessages.UnidadeMedidaNula));
        }
        #endregion

    }
}
