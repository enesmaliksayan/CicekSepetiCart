using CicekSepetiCart.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using CicekSepetiCart.Domain.Data;
using CicekSepetiCart.Application.Interfaces;
using CicekSepetiCart.Application.Services;
using CicekSepetiCart.Domain.Repositories;
using CicekSepetiCart.Infrastructure.Repositories;
using System.Linq;
using CicekSepetiCart.Domain.Providers;
using CicekSepetiCart.Infrastructure.Providers;

namespace CicekSepetiCart.API
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
            services.AddDbContext<CartDbContext>(options => options.UseSqlServer("Data Source=.;Database=CicekSepetiCartTest;Integrated Security=True"));

            services.AddScoped<ICartDbContext, CartDbContext>();
            services.AddScoped<ICartService,CartService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductProvider, ProductProvider>();
            services.AddScoped<IStockProvider, StockProvider>();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CicekSepetiCart.API", Version = "v1" }); 
            });
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CicekSepetiCart.API v1"));
            }

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
