using EasyRedir;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace EasyRedirConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var easyRedirClient = new EasyRedirClient("RBU7M1GVOXZ2CNY0KA95", "bLQtfeljKzsQ/b4uxnu7eoscR3wKIjLXACd/RWN1afui6LPZa1slVv2u");

            var response = easyRedirClient.CreateEasyRedirRule(
                new Uri("https://DumbTest.com"),
                "DumbTest2.com"
            );

            //easyRedirClient.RemoveEasyRedirRule(new Guid("fd7bb48f-aee8-4c16-b0dc-59318832d658"));

            //var response = await easyRedirClient.GetEasyRedirHost();
            //var response = await easyRedirClient.GetEasyRedirHost(new Guid("f8bda3eb-58fa-45a5-abda-1dd66231edb0"));

            //foreach (var host in response.Data) {
            //    Console.WriteLine(host.Attributes.Name);
            //}
        }
    }
}
