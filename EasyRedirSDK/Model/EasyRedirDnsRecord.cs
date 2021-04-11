using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirDnsRecord
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("values")]
        public string[] Values { get; set; }

        public EasyRedirDnsRecord()
        {
        }

        public EasyRedirDnsRecord(string type, string[] values)
        {
            Type = type;
            Values = values;
        }
    }
}
