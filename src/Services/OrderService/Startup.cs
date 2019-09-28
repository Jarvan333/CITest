using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderService.Events;

namespace OrderService
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
            services.AddTransient<CapEventsHandler>();
            services.AddCap(x =>
            {
                x.UseSqlServer("Data Source=.,1433;database=CITEST.OrderDB;User=sa;Password=admin123");
                x.UseRabbitMQ(options =>
                {
                    options.HostName = "localhost";
                    options.UserName = "admin";
                    options.Password = "admin123";
                    options.ExchangeName = "citest.topic";
                });
                x.UseDashboard();
                x.DefaultGroup = $"{Assembly.GetExecutingAssembly().GetName().Name}.EventHandlers";
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
