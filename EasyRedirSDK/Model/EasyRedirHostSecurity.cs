using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirHostSecurity
    {
        [JsonPropertyName("https_upgrade")]
        public bool HttpsUpgrade { get; set; }

        [JsonPropertyName("prevent_foreign_embedding")]
        public bool PreventForeignEmbedding { get; set; }

        [JsonPropertyName("hsts_include_sub_domains")]
        public bool HstsIncludeSubdomains { get; set; }

        [JsonPropertyName("hsts_max_age")]
        public int? HstsMaxAge { get; set; }

        [JsonPropertyName("hsts_preload")]
        public bool HstsPreload { get; set; }

        public EasyRedirHostSecurity() {}

        public EasyRedirHostSecurity(bool httpsUpgrade, bool preventForeignEmbedding, bool hstsIncludeSubdomains, int? hstsMaxAge, bool hstsPreload)
        {
            HttpsUpgrade = httpsUpgrade;
            PreventForeignEmbedding = preventForeignEmbedding;
            HstsIncludeSubdomains = hstsIncludeSubdomains;
            HstsMaxAge = hstsMaxAge;
            HstsPreload = hstsPreload;
        }
    }
}
