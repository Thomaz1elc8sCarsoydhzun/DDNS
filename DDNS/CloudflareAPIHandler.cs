using System.Text;
using System.Text.Json;

namespace DDNS
{
    public class CloudflareAPIHandler : IAPIHandler
    {
        private readonly string apiUrl;
        private readonly string apiKey;

        public CloudflareAPIHandler(string url, string key)
        {
            apiUrl = url;
            apiKey = key;
        }

        public async Task<string> GetDNSRecordIP(string domain, string subdomain)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            var response = await client.GetAsync($"{apiUrl}/zones/zone-id/dns_records?type=A&name={subdomain}.{domain}");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(responseBody);
            var ip = json.RootElement.GetProperty("result")[0].GetProperty("content").GetString();
            return ip;
        }

        public async Task UpdateDNSRecord(string domain, string subdomain, string ipAddress)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var content = new StringContent(JsonSerializer.Serialize(new
            {
                type = "A",
                name = $"{subdomain}.{domain}",
                content = ipAddress
            }), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{apiUrl}/zones/zone-id/dns_records/record-id", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
