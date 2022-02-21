using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Repository;
using Mercado.MVC.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Mercado.MVC.StatrUpconfig
{
    public static class ConfigureStartUp
    {
        public static void ConfigInterfaces(IServiceCollection services)
        {
            services.AddScoped<ICategoriaService, CaregoriaService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            services.AddScoped<IEntregaFornecedorService, EntregaFornecedorService>();
            services.AddScoped<IEntregaFornecedorRepository, EntregaFornecedorRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ISelectListService, SelectListService>();
        }
    }
}
