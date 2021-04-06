using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyRedir.Tests
{
    class TestGetRules
    {
        static async Task Main(string[] args) {
            var easyRedirClient = new EasyRedirClient("RBU7M1GVOXZ2CNY0KA95", "bLQtfeljKzsQ/b4uxnu7eoscR3wKIjLXACd/RWN1afui6LPZa1slVv2u");

            await easyRedirClient.GetEasyRedirRules();
        }
    }
}
