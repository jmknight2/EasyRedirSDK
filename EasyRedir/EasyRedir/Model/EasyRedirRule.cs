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

        public EasyRedirRule() {}

        public EasyRedirRule(Guid id, string type, EasyRedirRuleAttributes attributes) {
            this.Id = id;
            this.Type = type;
            this.Attributes = attributes;
        }
    }
}
