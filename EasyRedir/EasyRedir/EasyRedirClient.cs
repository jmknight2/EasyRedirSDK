using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EasyRedir.Model;

namespace EasyRedir
{
    public class EasyRedirClient
    {
        private const string BASE_URL = "https://api.easyredir.com/v1";
        private static readonly HttpClient client = new HttpClient();

        public EasyRedirClient() {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            client.BaseAddress = new Uri(BASE_URL);
        }

        public EasyRedirClient(string ApiKey, string ApiSecret) {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            var byteArray = Encoding.ASCII.GetBytes(String.Format("{0}:{1}", ApiKey, ApiSecret));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.BaseAddress = new Uri(BASE_URL);
        }
        
        public async Task<EasyRedirRuleResponse> GetEasyRedirRules() {
            var streamTask = client.GetStreamAsync("/v1/rules");
            

            return await JsonSerializer.DeserializeAsync<EasyRedirRuleResponse>(await streamTask);
        }

        public async Task<EasyRedirHostResponse> GetEasyRedirHost() {
            var streamTask = client.GetStreamAsync("/v1/hosts");

            return await JsonSerializer.DeserializeAsync<EasyRedirHostResponse>(await streamTask);
        }

        public async Task<EasyRedirHostResponse> GetEasyRedirHost(Guid Id)
        {
            var streamTask = client.GetStreamAsync("/v1/hosts/" + Id);

            return await JsonSerializer.DeserializeAsync<EasyRedirHostResponse>(await streamTask);
        }

        public async Task<EasyRedirHostResponse> CreateEasyRedirRule(Uri TargetUrl, string[] SourceUrls, string ResponseType=EasyRedirResponseType.MovedPermanently, bool ForwardParams=false, bool ForwardPath = false)
        {
            var newRule = new EasyRedirRuleAttributes(ForwardParams, ForwardPath, ResponseType, SourceUrls, TargetUrl);
            var req = new HttpRequestMessage(HttpMethod.Post, "/v1/rules");
            req.Content = new StringContent(Encoding.Default.GetString(JsonSerializer.SerializeToUtf8Bytes(newRule)), Encoding.UTF8, "application/json");

            Console.WriteLine(Encoding.Default.GetString(JsonSerializer.SerializeToUtf8Bytes(newRule)));

            var responseMessage = await client.SendAsync(req);

            Console.WriteLine(responseMessage.ToString());

            if (responseMessage == null) {
                
            }

            var responseString = JsonSerializer.SerializeAsync(await responseMessage.Content.ReadAsStreamAsync(), Encoding.UTF8);

            Console.WriteLine(responseString);

            return await JsonSerializer.DeserializeAsync<EasyRedirHostResponse>(await responseMessage.Content.ReadAsStreamAsync());
        }

        public async Task<EasyRedirHostResponse> CreateEasyRedirRule(Uri TargetUrl, string SourceUrl, string ResponseType = EasyRedirResponseType.MovedPermanently, bool ForwardParams = false, bool ForwardPath = false)
        {
            return await CreateEasyRedirRule(TargetUrl, new string[] { SourceUrl }, ResponseType, ForwardParams, ForwardPath);
        }

        public async Task<EasyRedirHostResponse> UpdateEasyRedirRule(Guid Id, Uri TargetUrl, string[] SourceUrls, string ResponseType = EasyRedirResponseType.MovedPermanently, bool ForwardParams = false, bool ForwardPath = false)
        {
            var req = new HttpRequestMessage(HttpMethod.Patch, ("/v1/rules/" + Id));

            var newRule = new EasyRedirRuleAttributes(ForwardParams, ForwardPath, ResponseType, SourceUrls, TargetUrl);
            req.Content = new StringContent(Encoding.Default.GetString(JsonSerializer.SerializeToUtf8Bytes(newRule)), Encoding.UTF8, "application/json");

            var responseMessage = await client.SendAsync(req);

            return await JsonSerializer.DeserializeAsync<EasyRedirHostResponse>(await responseMessage.Content.ReadAsStreamAsync());
        }

        public async Task<EasyRedirHostResponse> UpdateEasyRedirRule(Guid Id, Uri TargetUrl, string SourceUrl, string ResponseType = EasyRedirResponseType.MovedPermanently, bool ForwardParams = false, bool ForwardPath = false) 
        {
            return await UpdateEasyRedirRule(Id, TargetUrl, new string[] { SourceUrl }, ResponseType, ForwardParams, ForwardPath);
        }

        public void RemoveEasyRedirRule(Guid Id)
        {
            var req = new HttpRequestMessage(HttpMethod.Delete, ("/v1/rules/" + Id));

            var responseMessage = client.SendAsync(req);
        }
    }
}
