using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDeBiblioteca.Data.Context;
using GerenciamentoDeBiblioteca.Data.Repositories;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoDeBiblioteca;


namespace GerenciamentoDeBiblioteca
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do DbContext
            services.AddDbContext<DataContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            // Configuração dos repositórios
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IAutorLivroRepository, AutorLivroRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Configuração do AutoMapper
            services.AddAutoMapper(typeof(Program));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library Management API", Version = "v1" });
            });

            services.AddControllers();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome do seu projeto v1");
            });
        }
    }
}