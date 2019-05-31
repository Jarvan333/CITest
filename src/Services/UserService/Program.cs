using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace UserService
{
    public class Program
    {
        public static string ArgString { get; set; }

        public static void Main(string[] args)
        {
            ArgString = $"args:{JsonConvert.SerializeObject(args)}";
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(x =>
                {
                    //x.ListenLocalhost(80);
                })
                .UseStartup<Startup>();
    }
}
