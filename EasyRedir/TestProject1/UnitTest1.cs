using EasyRedir;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static async Task TestMethod1()
        {
            var easyRedirClient = new EasyRedirClient("RBU7M1GVOXZ2CNY0KA95", "bLQtfeljKzsQ/b4uxnu7eoscR3wKIjLXACd/RWN1afui6LPZa1slVv2u");

            await easyRedirClient.GetEasyRedirRules();
        }
    }
}
