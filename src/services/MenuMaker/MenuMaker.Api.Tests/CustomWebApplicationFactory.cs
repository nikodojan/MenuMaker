using MenuMaker.Api.Tests.Stubs;
using MenuMaker.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Api.Tests;
public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var recipeRepoDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                typeof(IRecipesRepository));

            services.Remove(recipeRepoDescriptor);

            services.AddSingleton<IRecipesRepository, RecipesRepositoryStub>();
        });

        builder.UseEnvironment("Development");
    }
}
