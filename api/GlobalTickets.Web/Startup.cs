using GloboTickets.Web.Services;
using GloboTickets.Web.Services.EventCatalog;
using GloboTickets.Web.Services.ShoppingBasket;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
namespace GlobalTickets.Web
{
    public class Startup
    {
        private string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<EventCatalogService>();
            services.AddSingleton<IEventService, EventCatalogService>();
            services.AddSingleton<ICategoryService, EventCatalogService>();
            services.AddHttpClient<ShoppingBasketService>();
            services.AddSingleton<IBasketService, ShoppingBasketService>();
            services.AddSingleton<IBasketLineService, ShoppingBasketService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GlobalTickets.Web", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: MyAllowSpecificOrigins,
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlobalTickets.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
