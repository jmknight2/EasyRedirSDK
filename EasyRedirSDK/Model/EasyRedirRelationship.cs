using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirRelationship
    {
        [JsonPropertyName("source_hosts")]
        public EasyRedirRelationshipSourceHostResponse SourceHosts { get; set; }

        public EasyRedirRelationship() {}

        public EasyRedirRelationship(EasyRedirRelationshipSourceHostResponse sourceHosts)
        {
            SourceHosts = sourceHosts;
        }
    }
}
