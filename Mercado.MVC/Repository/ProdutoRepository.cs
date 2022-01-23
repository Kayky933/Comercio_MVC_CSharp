using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class ProdutoRepository : BaseRepository<ProdutoModel>, IProdutoRepository
    {

        public ProdutoRepository(MercadoMVCContext context) : base(context)
        {
        }

        public override void Update(ProdutoModel entity)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=MercadoMVCContext-650fb4fd-e2db-451a-8dd5-04bfe149e548;Trusted_Connection=True;MultipleActiveResultSets=true";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = connection.CreateCommand();

            command.CommandText = "UPDATE Produtos " +
                "SET Descricao = @Desc," +
                " PrecoUnidade = @PrecoUni ," +
                " UnidadeDeMedida = @UnidMed," +
                " IdCategoria = @IdCat, " +
                "DataAddProduto = @DataEdit Where Id = " + entity.Id;

            command.Parameters.AddWithValue("@Desc", entity.Descricao);
            command.Parameters.AddWithValue("@PrecoUni", entity.PrecoUnidade);
            command.Parameters.AddWithValue("@UnidMed", entity.UnidadeDeMedida);
            command.Parameters.AddWithValue("@IdCat", entity.IdCategoria);
            command.Parameters.AddWithValue("@DataEdit", entity.DataAddProduto);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        public override ProdutoModel GetOneById(int? id)
        {
            return GetContext().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
