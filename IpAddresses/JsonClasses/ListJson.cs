using System.Text.Json.Serialization;

namespace IpAddresses.JsonClasses
{
    public class ListJson
    {
        [JsonPropertyName("commands")]
        public List<JsonIpDate> ipDate { get; set; }
    }
}
