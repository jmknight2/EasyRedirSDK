using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirHostLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }

        public EasyRedirHostLinks() {}

        public EasyRedirHostLinks(string self)
        {
            Self = self;
        }
    }
}
