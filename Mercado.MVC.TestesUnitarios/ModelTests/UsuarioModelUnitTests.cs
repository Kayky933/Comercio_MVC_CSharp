using Mercado.MVC.TestesUnitarios.Builder;
using Mercado.MVC.Validation.ErrorMessage;
using Mercado.MVC.Validation.ValidateModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Mercado.MVC.TestesUnitarios.ModelTests
{
    public class UsuarioModelUnitTests
    {
        private readonly UsuarioValidation _validator;
        private readonly UsuarioModelBuilder _builder;
        public UsuarioModelUnitTests()
        {
            var provider = new ServiceCollection().AddScoped<UsuarioValidation>().BuildServiceProvider();
            _builder = new UsuarioModelBuilder();
            _validator = provider.GetService<UsuarioValidation>();
        }

        [Fact(DisplayName = "Classe Válida")]
        public async Task ClasseValida()
        {
            var instancia = _builder.Build();
            var validation = await _validator.ValidateAsync(instancia);
            Assert.True(validation.IsValid);
        }

        #region Nome
        [Theory(DisplayName = "Nome Válido")]
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
        public async Task NomeValido(string nome)
        {
            var instancia = _builder.With(x => x.Nome = nome).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }

        [Theory(DisplayName = "Nome Tamanho mínimo")]
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
        public async Task NomeTamanhoMinimo(string nome)
        {
            var instancia = _builder.With(x => x.Nome = nome).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.NomeTamanhoMinimo));
        }


        [Fact(DisplayName = "Nome nulo")]
        public async Task NomaFantasiaNulo()
        {
            var instancia = _builder.With(x => x.Nome = null).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.NomeNulo));
        }
        [Fact(DisplayName = "Nome vazio")]
        public async Task NomaFantasiaVazio()
        {
            var instancia = _builder.With(x => x.Nome = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.NomeNulo));
        }

        [Fact(DisplayName = "Nome Tamanho máximo")]
        public async Task NomaFantasiaTamanhoMaxio()
        {
            var instancia = _builder.With(x => x.Nome = "A".PadLeft(101)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.NomeTamanhoMaximo));
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
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.EmailTamanhoMinimo));
        }
        [Fact(DisplayName = "Email nulo")]
        public async Task EmailNulo()
        {
            var instancia = _builder.With(x => x.Email = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.EmailNulo));
        }

        [Fact(DisplayName = "Email Tamanho máximo")]
        public async Task EmailTamanhoMaximo()
        {
            var instancia = _builder.With(x => x.Email = "@gmail.com".PadLeft(101)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.EmailTamanhoMaximo));
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
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.EmailFormato));
        }
        #endregion

        #region Senha
        [Theory(DisplayName = "Senha válida")]
        [InlineData("12345678")]
        [InlineData("87654321")]
        [InlineData("kgkfdjsjkskjhkjhkhhkh")]
        [InlineData("jhbjbHBHBJHBJbhjbjbjhBJB")]
        [InlineData("LFKTNTNTNJTJTJTJTJJT")]
        [InlineData("djsjhbjhbjhbj")]
        [InlineData("knjbjhbbuygyuu")]
        public async Task SenhaValida(string senha)
        {
            var instancia = _builder.With(x => x.Senha = senha).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.True(validacao.IsValid);
        }

        [Theory(DisplayName = "Senha inválida")]
        [InlineData("123")]
        [InlineData("321")]
        [InlineData("rrggds")]
        [InlineData("ddkyaa")]
        [InlineData("rr456")]
        [InlineData("ddbui6")]
        [InlineData("1233454")]
        public async Task SenhaInvalida(string senha)
        {
            var instancia = _builder.With(x => x.Senha = senha).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.SenhaTamanhoMinimo));
        }

        [Fact(DisplayName = "Senha Nula")]
        public async Task SenhaNula()
        {
            var instancia = _builder.With(x => x.Senha = "").Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.SenhaNula));
        }
        [Fact(DisplayName = "Senha amanho máximo")]
        public async Task SenhaTamanhoMaximo()
        {
            var instancia = _builder.With(x => x.Senha = "a".PadLeft(81, 'b')).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.SenhaTamanhoMaximo));
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

        [Fact(DisplayName = "Data de nascimento inválida")]
        public async Task Data_NascimentoInvalida()
        {
            var instancia = _builder.With(x => x.Data_Nascimento = DateTime.Today.AddYears(-17)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.Data_NascimentoIdadeMinima));
        }

        [Fact(DisplayName = "Data de nascimento nula")]
        public async Task Data_NascimentoNula()
        {
            var instancia = _builder.With(x => x.Data_Nascimento = Convert.ToDateTime(null)).Build();
            var validacao = await _validator.ValidateAsync(instancia);
            Assert.False(validacao.IsValid);
            Assert.Contains(validacao.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.Data_NascimentoNula));
        }
        #endregion
    }
}
