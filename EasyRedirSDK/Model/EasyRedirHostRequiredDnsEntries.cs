using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirHostRequiredDnsEntries
    {
        [JsonPropertyName("recommended")]
        public EasyRedirDnsRecord Recommended { get; set; }

        [JsonPropertyName("alternatives")]
        public List<EasyRedirDnsRecord> Alternatives { get; set; }

        public EasyRedirHostRequiredDnsEntries()
        {
        }

        public EasyRedirHostRequiredDnsEntries(EasyRedirDnsRecord recommended, List<EasyRedirDnsRecord> alternatives)
        {
            Recommended = recommended;
            Alternatives = alternatives;
        }
    }
}
