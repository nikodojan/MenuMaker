using MenuMaker.Api.Services;
using MenuMaker.Domain.Interfaces;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MenuMaker.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Configuration.AddEnvironmentVariables();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<RecipesContext>(options =>
        {
            var cs = builder.Configuration.GetValue<string>("mm-db-connection-string");
            options.UseNpgsql(cs, pgsqlOptions =>
            {
                pgsqlOptions.MigrationsAssembly("MenuMaker.Infrastructure");
            });

            if (builder.Environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
            }
        });

        builder.Services.AddTransient<IRecipesRepository, RecipesRepository>();
        //builder.Services
        //    .AddTransient<IGenericRepository<Recipe, int>, GenericRepository<Recipe, int, RecipesContext>>();
        builder.Services
            .AddTransient<IGenericRepository<Grocery, int>, GenericRepository<Grocery, int, RecipesContext>>();
        builder.Services.AddScoped<IUnitOfWork<RecipesContext>, RecipesContext>();

        builder.Services.AddTransient<IRecipesService, RecipesService>();
        builder.Services.AddTransient<IGroceriesListService, GroceriesListService>();

        builder.Services.AddHealthChecks()
            .AddDbContextCheck<RecipesContext>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.MapHealthChecks("/health");

        app.Run();
    }
}


