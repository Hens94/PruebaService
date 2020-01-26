using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PruebaService_App.Models.HttpClients
{
    public class PersonResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }
    }
}
