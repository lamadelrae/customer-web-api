using CustomerWebApi.Application.Adapter;
using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Application.Services;
using CustomerWebApi.DomainService.Interfaces;
using CustomerWebApi.DomainService.Services;
using CustomerWebApi.Infrastructure.Data.Interfaces;
using CustomerWebApi.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CustomerWebApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerWebApi", Version = "v1" });
            });

            services.AddScoped<ICustomerApplicationService, CustomerApplicationService>();
            services.AddScoped<IAddressApplicationService, AddressApplicationService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAddressAdapter, AddressAdapter>();
            services.AddScoped<ICustomerAdapter, CustomerAdapter>();
            services.AddScoped<ICustomerAdapter, CustomerAdapter>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerWebApi v1"));
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
