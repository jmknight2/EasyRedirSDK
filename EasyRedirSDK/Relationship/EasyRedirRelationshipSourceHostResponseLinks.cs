using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirRelationshipSourceHostResponseLinks
    {
        [JsonPropertyName("related")]
        public string Related { get; set; }

        public EasyRedirRelationshipSourceHostResponseLinks() {}

        public EasyRedirRelationshipSourceHostResponseLinks(string related)
        {
            Related = related;
        }
    }
}
