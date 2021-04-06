using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedir.Model
{
    public class EasyRedirRuleResponse
    {
        [JsonPropertyName("data")]
        public List<EasyRedirRule> Data { get; set; }

        [JsonPropertyName("meta")]
        public EasyRedirResponseMeta Meta { get; set; }

        [JsonPropertyName("links")]
        public EasyRedirResponseLinks Links { get; set; }

        public EasyRedirRuleResponse(List<EasyRedirRule> data, EasyRedirResponseMeta meta, EasyRedirResponseLinks links) {
            this.Data = data;
            this.Meta = meta;
            this.Links = links;
        }


    }
}
