using System;
using System.CommandLine;
using System.IO;
using System.Threading.Tasks;
using DDNS;
using NLog;

namespace DDNS
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            // 创建主命令
            var rootCommand = new RootCommand("DDNS - A tool for updating DNS records dynamically.");

            // 配置文件路径选项
            var configOption = new Option<string>(
                name: "--config",
                description: "Path to the configuration file",
                getDefaultValue: () => "config.json");

            // 测试模式选项
            var testOption = new Option<bool>(
                name: "--test",
                description: "Run in test mode without updating DNS records",
                getDefaultValue: () => false);

            // 更新间隔选项
            var intervalOption = new Option<int?>(
                name: "--interval",
                description: "Override the update interval (in seconds)");

            // 添加选项到主命令
            rootCommand.AddOption(configOption);
            rootCommand.AddOption(testOption);
            rootCommand.AddOption(intervalOption);

            // 设置命令处理器
            rootCommand.SetHandler(async (config, test, interval) =>
            {
                try
                {
                    // 验证配置文件路径
                    if (!File.Exists(config))
                    {
                        Console.WriteLine($"Configuration file not found: {config}");
                        return;
                    }

                    // 加载配置文件
                    var configuration = ConfigurationManager.LoadConfiguration(config);
                    if (interval.HasValue)
                    {
                        configuration.Interval = interval.Value;
                    }

                    // 创建API处理器和更新器
                    var apiHandler = new CloudflareAPIHandler(configuration.API.URL, configuration.API.Key);
                    var updater = new DDNSUpdater(apiHandler, configuration);

                    // 测试模式
                    if (test)
                    {
                        Console.WriteLine("Running in test mode...");
                        string currentIP = await updater.GetPublicIPAddress();
                        string dnsRecordIP = await apiHandler.GetDNSRecordIP(configuration.Domain.Name, configuration.Domain.Subdomain);
                        Console.WriteLine($"Current Public IP: {currentIP}");
                        Console.WriteLine($"DNS Record IP: {dnsRecordIP}");
                        return;
                    }

                    // 开始更新
                    Console.WriteLine("Starting DDNS Updater...");
                    logger.Info("DDNSUpdater started.");
                    await updater.StartAsync();
                }
                catch (Exception ex)
                {
                    logger.Fatal(ex, "Unhandled exception occurred.");
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }, configOption, testOption, intervalOption);

            // 执行命令
            return await rootCommand.InvokeAsync(args);
        }
    }
}
