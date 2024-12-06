using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using NLog;

namespace DDNS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            try
            {
                string configPath = args.Length != 0 ? args[0] : "config.json";
                var config = ConfigurationManager.LoadConfiguration(configPath);

                var apiHandler = new CloudflareAPIHandler(config.API.URL, config.API.Key);
                var updater = new DDNSUpdater(apiHandler, config);

                logger.Info("DDNSUpdater started.");
                await updater.StartAsync();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Unhandled exception occurred.");
            }
        }
    }
}
