using System.Text.Json.Serialization;

namespace IpAddresses.JsonClasses
{
    public class JsonIpDate
    {
        [JsonPropertyName("command")]
        public string Command { get; set; }

        [JsonPropertyName("parameter")]
        public string Parameter { get; set; }
    }
}
