using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    public class EasyRedirHostAttributes
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("dns_status")]
        public string DnsStatus { get; set; }

        [JsonPropertyName("dns_tested_at")]
        public string DnsTestedAt { get; set; }

        [JsonPropertyName("certificate_status")]
        public string CertificateStatus { get; set; }

        [JsonPropertyName("acme_enabled")]
        public bool AcmeEnabled { get; set; }

        [JsonPropertyName("required_dns_entries")]
        public EasyRedirHostRequiredDnsEntries RequiredDnsEntries { get; set; }

        [JsonPropertyName("detected_dns_entries")]
        public List<EasyRedirDnsRecord> DetectedDnsEntries { get; set; }

        [JsonPropertyName("match_options")]
        public EasyRedirHostMatchOptions MatchOptions { get; set; }

        [JsonPropertyName("not_found_action")]
        public EasyRedirHostNotFoundAction NotFoundAction { get; set; }

        [JsonPropertyName("security")]
        public EasyRedirHostSecurity Security { get; set; }

        public EasyRedirHostAttributes() {}

        public EasyRedirHostAttributes(string name, string dnsStatus, string dnsTestedAt, string certificateStatus, bool acmeEnabled, EasyRedirHostRequiredDnsEntries requiredDnsEntries, List<EasyRedirDnsRecord> detectedDnsEntries, EasyRedirHostMatchOptions matchOptions, EasyRedirHostNotFoundAction notFoundAction, EasyRedirHostSecurity security) {
            Name = name;
            DnsStatus = dnsStatus;
            DnsTestedAt = dnsTestedAt;
            CertificateStatus = certificateStatus;
            AcmeEnabled = acmeEnabled;
            RequiredDnsEntries = requiredDnsEntries;
            DetectedDnsEntries = detectedDnsEntries;
            MatchOptions = matchOptions;
            NotFoundAction = notFoundAction;
            Security = security;
        }
    }
}
