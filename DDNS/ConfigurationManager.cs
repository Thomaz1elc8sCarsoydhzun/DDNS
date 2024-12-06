using System.Text.Json;

namespace DDNS
{
    public static class ConfigurationManager
    {
        public static Configuration LoadConfiguration(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException($"Configuration file not found: {filePath}");
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Configuration>(json);
        }
    }
}
