using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Questionados.Repositories;
using Questionados.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionados.NET
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
            //Agrego el contexto de la db, por defecto es scoped
            //Singleton es medio peligroso porque el db context mantiene los cambios por request
            //y la idea es que hagas un Save Final
            //De ser necesario, se puede armar un PoolContext
            //AddDbContextPool, ojo que el default es 128
            services.AddDbContext<QuestionadosContext>(options =>
            options.UseMySQL(Configuration["ConnectionStrings:DBConnection"]));


            services.AddControllers();

            //agrego el servicio SCOPED se crea uno en cada request.
            //ACA SOn clases, pero se estila que sean interfaces + la clase
            //Se necesita Scoped porque para que sea singleton el db context
            //tiene que ser singleton y el db context singleton puede traer problemas de
            //cuello de botella, en tal caso seria un pool singleton
            services.AddScoped(typeof(CategoriaService));
            services.AddScoped(typeof(PreguntaService));
            services.AddScoped(typeof(QuestionadosService));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
