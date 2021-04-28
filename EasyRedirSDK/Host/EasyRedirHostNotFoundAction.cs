using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirHostNotFoundAction
    {
        [JsonPropertyName("forward_params")]
        public bool ForwardParams { get; set; }

        [JsonPropertyName("forward_path")]
        public bool ForwardPath { get; set; }

        [JsonPropertyName("custom_404_body_present")]
        public bool Custom404BodyPresent { get; set; }

        [JsonPropertyName("custom_404_body")]
        public string Custom404Body { get; set; }

        [JsonPropertyName("response_code")]
        public int ResponseCode { get; set; }

        [JsonPropertyName("response_url")]
        public Uri ResponseUrl { get; set; }

        public EasyRedirHostNotFoundAction() {}

        public EasyRedirHostNotFoundAction(bool forwardParams, bool forwardPath, bool custom404BodyPresent, int responseCode, Uri responseUrl)
        {
            ForwardParams = forwardParams;
            ForwardPath = forwardPath;
            Custom404BodyPresent = custom404BodyPresent;
            ResponseCode = responseCode;
            ResponseUrl = responseUrl;
        }

        public EasyRedirHostNotFoundAction(bool forwardParams, bool forwardPath, string custom404Body, int responseCode, Uri responseUrl)
        {
            ForwardParams = forwardParams;
            ForwardPath = forwardPath;
            Custom404Body = custom404Body;
            ResponseCode = responseCode;
            ResponseUrl = responseUrl;
        }
    }
}
