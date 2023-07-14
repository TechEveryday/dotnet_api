using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DotnetApi.Models;
using DotnetApi.Services;
using System;
using Npgsql;

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

            var connectionString = System.Environment.GetEnvironmentVariable("DATABASE_URL");
            var databasePw = System.Environment.GetEnvironmentVariable("DATABASE_PW");
            // var connectionString = "Host=localhost;Port=5432;Database=localdb;Username=user;Password=password";
            var databaseUri = new Uri(connectionString);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder = new NpgsqlConnectionStringBuilder
            // {
            //     Host = databaseUri.Host,
            //     Port = databaseUri.Port,
            //     Username = userInfo[0],
            //     Password = userInfo[1],
            //     Database = databaseUri.LocalPath.TrimStart('/')
            // };
            {
                Host = "connect-api-db.internal",
                Port = 5432,
                Username = "postgres",
                Password = databasePw,
                Database = "postgres"
            };

            services.AddDbContext<PostgresContext>(options => options.UseNpgsql(builder.ToString()));
            // options.UseNpgsql(Configuration.GetConnectionString("PostgresContext")));

            services.AddScoped<CityForecastService>();
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
