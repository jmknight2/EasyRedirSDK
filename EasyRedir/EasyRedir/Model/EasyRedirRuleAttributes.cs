using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedir.Model
{
    public class EasyRedirRuleAttributes
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
        public Uri TargetUrl { get; set; }

        EasyRedirRuleAttributes() { }

        public EasyRedirRuleAttributes(bool forwardParams, bool forwardPath, string responseType, string[] sourceUrls, Uri targetUrl)
        {
            this.ForwardParams = forwardParams;
            this.ForwardPath = forwardPath;
            this.ResponseType = responseType;
            this.SourceUrls = sourceUrls;
            this.TargetUrl = targetUrl;
        }
    }
}
