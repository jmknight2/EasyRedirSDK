using EasyRedir;
using EasyRedir.Model;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EasyRedirConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var easyRedirClient = new EasyRedirClient("RBU7M1GVOXZ2CNY0KA95", "bLQtfeljKzsQ/b4uxnu7eoscR3wKIjLXACd/RWN1afui6LPZa1slVv2u");

            //var response = await easyRedirClient.CreateEasyRedirRule( new EasyRedirRuleAttributes
            //{
            //    TargetUrl = new Uri("https://google.com"),
            //    SourceUrls = new string[] { "dumbtest.com" }    
            //});

            //var response = await easyRedirClient.UpdateEasyRedirRule(new Guid("c9c3e58e-394f-4281-b382-2d1dc8adb3b7"), new EasyRedirRuleAttributes {
            //    TargetUrl = new Uri("https://google.com")
            //});

            //easyRedirClient.RemoveEasyRedirRule(new Guid("c9c3e58e-394f-4281-b382-2d1dc8adb3b7"));

            var response = await easyRedirClient.GetEasyRedirRules();
            //var response = await easyRedirClient.GetEasyRedirHost(new Guid("f8bda3eb-58fa-45a5-abda-1dd66231edb0"));

            //foreach (var host in response.Data) {
            //    Console.WriteLine(host.Attributes.Name);
            //}

            Console.WriteLine(Encoding.Default.GetString(JsonSerializer.SerializeToUtf8Bytes(response)));
        }
    }
}
