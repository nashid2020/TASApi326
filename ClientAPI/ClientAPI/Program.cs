using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpclient = HttpClientFactory.Create();

            var url = "https://localhost:44367/api/Packages";
            var data = await httpclient.GetStringAsync(url);
            
            Console.WriteLine(data);
        }
    }
}
