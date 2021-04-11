using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedir.Model
{
    public class EasyRedirError
    {
        [JsonPropertyName("resource")]
        public string Resource { get; set; }

        [JsonPropertyName("param")]
        public string Param { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        public EasyRedirError() {}

        public EasyRedirError(string Resource, string Param, string Code, string Message)
        {
            this.Resource = Resource;
            this.Param = Param;
            this.Code = Code;
            this.Message = Message;
        }
    }
}
