using MenuMaker.Api.Services;
using MenuMaker.Domain.Aggregates.RecipeAggregate;
using MenuMaker.Infrastructure.Persistence;
using MenuMaker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RecipesContext>(options =>
{
    options.UseMySql(
            builder.Configuration.GetConnectionString("mm_v1"), 
            new MySqlServerVersion(new Version(5, 7)),
            x=>x.MigrationsAssembly("MenuMaker.Infrastructure"));

    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});

builder.Services.AddTransient<IRecipesRepository, RecipesRepository>();
builder.Services
    .AddTransient<IGenericRepository<Recipe, int>, GenericRepository<Recipe, int, RecipesContext>>();
builder.Services.AddScoped<IUnitOfWork<RecipesContext>, RecipesContext>();

builder.Services.AddTransient<IRecipesService, RecipesService>();

builder.Services.AddHealthChecks()
    .AddDbContextCheck<RecipesContext>();


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

app.MapHealthChecks("/health");

app.Run();
