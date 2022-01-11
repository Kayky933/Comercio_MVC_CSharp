using Mercado.MVC.Data;
using Mercado.MVC.Interfaces.Repository;
using Mercado.MVC.Interfaces.Service;
using Mercado.MVC.Repository;
using Mercado.MVC.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mercado.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<ICategoriaService, CaregoriaService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddDbContext<MercadoMVCContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MercadoMVCContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
