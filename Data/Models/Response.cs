using Newtonsoft.Json;

namespace Template.Data.Models
{
    public class Response
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}