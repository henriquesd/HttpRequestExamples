using System.Text.Json.Serialization;

namespace HttpRequestExamples.Models
{
    public class BtcContent
    {
        [JsonPropertyName("bpi")]
        public Bpi? Bpi { get; set; }
    }

    public class Bpi
    {
        [JsonPropertyName("EUR")]
        public Eur? Eur { get; set; }
    }

    public class Eur
    {
        [JsonPropertyName("rate")]
        public string? Rate { get; set; }
    }
}