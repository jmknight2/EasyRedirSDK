using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirResponseMeta
    {
        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        public EasyRedirResponseMeta() {}

        public EasyRedirResponseMeta(bool hasMore)
        {
            HasMore = hasMore;
        }
    }
}
