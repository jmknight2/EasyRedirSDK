using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class CreateEasyRedirRuleRequest
    {
        [JsonPropertyName("forward_params")]
        public bool ForwardParams { get; set; }

        [JsonPropertyName("forward_path")]
        public bool ForwardPath { get; set; }

        [JsonPropertyName("response_type")]
        public string ResponseType { get; set; }

        [JsonPropertyName("source_urls")]
        public string[] SourceUrls { get; set; }

        [JsonPropertyName("target_url")]
        public string TargetUrl { get; set; }
    }
}
