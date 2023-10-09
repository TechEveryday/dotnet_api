using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using DotnetApi.Models;
using DotnetApi.Services;
using Npgsql;
using DotnetApi.Repositories;

namespace DotnetApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotnetApi", Version = "v1" });
            });

            // This is for prod
            var databasePw = System.Environment.GetEnvironmentVariable("DATABASE_PW");
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = "connect-api-db.internal",
                Port = 5432,
                Username = "postgres",
                Password = databasePw,
                Database = "postgres"
            };
            services.AddDbContext<PostgresContext>(options => options.UseNpgsql(builder.ToString()));

            // This is for dev
            // var connectionString = "Host=localhost;Port=5432;Database=postgres;Username=user;Password=password";
            // services.AddDbContext<PostgresContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<AppService>();
            services.AddScoped<AttributeService>();
            services.AddScoped<AttributeTypeService>();
            services.AddScoped<EntityService>();
            services.AddScoped<EntityTypeService>();
            services.AddScoped<RecordService>();

            services.AddScoped<AppRepository>();
            services.AddScoped<AttributeRepository>();
            services.AddScoped<AttributeTypeRepository>();
            services.AddScoped<EntityRepository>();
            services.AddScoped<EntityTypeRepository>();
            services.AddScoped<RecordRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotnetApi v1"));
            // }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
