using EastWestTest.Domain.Interfaces;
using EastWestTest.Infrastructure.Business;
using EastWestTest.Infrastructure.Data;
using EastWestTest.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace EastWestTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderFilter, OrderListFilter>();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(connection));

            services.AddMvc().AddJsonOptions(jsonOpions =>
            {
                jsonOpions.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
