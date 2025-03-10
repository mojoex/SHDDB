using System.Text.Json.Serialization;

namespace SHDDB.DTO.Configuration
{
    public class Changelog
    {
        [JsonPropertyName("version")]
        public SemVer Version { get; set; }

        [JsonPropertyName("titleUpdate")]
        public string TitleUpdate { get; set; }

        [JsonPropertyName("releases")]
        public Dictionary<string, Release> Releases { get; set; }
    }

    public class SemVer
    {
        [JsonPropertyName("major")]
        public int Major { get; set; }

        [JsonPropertyName("minor")]
        public int Minor { get; set; }

        [JsonPropertyName("patch")]
        public int Patch { get; set; }

        [JsonPropertyName("tag")]
        public string? Tag { get; set; }

        public string AsString() => $"{Major}.{Minor}.{Patch}{(Tag != null ? $"-{Tag}" : "")}";
    }

    public class Release
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("changelog")]
        public List<string> Changelog { get; set; }
    }
}
