namespace DDNS
{
    public class Configuration
    {
        public APIConfig API { get; set; }
        public DomainConfig Domain { get; set; }
        public int Interval { get; set; } = 300;
    }
}
