using AddToCart.Entities;
using AddToCart.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recipes.API.Helpers;
using System.Collections.Generic;

namespace AddToCart
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=AddToCartDB;Trusted_Connection=True;";
            services.AddDbContext<AddToCartContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IAddToCartRepository, AddToCartRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            AddToCartContext addToCartContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Internal error occurred.");
                    });
                });
            }

            addToCartContext.EnsureSeedDataForContext();
            addToCartContext.EnsureSeedDataForUserContext();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IEnumerable<Entities.Category>, Models.CategoryListDto>()
                    .ConvertUsing<CategoryListConverter>();
            });

                app.UseMvc();
        }
    }
}

