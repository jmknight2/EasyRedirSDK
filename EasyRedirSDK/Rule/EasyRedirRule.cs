using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirRule
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attributes")]
        public EasyRedirRuleAttributes Attributes { get; set; }

        [JsonPropertyName("relationships")]
        public EasyRedirRelationship Relationships { get; set; }

        public EasyRedirRule() {}

        public EasyRedirRule(Guid id, string type, EasyRedirRuleAttributes attributes, EasyRedirRelationship relationships)
        {
            Id = id;
            Type = type;
            Attributes = attributes;
            Relationships = relationships;
        }
    }
}
