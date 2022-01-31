using Mercado.MVC.TestesUnitarios.Builder;
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
    public class ClienteModelUnitTests
    {
        private readonly ClienteModelBuilder _builder;
        private readonly ClienteValidation _validator;

        public ClienteModelUnitTests()
        {
            var provider = new ServiceCollection().AddScoped<ClienteValidation>().BuildServiceProvider();
            _builder = new ClienteModelBuilder();
            _validator = provider.GetService<ClienteValidation>();
        }

        [Fact(DisplayName = "Classe válida")]
        public async Task ClasseValida()
        {
            var instance = _builder.Build();
            var validation = await _validator.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
    }
}
