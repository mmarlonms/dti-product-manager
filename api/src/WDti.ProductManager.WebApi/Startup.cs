using Dti.ProductManager.Data;
using Dti.ProductManager.Repository;
using Dti.ProductManager.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonteOlimpo.Base.ApiBoot;
using MonteOlimpo.Base.Core.CrossCutting;
using System.Collections.Generic;
using System.Reflection;

namespace WDti.ProductManager.WebApi
{
    public class Startup : MonteOlimpoBootStrap
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddCors();

            services.RegisterMonteOlimpoDataBase<DtiContext>(Configuration);
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); 
            base.Configure(app, env);

        }

        protected override IEnumerable<Assembly> GetAditionalAssemblies()
        {
            yield return typeof(ProdutoRepository).Assembly;
            yield return typeof(ProdutoService).Assembly;
        }
    }
}