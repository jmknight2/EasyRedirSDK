using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedir.Model
{
    public class EasyRedirResponseLinks
    {
        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("prev")]
        public string Prev { get; set; }

        public EasyRedirResponseLinks(string next, string prev)
        {
            this.Next = next;
            this.Prev = prev;
        }
    }
}
