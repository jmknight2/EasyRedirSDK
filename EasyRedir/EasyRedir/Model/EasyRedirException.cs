using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyRedirSDK.Model
{
    [Serializable]
    public class EasyRedirException : Exception
    {
        [JsonPropertyName("type")]
        public string ErrorType { get; set; }

        [JsonPropertyName("message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("errors")]
        [JsonConverter(typeof(SingleOrArrayConverter<EasyRedirError>))]
        public List<EasyRedirError> Errors { get; set; }

        public EasyRedirException() : base() { }
        public EasyRedirException(string message) : base(message) { }
        public EasyRedirException(string message, Exception inner) : base(message, inner) { }

        public EasyRedirException(string errorType, string errorMessage, List<EasyRedirError> errors) : base(errorMessage)
        {
            Console.WriteLine("I'm alive!!");
            ErrorMessage = errorMessage;
            ErrorType = errorType;
            Errors = errors;
        }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected EasyRedirException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public override string ToString()
        {
            return String.Format("Error Type: {0}; Error Message: {1}.", ErrorType, ErrorMessage);
        }
    }
}
