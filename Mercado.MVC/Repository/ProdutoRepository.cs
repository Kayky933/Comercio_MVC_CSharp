using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Mercado.MVC.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MercadoMVCContext _context;
        private readonly IConfiguration _configuration;

        public ProdutoRepository(MercadoMVCContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void Create(ProdutoModel entity)
        {
            _context.ProdutoModel.Add(entity);
            SaveChangesDb();
        }

        public void Delete(ProdutoModel entity)
        {
            _context.ProdutoModel.Remove(entity);
            SaveChangesDb();
        }

        public void Update(ProdutoModel entity)
        {
            string connectionString = _configuration.GetConnectionString("MercadoMVCContext");

            using (SqlConnection connection = new(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Produtos " +
                    "SET Descricao = @Desc," +
                    " PrecoUnidade = @PrecoUni ," +
                    " UnidadeDeMedida = @UnidMed," +
                    " IdCategoria = @IdCat " +
                    "WHERE Id = " + entity.Id;

                command.Parameters.AddWithValue("@Desc", entity.Descricao);
                command.Parameters.AddWithValue("@PrecoUni", entity.PrecoUnidade);
                command.Parameters.AddWithValue("@UnidMed", entity.UnidadeDeMedida);
                command.Parameters.AddWithValue("@IdCat", entity.IdCategoria);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public IEnumerable<ProdutoModel> GetAll()
        {
            return _context.ProdutoModel.Include(x => x.Categoria).ToList();
        }

        public ProdutoModel GetOneById(int? id)
        {
            return _context.ProdutoModel.Where(x => x.Id == id).FirstOrDefault();
        }
        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }
    }
}
