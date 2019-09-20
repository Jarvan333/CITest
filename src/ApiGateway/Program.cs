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
            GenerateOcelotConfigFile();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration(config => config.AddInMemoryCollection(GetRoutes()))
                .ConfigureAppConfiguration(config =>config.AddJsonFile("ocelot.json"))
                .UseStartup<Startup>();

        private static void GenerateOcelotConfigFile()
        {
            var routes = GetFileReRoutes();
            FileConfiguration config=new FileConfiguration()
            {
                ReRoutes = routes
            };
            var path = "ocelot.json";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            File.WriteAllText(path,JsonConvert.SerializeObject(config));
        }

        private static KeyValuePair<string, string>[] GetRoutes()
        {
            var routes = GetFileReRoutes();
            var globalConfiguration = new FileGlobalConfiguration();
            return new[]
            {
                new KeyValuePair<string, string>("ReRoutes",JsonConvert.SerializeObject(routes)),
                new KeyValuePair<string, string>("GlobalConfiguration",JsonConvert.SerializeObject(globalConfiguration))
            };
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

    public class Source : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            if (builder.Properties.All(x => x.Key != "ReRoutes"))
            {
                builder.Properties.Add("ReRoutes", Program.GetFileReRoutes());
            }
            var provider = new OcelotProvider(builder.Properties);
            return provider;
        }
    }

    public class OcelotProvider : IConfigurationProvider
    {
        private ConfigurationReloadToken _reloadToken = new ConfigurationReloadToken();

        /// <summary>
        /// Initializes a new <see cref="T:Microsoft.Extensions.Configuration.IConfigurationProvider" />
        /// </summary>
        public OcelotProvider(IDictionary<string, object> properties)
        {
            this.Data = properties;
        }

        /// <summary>The configuration key value pairs for this provider.</summary>
        protected IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Attempts to find a value with the given key, returns true if one is found, false otherwise.
        /// </summary>
        /// <param name="key">The key to lookup.</param>
        /// <param name="value">The value found at key if one is found.</param>
        /// <returns>True if key has a value, false otherwise.</returns>
        public virtual bool TryGet(string key, out string value)
        {
            if (this.Data.TryGetValue(key, out object temp))
            {
                value = JsonConvert.SerializeObject(temp);
                return true;
            }
            value = string.Empty;
            return false;
        }

        /// <summary>Sets a value for a given key.</summary>
        /// <param name="key">The configuration key to set.</param>
        /// <param name="value">The value to set.</param>
        public virtual void Set(string key, string value)
        {
            this.Data[key] = value;
        }

        /// <summary>Loads (or reloads) the data for this provider.</summary>
        public virtual void Load()
        {
        }

        /// <summary>Returns the list of keys that this provider has.</summary>
        /// <param name="earlierKeys">The earlier keys that other providers contain.</param>
        /// <param name="parentPath">The path for the parent IConfiguration.</param>
        /// <returns>The list of keys for this provider.</returns>
        public virtual IEnumerable<string> GetChildKeys(
          IEnumerable<string> earlierKeys,
          string parentPath)
        {
            string prefix = parentPath == null ? string.Empty : parentPath + ConfigurationPath.KeyDelimiter;
            var source = this.Data.Where(x => x.Key != "FileProvider").Select(x => new KeyValuePair<string, string>(x.Key, JsonConvert.SerializeObject(x.Value))).ToList();
            var current = source.Where(kv => kv.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).Select(kv => Segment(kv.Key, prefix.Length)).ToList();
            return current.Concat(earlierKeys).OrderBy(k => k, ConfigurationKeyComparer.Instance);
        }

        private static string Segment(string key, int prefixLength)
        {
            int num = key.IndexOf(ConfigurationPath.KeyDelimiter, prefixLength, StringComparison.OrdinalIgnoreCase);
            if (num >= 0)
                return key.Substring(prefixLength, num - prefixLength);
            return key.Substring(prefixLength);
        }

        /// <summary>
        /// Returns a <see cref="T:Microsoft.Extensions.Primitives.IChangeToken" /> that can be used to listen when this provider is reloaded.
        /// </summary>
        /// <returns></returns>
        public IChangeToken GetReloadToken()
        {
            return (IChangeToken)this._reloadToken;
        }

        /// <summary>
        /// Triggers the reload change token and creates a new one.
        /// </summary>
        protected void OnReload()
        {
            Interlocked.Exchange<ConfigurationReloadToken>(ref this._reloadToken, new ConfigurationReloadToken()).OnReload();
        }
    }
}
