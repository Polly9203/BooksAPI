using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Models
{
    public class TwilioAnswer
    {
        [JsonProperty("account_sid")]
        public string Account_sid { get; set; }

        [JsonProperty("api_version")]
        public string Api_version { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("date_created")]
        public string Date_created { get; set; }

        [JsonProperty("date_sent")]
        public string Date_sent { get; set; }

        [JsonProperty("date_updated")]
        public string Date_updated { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("error_code")]
        public string Error_code { get; set; }

        [JsonProperty("error_message")]
        public string Error_message { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("messaging_service_sid")]
        public string Messaging_service_sid { get; set; }

        [JsonProperty("num_media")]
        public int Num_media { get; set; }

        [JsonProperty("num_segments")]
        public int Num_segments { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("price_unit")]
        public string Price_unit { get; set; }

        [JsonProperty("sid")]
        public string Sid { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("subresource_uris")]
        public string Subresource_uris { get; set; }

    }
}
