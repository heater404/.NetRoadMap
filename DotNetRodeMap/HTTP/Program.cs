using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HTTP
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            string uri = @"http://www.bing.com";

            var respose = client.GetAsync(uri);

            HttpStatusCode statusCode = respose.Result.StatusCode;
            Console.WriteLine(statusCode.ToString());

            HttpResponseHeaders header = respose.Result.Headers;

            HttpContent content = respose.Result.Content;
            var ct = content.ReadAsStringAsync();
            Console.WriteLine(ct.Result);
        }
    }
}
