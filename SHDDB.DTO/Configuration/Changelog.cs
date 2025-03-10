using System.Text.Json.Serialization;

namespace SHDDB.DTO.Configuration
{
    public class Release
    {
        [JsonIgnore]
        public string Version { get; set; } = "v0.0.1";

        [JsonPropertyName("titleUpdate")]
        public string TitleUpdate { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        [JsonIgnore]
        public List<string> Notes { get; set; } = [];

        public string Uri { get; set; } = string.Empty;
    }
}
