using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PruebaService_App.Models.HttpClients
{
    public class PeopleResponse
    {
        [JsonPropertyName("results")]
        public IEnumerable<PersonResponse> People { get; set; }
    }
}
