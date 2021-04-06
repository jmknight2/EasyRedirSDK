using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedir.Model
{
    public class EasyRedirHost
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public EasyRedirHostAttributes Attributes { get; set; }

        [JsonPropertyName("links")]
        public EasyRedirHostLinks Links { get; set; }

        public EasyRedirHost() {}

        public EasyRedirHost(Guid id, string type, EasyRedirHostAttributes attributes, EasyRedirHostLinks links) {
            this.Id = id;
            this.Type = type;
            this.Attributes = attributes;
            this.Links = links;
        }
    }
}
