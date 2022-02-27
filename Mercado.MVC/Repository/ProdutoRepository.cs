using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class ProdutoRepository : BaseRepository<ProdutoModel>, IProdutoRepository
    {
        public ProdutoRepository(MercadoMVCContext context, IConfiguration configuration) : base(context)
        {
        }
        public override IEnumerable<ProdutoModel> GetAll(Guid? id)
        {
            return GetContext().Where(x => x.Id_Usuario == id).ToList();
        }
        //public override void Update(ProdutoModel entity)
        //{
        //    string connectionString = _configuration.GetConnectionString("MercadoMVCContext");

        //    using SqlConnection connection = new(connectionString);
        //    using SqlCommand command = connection.CreateCommand();

        //    command.CommandText = "UPDATE Produtos " +
        //        "SET Descricao = @Desc, " +
        //        "Preco_Unidade = @PrecoUni, " +
        //        "Unidade_De_Medida = @UnidMed, " +
        //        "Id_Categoria = @IdCat, " +
        //        "Id_Usuario = @Id_Usuario," +
        //        "DataAddProduto = @DataEdit Where Id = " + entity.Id + " AND Id_Usuario = "+entity.Id_Usuario;

        //    command.Parameters.AddWithValue("@Desc", entity.Descricao);
        //    command.Parameters.AddWithValue("@PrecoUni", entity.Preco_Unidade);
        //    command.Parameters.AddWithValue("@UnidMed", entity.Unidade_De_Medida);
        //    command.Parameters.AddWithValue("@IdCat", entity.Id_Categoria);
        //    command.Parameters.AddWithValue("@DataEdit", entity.DataAddProduto);
        //    command.Parameters.AddWithValue("@Id_Usuario", entity.Id_Usuario);

        //    connection.Open();

        //    command.ExecuteNonQuery();

        //    connection.Close();
        //}

        public override ProdutoModel GetOneById(Guid? id)
        {
            return GetContext().Where(x => x.Id == id).FirstOrDefault();
        }
        public void Delete(ProdutoModel entity)
        {
            GetContext().Remove(entity);
            SaveDb();
        }
    }
}
