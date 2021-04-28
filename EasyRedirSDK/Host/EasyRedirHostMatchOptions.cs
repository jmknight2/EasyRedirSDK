using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirHostMatchOptions
    {
        [JsonPropertyName("case_insensitive")]
        public bool CaseInsensitive { get; set; }

        [JsonPropertyName("slash_insensitive")]
        public bool SlashInsensitive { get; set; }

        public EasyRedirHostMatchOptions() {}

        public EasyRedirHostMatchOptions(bool caseInsensitive, bool slashInsensitive)
        {
            CaseInsensitive = caseInsensitive;
            SlashInsensitive = slashInsensitive;
        }
    }
}
