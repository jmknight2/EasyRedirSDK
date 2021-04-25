using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EasyRedirSDK.Model;

namespace EasyRedirSDK
{
    public class EasyRedirClient
    {
        // The base URL for the API.
        private const string BASE_URL = "https://api.easyredir.com";
        private readonly HttpClient client;

        public EasyRedirClient(string ApiKey, string ApiSecret) {
            // Actually initialize the client.
            client = new HttpClient();

            // We only want JSON, because JSON is the best.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            // Convert the Key/Secret pair into a Base64 Basic Auth header value, and store that value in the Authenication header of client.
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", ApiKey, ApiSecret))));
            // Sets the base URI for client so we don't have to keep referencing it. Note that subsequent endpoints must include a leading slash.
            client.BaseAddress = new Uri(BASE_URL);
        }

        // Gets the specified number of rules. Limit defaults to 25.
        public async Task<EasyRedirRuleResponse> GetEasyRedirRules(int limit=25)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, "/v1/rules?limit=" + limit);

            var responseMessage = client.SendAsync(req).Result;

            if (!responseMessage.IsSuccessStatusCode)
            {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }

            return await JsonSerializer.DeserializeAsync<EasyRedirRuleResponse>(await responseMessage.Content.ReadAsStreamAsync());
        }

        // Gets the specified number of rules, where the source and target Urls match the values specified. Limit defaults to 25.
        public async Task<EasyRedirRuleResponse> GetEasyRedirRules(string sourceUrl, string targetUrl, int limit = 25)
        {
            var requestUri = String.Format("/v1/rules?limit={0}", limit);
            
            if (!String.IsNullOrWhiteSpace(sourceUrl)) 
            {
                requestUri += String.Format("&sq={0}", sourceUrl);
            }

            if (!String.IsNullOrWhiteSpace(targetUrl))
            {
                requestUri += String.Format("&tq={0}", targetUrl);
            }

            var req = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var responseMessage = client.SendAsync(req).Result;

            if (!responseMessage.IsSuccessStatusCode)
            {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }

            return await JsonSerializer.DeserializeAsync<EasyRedirRuleResponse>(await responseMessage.Content.ReadAsStreamAsync());
        }

        // Gets a list of rules based on the pageToken passed in. This is really meant to be used as a subsequent call after getting a page token. 
        public async Task<EasyRedirRuleResponse> GetEasyRedirRules(string pageToken)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, pageToken);

            var responseMessage = client.SendAsync(req).Result;

            if (!responseMessage.IsSuccessStatusCode)
            {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }

            return await JsonSerializer.DeserializeAsync<EasyRedirRuleResponse>(await responseMessage.Content.ReadAsStreamAsync());
        }

        // Gets the specified number of hosts. Limit defaults to 25.
        public async Task<EasyRedirHostResponse> GetEasyRedirHost(int limit=25)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, "/v1/hosts?limit=" + limit.ToString());

            var responseMessage = client.SendAsync(req).Result;

            if (!responseMessage.IsSuccessStatusCode)
            {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }

            return await JsonSerializer.DeserializeAsync<EasyRedirHostResponse>(await responseMessage.Content.ReadAsStreamAsync());
        }

        // Gets a list of hosts based on the pageToken passed in. This is really meant to be used as a subsequent call after getting a page token.
        public async Task<EasyRedirHostResponse> GetEasyRedirHost(string pageToken)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, pageToken);

            var responseMessage = client.SendAsync(req).Result;

            if (!responseMessage.IsSuccessStatusCode)
            {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }

            return await JsonSerializer.DeserializeAsync<EasyRedirHostResponse>(await responseMessage.Content.ReadAsStreamAsync());
        }

        // Gets a single host with the specified ID.
        public async Task<EasyRedirHost> GetEasyRedirHost(Guid Id)
        {
            var req = new HttpRequestMessage(HttpMethod.Get, ("/v1/hosts/" + Id));

            var responseMessage = client.SendAsync(req).Result;

            if (!responseMessage.IsSuccessStatusCode)
            {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }

            var hostResponse = await JsonSerializer.DeserializeAsync<EasyRedirHostResponse>(await responseMessage.Content.ReadAsStreamAsync());

            return hostResponse.Data[0];
        }

        public async Task<EasyRedirHost> UpdateEasyRedirHost(Guid Id, EasyRedirHostAttributes HostAttributes)
        {
            JsonSerializerOptions serializerOptions = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var req = new HttpRequestMessage(HttpMethod.Patch, ("/v1/hosts/" + Id));
            req.Content = new StringContent(Encoding.Default.GetString(JsonSerializer.SerializeToUtf8Bytes(HostAttributes, serializerOptions)), Encoding.UTF8, "application/json");

            var responseMessage = await client.SendAsync(req);

            if (!responseMessage.IsSuccessStatusCode)
            {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }

            return await JsonSerializer.DeserializeAsync<EasyRedirHost>(await responseMessage.Content.ReadAsStreamAsync(), serializerOptions);
        }

        // Creates a new EasyRedir rule. This overload is for multiple SourceUrls.
        public async Task<EasyRedirRule> CreateEasyRedirRule(Uri TargetUrl, string[] SourceUrls, string ResponseType=EasyRedirResponseType.MovedPermanently, bool ForwardParams=false, bool ForwardPath = false, bool includeRelationships = true)
        {
            var requestUri = "/v1/rules";

            if (includeRelationships)
            {
                requestUri += String.Format("?include[]=relationship");
            }

            var newRule = new EasyRedirRuleAttributes(ForwardParams, ForwardPath, ResponseType, SourceUrls, TargetUrl);
            var reqContent = new StringContent(Encoding.Default.GetString(JsonSerializer.SerializeToUtf8Bytes(newRule)), Encoding.UTF8, "application/json");

            Console.WriteLine(Encoding.Default.GetString(JsonSerializer.SerializeToUtf8Bytes(newRule)));

            var responseMessage = await client.PostAsync(requestUri, reqContent);

            if (!responseMessage.IsSuccessStatusCode) {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }

            var ruleResponse = await JsonSerializer.DeserializeAsync<EasyRedirRuleResponse>(await responseMessage.Content.ReadAsStreamAsync());

            return ruleResponse.Data[0];
        }

        // Creates a new EasyRedir rule. This overload is for only a single SourceUrl, and essentially just wraps that URL in a single item array and passes it to the above overload.
        public async Task<EasyRedirRule> CreateEasyRedirRule(Uri TargetUrl, string SourceUrl, string ResponseType = EasyRedirResponseType.MovedPermanently, bool ForwardParams = false, bool ForwardPath = false, bool includeRelationships = true)
        {
            return await CreateEasyRedirRule(TargetUrl, new string[] { SourceUrl }, ResponseType, ForwardParams, ForwardPath, includeRelationships);
        }

        // Creates a new EasyRedir rule. This overload accepts an object which can be easier to build, but all properties are required.
        public async Task<EasyRedirRule> CreateEasyRedirRule(EasyRedirRuleAttributes RuleAttributes, bool includeRelationships = true)
        {
            var requestUri = "/v1/rules";

            if (includeRelationships)
            {
                requestUri += String.Format("?include[]=relationship");
            }

            var reqContent = new StringContent(Encoding.Default.GetString(JsonSerializer.SerializeToUtf8Bytes(RuleAttributes)), Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync(requestUri, reqContent);

            if (!responseMessage.IsSuccessStatusCode)
            {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }

            var ruleResponse = await JsonSerializer.DeserializeAsync<EasyRedirRuleResponse>(await responseMessage.Content.ReadAsStreamAsync());

            return ruleResponse.Data[0];
        }

        // Updates the rule with the ID specified, making the passed in the RuleAttributes object.
        public async Task<EasyRedirRule> UpdateEasyRedirRule(Guid Id, EasyRedirRuleAttributes RuleAttributes, bool includeRelationships=true)
        {
            var requestUri = "/v1/rules/" + Id;

            if (includeRelationships)
            {
                requestUri += String.Format("?include[]=relationship");
            }

            var req = new HttpRequestMessage(HttpMethod.Patch, requestUri);

            JsonSerializerOptions serializerOptions = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            req.Content = new StringContent(Encoding.Default.GetString(JsonSerializer.SerializeToUtf8Bytes(RuleAttributes, serializerOptions)), Encoding.UTF8, "application/json");

            var responseMessage = await client.SendAsync(req);

            if (!responseMessage.IsSuccessStatusCode)
            {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }

            var ruleResponse = await JsonSerializer.DeserializeAsync<EasyRedirRuleResponse>(await responseMessage.Content.ReadAsStreamAsync(), serializerOptions);

            return ruleResponse.Data[0];
        }

        // Removes the rule with the specified ID. 
        public async void RemoveEasyRedirRule(Guid Id)
        {
            var req = new HttpRequestMessage(HttpMethod.Delete, ("/v1/rules/" + Id));

            var responseMessage = client.SendAsync(req).Result;

            if (!responseMessage.IsSuccessStatusCode)
            {
                var exc = await JsonSerializer.DeserializeAsync<EasyRedirException>(await responseMessage.Content.ReadAsStreamAsync());

                throw exc;
            }
        }
    }
}
