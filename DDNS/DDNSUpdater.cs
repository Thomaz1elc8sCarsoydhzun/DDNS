using NLog;

namespace DDNS
{
    public class DDNSUpdater
    {
        private readonly IAPIHandler apiHandler;
        private readonly Configuration config;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public DDNSUpdater(IAPIHandler handler, Configuration configuration)
        {
            apiHandler = handler;
            config = configuration;
        }

        public async Task StartAsync()
        {
            while (true)
            {
                try
                {
                    string currentIP = await GetPublicIPAddress();
                    string dnsRecordIP = await apiHandler.GetDNSRecordIP(config.Domain.Name, config.Domain.Subdomain);

                    if (currentIP == dnsRecordIP)
                    {
                        logger.Info($"No update required. Current IP ({currentIP}) matches DNS record.");
                    }
                    else
                    {
                        await apiHandler.UpdateDNSRecord(config.Domain.Name, config.Domain.Subdomain, currentIP);
                        logger.Info($"DNS record updated successfully to {currentIP}.");
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Error during DNS update.");
                }

                await Task.Delay(config.Interval * 1000);
            }
        }

        public async Task<string> GetPublicIPAddress()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://api.ipify.org");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
