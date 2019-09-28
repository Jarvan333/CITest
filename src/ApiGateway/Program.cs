using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Ocelot.Configuration.File;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ocelot.json");
            GenerateOcelotConfigFile(path);
            return WebHost.CreateDefaultBuilder(args)
                 //.ConfigureAppConfiguration(config => config.AddInMemoryCollection(GetRoutes()))
                 .ConfigureAppConfiguration(config => config.AddJsonFile(path))
                 .UseStartup<Startup>();
        }


        private static void GenerateOcelotConfigFile(string path)
        {
            var routes = GetFileReRoutes();
            FileConfiguration config = new FileConfiguration()
            {
                ReRoutes = routes
            };
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(config));
        }

        public static List<FileReRoute> GetFileReRoutes()
        {
            return new List<FileReRoute>
            {
                new FileReRoute
                {
                    DownstreamPathTemplate="/api/{everything}",
                    DownstreamScheme="http",
                    DownstreamHostAndPorts = new List<FileHostAndPort>()
                    {
                        new FileHostAndPort()
                        {
                            Host = "localhost",
                            Port = 1500
                        }
                    },
                    UpstreamPathTemplate =  "/api/{everything}",
                    UpstreamHttpMethod = new List<string>(){ "Get", "Post", "Put", "Delete" }
                }
            };
        }
    }
}
