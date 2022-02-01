using Mercado.MVC.TestesUnitarios.Builder;
using Mercado.MVC.Validation.ErrorMessage;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.Extensions.DependencyInjection;
using System;
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
            var instancia = _builder.Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        #region Razão Social
        [Theory(DisplayName = "Razão Social Válida")]
        [InlineData("Cleber")]
        [InlineData("João")]
        [InlineData("Antônio")]
        [InlineData("Anderson")]
        [InlineData("Alberto")]
        [InlineData("Carlos")]
        [InlineData("Marcos")]
        [InlineData("Júlia")]
        [InlineData("Maria")]
        [InlineData("Adriana")]
        public async Task RazaoSocialValida(string razao)
        {
            var instancia = _builder.With(x => x.Razao_Social = razao).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "Razão Social Tamanho mínimo")]
        [InlineData("qq")]
        [InlineData("sd")]
        [InlineData("as")]
        [InlineData("cc")]
        [InlineData("vv")]
        [InlineData("hh")]
        [InlineData("sf")]
        [InlineData("lk")]
        [InlineData("yt")]
        [InlineData("ee")]
        public async Task RazaoSocialTamanhoMinimo(string razao)
        {
            var instancia = _builder.With(x => x.Razao_Social = razao).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RazaoSocialTamanhoMinimo));
        }


        [Fact(DisplayName = "Razão Social nula")]
        public async Task RazaoSocialNula()
        {
            var instancia = _builder.With(x => x.Razao_Social = null).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RazaoSocialNula));
        }
        [Fact(DisplayName = "Razão Social vazia")]
        public async Task RazaoSocialVazia()
        {
            var instancia = _builder.With(x => x.Razao_Social = "").Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RazaoSocialNula));
        }

        [Fact(DisplayName = "Razão Social Tamanho máximo")]
        public async Task RazaoSocialTamanhoMaxio()
        {
            var instancia = _builder.With(x => x.Razao_Social = "A".PadLeft(101)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RazaoSocialTamanhoMaximo));
        }
        #endregion

        #region Nome Fantasia
        [Theory(DisplayName = "Nome Fantasia Válido")]
        [InlineData("Cleber")]
        [InlineData("João")]
        [InlineData("Antônio")]
        [InlineData("Anderson")]
        [InlineData("Alberto")]
        [InlineData("Carlos")]
        [InlineData("Marcos")]
        [InlineData("Júlia")]
        [InlineData("Maria")]
        [InlineData("Adriana")]
        public async Task NomeFantasiaValido(string nome)
        {
            var instancia = _builder.With(x => x.Nome_Fantasia = nome).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "Nome Fantasia Tamanho mínimo")]
        [InlineData("qq")]
        [InlineData("sd")]
        [InlineData("as")]
        [InlineData("cc")]
        [InlineData("vv")]
        [InlineData("hh")]
        [InlineData("sf")]
        [InlineData("lk")]
        [InlineData("yt")]
        [InlineData("ee")]
        public async Task NomeFantasiaTamanhoMinimo(string nome)
        {
            var instancia = _builder.With(x => x.Nome_Fantasia = nome).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.NomeFantasiaTamanhoMinimo));
        }


        [Fact(DisplayName = "Nome Fantasia nulo")]
        public async Task NomaFantasiaNulo()
        {
            var instancia = _builder.With(x => x.Nome_Fantasia = null).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.NomeFantasiaNulo));
        }
        [Fact(DisplayName = "Razão Social vazia")]
        public async Task NomaFantasiaVazio()
        {
            var instancia = _builder.With(x => x.Nome_Fantasia = "").Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.NomeFantasiaNulo));
        }

        [Fact(DisplayName = "Nome Fantasia Tamanho máximo")]
        public async Task NomaFantasiaTamanhoMaxio()
        {
            var instancia = _builder.With(x => x.Nome_Fantasia = "A".PadLeft(101)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.NomeFantasiaTamanhoMaximo));
        }
        #endregion

        #region Data de Nascimento
        [Fact(DisplayName = "Data de nascimento Válida")]
        public async Task DataNascimentoValida()
        {
            var instancia = _builder.With(x => x.Data_Nascimento = DateTime.Today.AddYears(-18)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }
        #endregion

        #region RG
        [Theory(DisplayName = "Rg Válido")]
        [InlineData("11.111.967-8")]
        [InlineData("12.224.575-7")]
        [InlineData("13.864.263-5")]
        [InlineData("14.374.986-4")]
        [InlineData("15.765.769-3")]
        [InlineData("16.958.866-2")]
        [InlineData("17.998.437-6")]
        [InlineData("18.466.456-9")]
        [InlineData("19.335.936-4")]
        [InlineData("10.243.735-2")]
        public async Task RgValido(string RG)
        {
            var instancia = _builder.With(x => x.RG = RG).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "Rg Inválido")]
        [InlineData("11.11.967-8")]
        [InlineData("12.22575-7")]
        [InlineData("13.64.23-5")]
        [InlineData("14.4.986-4")]
        [InlineData("15.75.769-3")]
        [InlineData("16.98.866-2")]
        [InlineData("17.998437-6")]
        [InlineData("1866.45-9")]
        [InlineData("19.33.936-4")]
        [InlineData("10.23.735-2")]
        public async Task RgInvalido(string RG)
        {
            var instancia = _builder.With(x => x.RG = RG).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RGTamanho));
        }

        [Fact(DisplayName = "Rg Nulo")]
        public async Task RgNulo()
        {
            var instancia = _builder.With(x => x.RG = null).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RGNulo));
        }

        [Fact(DisplayName = "Rg Vazio")]
        public async Task RgVazio()
        {
            var instancia = _builder.With(x => x.RG = "").Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RGNulo));
        }
        #endregion

        #region CPF        
        [Theory(DisplayName = "CPF Inválido")]
        [InlineData("11.000.55-00")]
        [InlineData("55.12.000-00")]
        [InlineData("88.234.000-00")]
        [InlineData("4342.33.000-663")]
        [InlineData("55555.44.000-345")]
        [InlineData("4444.01100.543-00")]
        [InlineData("566.44.000-3335")]
        [InlineData("77.3453.3451-00")]
        [InlineData("000.23.000-00")]
        [InlineData("66.11.000-00")]
        [InlineData("45.000.233-00")]
        public async Task CPFInvalido(string CPF)
        {
            var instancia = _builder.With(x => x.CPF = CPF).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.CPFTamanho));
        }

        [Theory(DisplayName = "CPF Válido")]
        [InlineData("244.123.999-33")]
        [InlineData("332.444.888-22")]
        [InlineData("555.455.777-34")]
        [InlineData("666.336.666-23")]
        [InlineData("554.999.444-11")]
        [InlineData("223.445.333-55")]
        [InlineData("553.333.222-66")]
        [InlineData("678.442.111-33")]
        public async Task CPFValido(string CPF)
        {
            var instancia = _builder.With(x => x.CPF = CPF).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }
        [Fact(DisplayName = "CPF nulo")]
        public async Task CPFNulo()
        {
            var instancia = _builder.With(x => x.CPF = "").Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.CPFNulo));
        }
        #endregion

        #region CEP

        [Theory(DisplayName = "CEP Válido")]
        [InlineData("67482-998")]
        [InlineData("88766-557")]
        [InlineData("13311-876")]
        [InlineData("13344-762")]
        [InlineData("44673-836")]
        [InlineData("86733-723")]
        [InlineData("84763-357")]
        [InlineData("26685-987")]
        [InlineData("99872-766")]
        public async Task CEPValido(string CEP)
        {
            var instancia = _builder.With(x => x.CEP = CEP).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "CEP inválido")]
        [InlineData("6748-998")]
        [InlineData("866-557")]
        [InlineData("1331876")]
        [InlineData("1334-762")]
        [InlineData("4463-836")]
        [InlineData("863-723")]
        [InlineData("8476357")]
        [InlineData("26685-7")]
        [InlineData("998266")]
        public async Task CEPInvalido(string CEP)
        {
            var instancia = _builder.With(x => x.CEP = CEP).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.CEPTamanho));
        }

        [Fact(DisplayName = "CEP nulo")]
        public async Task CEPNulo()
        {
            var instancia = _builder.With(x => x.CEP = "").Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.CEPNulo));
        }
        #endregion

        #region Bairro
        [Theory(DisplayName = "Bairro inválido")]
        [InlineData("Bairro Brasil")]
        [InlineData("Jardim Faculdade")]
        [InlineData("Centro")]
        [InlineData("Padre Bento")]
        [InlineData("Vila Nova")]
        [InlineData("Santa Tereza")]
        public async Task BairroValido(string bairro)
        {
            var instancia = _builder.With(x => x.Bairro = bairro).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "Bairro Tamanho Minimo")]
        [InlineData("ee")]
        [InlineData("qq")]
        [InlineData("rr")]
        [InlineData("aa")]
        [InlineData("ff")]
        [InlineData("hj")]
        [InlineData("kk")]
        [InlineData("tt")]
        [InlineData("yy")]
        public async Task BairroTamanhoMinimo(string bairro)
        {
            var instancia = _builder.With(x => x.Bairro = bairro).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.BairroTamanhoMinimo));
        }

        [Fact(DisplayName = "Bairro Tamanho máximo")]
        public async Task BairroTamanhoMaximo()
        {
            var instancia = _builder.With(x => x.Bairro = "A".PadLeft(101)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.BairroTamanhoMaximo));
        }

        [Fact(DisplayName = "Bairro nulo")]
        public async Task Bairronulo()
        {
            var instancia = _builder.With(x => x.Bairro = "").Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.BairroNulo));
        }
        #endregion

        #region Endedreço
        [Theory(DisplayName = "Endereco inválido")]
        [InlineData("Rua luiz Carlos Pires")]
        [InlineData("Alameda Reunidas Ip")]
        [InlineData("Rua São José")]
        [InlineData("Alameda Carlos")]
        [InlineData("Rua joão de Barro")]
        public async Task EnderecoValido(string endereco)
        {
            var instancia = _builder.With(x => x.Endereco = endereco).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "Endereco Tamanho Minimo")]
        [InlineData("eeqq")]
        [InlineData("qqw")]
        [InlineData("rr1")]
        [InlineData("aaff")]
        [InlineData("ff1")]
        [InlineData("hja")]
        [InlineData("kkw")]
        [InlineData("tt")]
        [InlineData("yy")]
        public async Task EnderecoTamanhoMinimo(string endereco)
        {
            var instancia = _builder.With(x => x.Endereco = endereco).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.EnderecoTamanhoMinimo));
        }

        [Fact(DisplayName = "Endereco Tamanho máximo")]
        public async Task EnderecoTamanhoMaximo()
        {
            var instancia = _builder.With(x => x.Endereco = "A".PadLeft(101)).Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.EnderecoTamanhoMaximo));
        }

        [Fact(DisplayName = "Endereco nulo")]
        public async Task EnderecoNulo()
        {
            var instancia = _builder.With(x => x.Endereco = "").Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.EnderecoNulo));
        }
        #endregion
    }
}
