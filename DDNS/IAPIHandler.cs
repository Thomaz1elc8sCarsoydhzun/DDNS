namespace DDNS
{
    public interface IAPIHandler
    {
        Task<string> GetDNSRecordIP(string domain, string subdomain);
        Task UpdateDNSRecord(string domain, string subdomain, string ipAddress);
    }
}
