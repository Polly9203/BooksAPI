using Newtonsoft.Json;

namespace BooksAPI.Models
{
    public class LoveAnswer
    {
        [JsonProperty("fname")]
        public string Fname { get; set; }
        [JsonProperty("sname")]
        public string Sname { get; set; }
        [JsonProperty("percentage")]
        public string Percentage { get; set; }
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}
