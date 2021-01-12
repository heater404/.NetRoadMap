using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            Task<HttpResponseMessage> respose = client.GetAsync(@"https://www.bilibili.com/?spm_id_from=333.5.b_7072696d61727950616765546162.1");

            respose.Wait();

            if (respose.IsCompletedSuccessfully)
            {
                Console.WriteLine(respose.Result.Content.Headers);
            }

        }
    }
}
