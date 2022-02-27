using FizzWare.NBuilder;
using Mercado.MVC.Models;
using Mercado.MVC.Models.Enum;
using System;

namespace Mercado.MVC.TestesUnitarios.Builder
{
    public class ClienteModelBuilder : BuilderBase<ClienteModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<ClienteModel>.CreateNew()
             .With(x => x.Ativo = true)
               .With(x => x.Nome_Fantasia = "Cleber")
               .With(x => x.Razao_Social = "Cleber")
               .With(x => x.Celular = "(11)11111-1111")
               .With(x => x.CEP = "13300-070")
               .With(x => x.CPF = "111.111.111-11")
               .With(x => x.Data_Cadastro = DateTime.Now)
               .With(x => x.Data_Nascimento = DateTime.Today.AddYears(-18))
               .With(x => x.Email = "gmail@gmail.com")
               .With(x => x.RG = "11.111.111-1")
               .With(x => x.Sexo = GeneroEnum.Masculino)
               .With(x => x.Telefone = "(11)1111-1111")
               .With(x => x.Ultima_Modificacao = DateTime.Now)
               .With(x => x.Whatsapp = "(11)11111-1111")
               .With(x => x.Bairro = "Centro")
               .With(x => x.Endereco = "Rua Santa Rita")
               .With(x => x.Numero_Casa = "10")
               .With(x => x.Complemento = "Centro de Itu")
               .With(x => x.Uf = UnidadeFederalEnum.SP);
        }
    }
}
