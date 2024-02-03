using MenuMaker.Api.Authentication;
using MenuMaker.Api.Services;
using MenuMaker.Domain.Interfaces;
using MenuMaker.Domain.Models.Recipes;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MenuMaker.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Configuration.AddEnvironmentVariables();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        // Swagger configuration with authorization
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "MenuMaker API", Version = "v1" });
            options.AddSecurityDefinition(Constants.ApiKeyHeaderName, new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid Api key",
                Name = Constants.ApiKeyHeaderName,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Name = Constants.ApiKeyHeaderName,
                        Type = SecuritySchemeType.ApiKey,
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = Constants.ApiKeyHeaderName
                        }
                    },
                    new string[]{}
                }
            });
        });

        builder.Services.AddSingleton<ApiKeyAuthorizationFilter>();

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
        
        // Repositories
        builder.Services.AddTransient<IRecipesRepository, RecipesRepository>();
        builder.Services.AddTransient<IGroceriesRepository, GroceriesRepository>();
        builder.Services.AddTransient<IGroceriesService, GroceriesService>();

        builder.Services.AddScoped<IUnitOfWork<RecipesContext>, RecipesContext>();

        // Application services
        builder.Services.AddTransient<IRecipesService, RecipesService>();
        builder.Services.AddTransient<IGroceriesListService, GroceriesListService>();

        builder.Services.AddHealthChecks()
            .AddDbContextCheck<RecipesContext>();

        builder.Services.AddHttpLogging(options=> { });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseHttpLogging();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthorization();

        app.MapControllers();

        app.MapHealthChecks("/health");

        app.Run();
    }
}


