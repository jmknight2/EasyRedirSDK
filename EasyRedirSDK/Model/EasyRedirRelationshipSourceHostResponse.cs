using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirRelationshipSourceHostResponse
    {
        [JsonPropertyName("data")]
        [JsonConverter(typeof(SingleOrArrayConverter<EasyRedirRelationshipSourceHost>))]
        public List<EasyRedirRelationshipSourceHost> Data { get; set; }

        [JsonPropertyName("links")]
        public EasyRedirRelationshipSourceHostResponseLinks Links { get; set; }

        public EasyRedirRelationshipSourceHostResponse() {}

        public EasyRedirRelationshipSourceHostResponse(List<EasyRedirRelationshipSourceHost> data, EasyRedirRelationshipSourceHostResponseLinks links)
        {
            Data = data;
            Links = links;
        }
    }
}
