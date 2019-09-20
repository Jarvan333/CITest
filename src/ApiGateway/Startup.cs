using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using ApiGateway.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Cache;
using Ocelot.Cache.CacheManager;
using Ocelot.Configuration;
using Ocelot.Configuration.File;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

namespace ApiGateway
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IUser, User1>();
            //services.AddTransient<IUser, User2>();
            //services.AddTransient<IUser, User3>();
            services.AddMvc();
            services.AddOcelot(Configuration);

            //var cache = services.BuildServiceProvider().GetService<IOcelotCache<FileConfiguration>>();
            //cache.Add("", new FileConfiguration(){ReRoutes = Program.GetFileReRoutes()}, TimeSpan.Zero, "");
            var config = Configuration.Get(typeof(FileConfiguration));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseOcelot().Wait();
        }
    }
}
