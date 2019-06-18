using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace UserService {
    public class Program {
        public static string ArgString { get; set; }

        public static void Main(string[] args) {
            ArgString = $"args:{JsonConvert.SerializeObject(args)}";
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel((x, y) =>
                {
                    y.ListenAnyIP(1500);
                    Console.WriteLine(x.HostingEnvironment.EnvironmentName);
                    //x.ListenLocalhost(80);
                })
                .UseStartup<Startup>();
    }
}
