using Mercado.MVC.Models.Enum;
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }

        #region Razão Social
        [Theory(DisplayName = "Razão Social deve ser Válida")]
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RazaoSocialTamanhoMinimo));
        }


        [Fact(DisplayName = "Razão Social nula")]
        public async Task RazaoSocialNula()
        {
            var instancia = _builder.With(x => x.Razao_Social = null).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RazaoSocialNula));
        }
        [Fact(DisplayName = "Razão Social vazia")]
        public async Task RazaoSocialVazia()
        {
            var instancia = _builder.With(x => x.Razao_Social = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RazaoSocialNula));
        }

        [Fact(DisplayName = "Razão Social Tamanho máximo")]
        public async Task RazaoSocialTamanhoMaxio()
        {
            var instancia = _builder.With(x => x.Razao_Social = "A".PadLeft(101)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RazaoSocialTamanhoMaximo));
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.NomeFantasiaTamanhoMinimo));
        }


        [Fact(DisplayName = "Nome Fantasia nulo")]
        public async Task NomaFantasiaNulo()
        {
            var instancia = _builder.With(x => x.Nome_Fantasia = null).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.NomeFantasiaNulo));
        }
        [Fact(DisplayName = "Razão Social vazia")]
        public async Task NomaFantasiaVazio()
        {
            var instancia = _builder.With(x => x.Nome_Fantasia = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.NomeFantasiaNulo));
        }

        [Fact(DisplayName = "Nome Fantasia Tamanho máximo")]
        public async Task NomaFantasiaTamanhoMaxio()
        {
            var instancia = _builder.With(x => x.Nome_Fantasia = "A".PadLeft(101)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.NomeFantasiaTamanhoMaximo));
        }
        #endregion

        #region Data de Nascimento
        [Fact(DisplayName = "Data de nascimento Válida")]
        public async Task Data_NascimentoValida()
        {
            var instancia = _builder.With(x => x.Data_Nascimento = DateTime.Today.AddYears(-18)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RGTamanho));
        }

        [Fact(DisplayName = "Rg Nulo")]
        public async Task RgNulo()
        {
            var instancia = _builder.With(x => x.RG = null).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RGNulo));
        }

        [Fact(DisplayName = "Rg Vazio")]
        public async Task RgVazio()
        {
            var instancia = _builder.With(x => x.RG = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.RGNulo));
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.CPFTamanho));
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }
        [Fact(DisplayName = "CPF nulo")]
        public async Task CPFNulo()
        {
            var instancia = _builder.With(x => x.CPF = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.CPFNulo));
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.CEPTamanho));
        }

        [Fact(DisplayName = "CEP nulo")]
        public async Task CEPNulo()
        {
            var instancia = _builder.With(x => x.CEP = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.CEPNulo));
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.BairroTamanhoMinimo));
        }

        [Fact(DisplayName = "Bairro Tamanho máximo")]
        public async Task BairroTamanhoMaximo()
        {
            var instancia = _builder.With(x => x.Bairro = "A".PadLeft(101)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.BairroTamanhoMaximo));
        }

        [Fact(DisplayName = "Bairro nulo")]
        public async Task Bairronulo()
        {
            var instancia = _builder.With(x => x.Bairro = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.BairroNulo));
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
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
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.EnderecoTamanhoMinimo));
        }

        [Fact(DisplayName = "Endereco Tamanho máximo")]
        public async Task EnderecoTamanhoMaximo()
        {
            var instancia = _builder.With(x => x.Endereco = "A".PadLeft(101)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.EnderecoTamanhoMaximo));
        }

        [Fact(DisplayName = "Endereco nulo")]
        public async Task EnderecoNulo()
        {
            var instancia = _builder.With(x => x.Endereco = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.EnderecoNulo));
        }
        #endregion

        #region Complemento
        [Theory(DisplayName = "Complemento deve ser válido")]
        [InlineData("Padovani")]
        [InlineData("Rua dos Ips")]
        [InlineData("Chacara grande")]
        [InlineData("rua Antonio")]
        [InlineData("Brasil")]
        [InlineData("Pista de skate")]
        [InlineData("Loja amarela")]
        public async Task ComplementoValido(string complemento)
        {
            var instancia = _builder.With(x => x.Complemento = complemento).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }

        [Theory(DisplayName = "Complemento Tamanho mínimo")]
        [InlineData("11")]
        [InlineData("kd")]
        [InlineData("ll")]
        [InlineData("88")]
        [InlineData("ga")]
        [InlineData("kk")]
        [InlineData("df")]
        public async Task ComplementoTamanhoMinimo(string complemento)
        {
            var instancia = _builder.With(x => x.Complemento = complemento).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.ComplementoTamanhoMinimo));
        }
        [Fact(DisplayName = "Complemento tamanho máximo")]
        public async Task ComplementoTamanhoMaximo()
        {
            var instancia = _builder.With(x => x.Complemento = "A".PadLeft(101)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.ComplementoTamanhoMaximo));
        }
        #endregion

        #region Unidade Federal
        [Theory(DisplayName = "unidade Federal deve ser valida")]
        [InlineData(UnidadeFederalEnum.AC)]
        [InlineData(UnidadeFederalEnum.AL)]
        [InlineData(UnidadeFederalEnum.AM)]
        [InlineData(UnidadeFederalEnum.AP)]
        [InlineData(UnidadeFederalEnum.BA)]
        [InlineData(UnidadeFederalEnum.CE)]
        [InlineData(UnidadeFederalEnum.DF)]
        [InlineData(UnidadeFederalEnum.ES)]
        [InlineData(UnidadeFederalEnum.GO)]
        [InlineData(UnidadeFederalEnum.MA)]
        [InlineData(UnidadeFederalEnum.MG)]
        [InlineData(UnidadeFederalEnum.MS)]
        [InlineData(UnidadeFederalEnum.MT)]
        [InlineData(UnidadeFederalEnum.PA)]
        [InlineData(UnidadeFederalEnum.PB)]
        [InlineData(UnidadeFederalEnum.PE)]
        [InlineData(UnidadeFederalEnum.PI)]
        [InlineData(UnidadeFederalEnum.PR)]
        [InlineData(UnidadeFederalEnum.RJ)]
        [InlineData(UnidadeFederalEnum.RN)]
        [InlineData(UnidadeFederalEnum.RO)]
        [InlineData(UnidadeFederalEnum.RR)]
        [InlineData(UnidadeFederalEnum.RS)]
        [InlineData(UnidadeFederalEnum.SC)]
        [InlineData(UnidadeFederalEnum.SE)]
        [InlineData(UnidadeFederalEnum.SP)]
        [InlineData(UnidadeFederalEnum.TO)]
        public async Task UnidadeFederalValida(UnidadeFederalEnum unidadeFederal)
        {
            var instancia = _builder.With(x => x.Uf = unidadeFederal).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }
        [Fact(DisplayName = "Unidade Federal nula")]
        public async Task UnidadeFederalNula()
        {
            var instancia = _builder.With(x => x.Uf = UnidadeFederalEnum.Selecione).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.UFNula));
        }
        #endregion

        #region Numero Casa
        [Theory(DisplayName = "Número da casa deve ser válido")]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("6")]
        [InlineData("7")]
        [InlineData("8")]
        [InlineData("444")]
        [InlineData("299")]
        [InlineData("100")]
        [InlineData("2888")]
        [InlineData("111111")]
        [InlineData("2846")]
        public async Task Numero_CasaValido(string numero)
        {
            var instancia = _builder.With(x => x.Numero_Casa = numero).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }

        [Theory(DisplayName = "Número da casa Tamanho máximo")]
        [InlineData("1111111")]
        [InlineData("2222222")]
        [InlineData("3222222")]
        [InlineData("4444444")]
        [InlineData("5555555")]
        [InlineData("6666666")]
        [InlineData("777777777")]
        [InlineData("8785644646454")]
        [InlineData("444847674365633")]
        [InlineData("29965544332676")]
        [InlineData("100222222")]
        [InlineData("28881231")]
        [InlineData("11111144977")]
        [InlineData("2846112332")]
        public async Task Numero_CasaTamanhoMaximo(string numero)
        {
            var instancia = _builder.With(x => x.Numero_Casa = numero).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.NumeroTamanhoMaximo));
        }

        [Fact(DisplayName = "Número da casa nulo")]
        public async Task Numero_CasaNulo()
        {
            var instancia = _builder.With(x => x.Numero_Casa = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.NumeroNulo));
        }
        #endregion

        #region Telefone
        [Theory(DisplayName = "Telefone válido")]
        [InlineData("(11)1234-5678")]
        [InlineData("(32)1111-1111")]
        [InlineData("(22)2222-2222")]
        [InlineData("(11)3333-3333")]
        [InlineData("(12)4444-4444")]
        [InlineData("(23)5555-5555")]
        [InlineData("(13)6666-6666")]
        [InlineData("(66)7777-7777")]
        [InlineData("(33)8888-8888")]
        public async Task TeefoneValido(string telefone)
        {
            var instancia = _builder.With(x => x.Telefone = telefone).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }

        [Theory(DisplayName = "Telefone Tamanho")]
        [InlineData("(11)123-5678")]
        [InlineData("()1234-5678")]
        [InlineData("(11)124-5678")]
        [InlineData("(11)12345678")]
        [InlineData("(11)1234-567")]
        [InlineData("(11)134-5678")]
        [InlineData("(11)1235678")]
        public async Task TelefoneTamanho(string telefone)
        {
            var instancia = _builder.With(x => x.Telefone = telefone).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.TelefoneTamanho));
        }
        #endregion

        #region Celular
        [Theory(DisplayName = "Celular válido")]
        [InlineData("(11)12344-5678")]
        [InlineData("(32)11111-1111")]
        [InlineData("(22)22222-2222")]
        [InlineData("(11)33333-3333")]
        [InlineData("(12)44444-4444")]
        [InlineData("(23)55555-5555")]
        [InlineData("(13)66666-6666")]
        [InlineData("(66)77777-7777")]
        [InlineData("(33)88888-8888")]
        public async Task CelularValido(string celular)
        {
            var instancia = _builder.With(x => x.Celular = celular).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }

        [Theory(DisplayName = "Celular Tamanho")]
        [InlineData("(11)1234-6789")]
        [InlineData("(11)1245-6789")]
        [InlineData("(11)123456789")]
        [InlineData("(11)123422256789")]
        [InlineData("(11)1235-6789")]
        [InlineData("(1)1345-6789")]
        [InlineData("(1)12345-6789")]
        [InlineData("(1)12345-689")]
        public async Task CelularTamanho(string celular)
        {
            var instancia = _builder.With(x => x.Celular = celular).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.CelularTamanho));
        }
        [Fact(DisplayName = "Celular nulo")]
        public async Task CelularNulo()
        {
            var instancia = _builder.With(x => x.Celular = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.CelularNulo));
        }
        #endregion

        #region Whatsapp
        [Theory(DisplayName = "Whatsapp válido")]
        [InlineData("(11)12344-5678")]
        [InlineData("(32)11111-1111")]
        [InlineData("(22)22222-2222")]
        [InlineData("(11)33333-3333")]
        [InlineData("(12)44444-4444")]
        [InlineData("(23)55555-5555")]
        [InlineData("(13)66666-6666")]
        [InlineData("(66)77777-7777")]
        [InlineData("(33)88888-8888")]
        public async Task WhatsappValido(string whatsapp)
        {
            var instancia = _builder.With(x => x.Whatsapp = whatsapp).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }

        [Theory(DisplayName = "Whatsapp Tamanho")]
        [InlineData("(11)1234-6789")]
        [InlineData("(11)1245-6789")]
        [InlineData("(11)123456789")]
        [InlineData("(11)123422256789")]
        [InlineData("(11)1235-6789")]
        [InlineData("(1)1345-6789")]
        [InlineData("(1)12345-6789")]
        [InlineData("(1)12345-689")]
        public async Task WhatsappTamanho(string whatsapp)
        {
            var instancia = _builder.With(x => x.Whatsapp = whatsapp).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.WhatsappTamanho));
        }
        [Fact(DisplayName = "Celular nulo")]
        public async Task WhatsappNulo()
        {
            var instancia = _builder.With(x => x.Whatsapp = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.WhatsappNulo));
        }
        #endregion

        #region Email
        [Theory(DisplayName = "Email deve ser válido")]
        [InlineData("teste@gmail.com")]
        [InlineData("123@gmail.com")]
        [InlineData("teste123@gmail.com")]
        [InlineData("emailvalido@gmail.com")]
        [InlineData("formato@gmail.com")]
        [InlineData("emailnaonulo@gmail.com")]
        [InlineData("teste@hotmail.com")]
        [InlineData("teste2@hotmail.com")]
        [InlineData("12445bhbhj@hotmail.com")]
        public async Task EmailValido(string email)
        {
            var instancia = _builder.With(x => x.Email = email).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }

        [Theory(DisplayName = "Email Tamanho mínimo")]
        [InlineData("a@gmail.com")]
        [InlineData("s@gmailm")]
        [InlineData("df@mail.com")]
        [InlineData("g@gml.com")]
        [InlineData("h@gail.com")]
        [InlineData("dn@gmilcom")]
        [InlineData("j@htmail.com")]
        [InlineData("k@hotmai.com")]
        [InlineData("l@hotmail.m")]
        public async Task EmailTamanhoMinimo(string email)
        {
            var instancia = _builder.With(x => x.Email = email).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.EmailTamanhoMinimo));
        }
        [Fact(DisplayName = "Email nulo")]
        public async Task EmailNulo()
        {
            var instancia = _builder.With(x => x.Email = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.EmailNulo));
        }

        [Fact(DisplayName = "Email Tamanho máximo")]
        public async Task EmailTamanhoMaximo()
        {
            var instancia = _builder.With(x => x.Email = "@gmail.com".PadLeft(101)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.EmailTamanhoMaximo));
        }
        [Theory(DisplayName = "Email Formato Inválido")]
        [InlineData("agmail.com")]
        [InlineData("smailm")]
        [InlineData("dfmail.com")]
        [InlineData("ggml.com")]
        [InlineData("hgail.com")]
        [InlineData("dngmilcom")]
        [InlineData("jhtmail.com")]
        [InlineData("khotmai.com")]
        [InlineData("lhotmail.m")]
        public async Task EmailFormato(string email)
        {
            var instancia = _builder.With(x => x.Email = email).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.EmailFormato));
        }
        #endregion

        #region Sexo
        [Theory(DisplayName = "Sexo deve ser válido")]
        [InlineData(GeneroEnum.Feminino)]
        [InlineData(GeneroEnum.Masculino)]
        [InlineData(GeneroEnum.Outros)]
        public async Task SexoValido(GeneroEnum sexo)
        {
            var instancia = _builder.With(x => x.Sexo = sexo).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }
        [Fact(DisplayName = "Sexo não informado")]
        public async Task SexoNulo()
        {
            var instancia = _builder.With(x => x.Sexo = GeneroEnum.Selecione).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(ClienteErrorMessages.SexoNulo));
        }

        #endregion

    }
}
