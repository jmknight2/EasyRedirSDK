using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirRelationshipSourceHost
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        public EasyRedirRelationshipSourceHost() {}

        public EasyRedirRelationshipSourceHost(Guid id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
