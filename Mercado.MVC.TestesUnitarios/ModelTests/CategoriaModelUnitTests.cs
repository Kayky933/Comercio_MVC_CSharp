using Mercado.MVC.TestesUnitarios.Builder;
using Mercado.MVC.Validation.ErrorMessage;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Mercado.MVC.TestesUnitarios.ModelTests
{
    public class CategoriaModelUnitTests
    {
        private readonly CategoriaModelBuilder _builder;
        private readonly CategoriaValidation _validator;

        public CategoriaModelUnitTests()
        {
            var provider = new ServiceCollection().AddScoped<CategoriaValidation>().BuildServiceProvider();
            _builder = new CategoriaModelBuilder();
            _validator = provider.GetService<CategoriaValidation>();
        }

        [Fact(DisplayName = "Classe válida")]
        public async Task ClasseValida()
        {
            var instance = _builder.Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }

        #region Descrição
        [Fact(DisplayName = "Descrcição Nula")]
        public async Task DescricaoNula()
        {
            var instancia = _builder.With(x => x.Descricao = "").Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(CategoriaErrorMessages.DescricaoCategoriaNula));
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
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(CategoriaErrorMessages.TamanhiMinimoDescricao));
        }

        [Fact(DisplayName = "Descrição tamanho máximo")]
        public async Task DescricaoTamanhoMaximo()
        {
            var descricaoTamanho = "A".PadLeft(101, 'A');
            var instance = _builder.With(x => x.Descricao = descricaoTamanho).Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(CategoriaErrorMessages.TamanhoMaximoDescricao));
        }
        #endregion

    }
}
