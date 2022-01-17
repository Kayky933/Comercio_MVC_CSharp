using FizzWare.NBuilder;
using Mercado.MVC.Models;
using Mercado.MVC.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
               .With(x => x.DataCadastro = DateTime.UtcNow)
               .With(x => x.Data_Nascimento = DateTime.Now.AddYears(-18))
               .With(x => x.Email = "gmail@gmail.com")
               .With(x => x.RG = "11.111.111-1")
               .With(x => x.Sexo = SexoEnum.Masculino)
               .With(x => x.Telefone = "(11)1111-1111")
               .With(x => x.UltimaModificacao = DateTime.UtcNow)
               .With(x => x.Whatsapp = "(11)11111-1111")
               .With(x => x.Bairro = "Centro")
               .With(x => x.Endereco = "Rua Santa Rita")
               .With(x => x.NumeroCasa = "10")
               .With(x => x.Complemento = "Centro de Itu")
               .With(x => x.Uf = UnidadeFederalEnum.SP);
        }
    }
}
