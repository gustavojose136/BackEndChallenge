
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Reviews.Data;
using Reviews.Repositorios;
using Reviews.Repositorios.Interfaces;
using System.Reflection;

namespace Reviews
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DepoimentoConnection");

            builder.Services.AddDbContext<DepoimentoContext>(opts =>
                opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                );

            builder.Services.AddScoped<IDepoimentoRepositorio, DepoimentoRepositorio>();

            builder.Services.
                    AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}