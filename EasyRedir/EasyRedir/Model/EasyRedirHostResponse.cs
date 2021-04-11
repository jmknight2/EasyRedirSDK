using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirHostResponse
    {
        [JsonPropertyName("data")]
        [JsonConverter(typeof(SingleOrArrayConverter<EasyRedirHost>))]
        public List<EasyRedirHost> Data { get; set; }

        [JsonPropertyName("meta")]
        public EasyRedirResponseMeta Meta { get; set; }

        [JsonPropertyName("links")]
        public EasyRedirResponseLinks Links { get; set; }

        public EasyRedirHostResponse(List<EasyRedirHost> data, EasyRedirResponseMeta meta, EasyRedirResponseLinks links) {
            this.Data = data;
            this.Meta = meta;
            this.Links = links;
        }


    }
}
