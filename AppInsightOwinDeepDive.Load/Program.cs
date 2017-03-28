using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AppInsightOwinDeepDive.Load
{
    public class Program
    {
        private const string yourUrlGoesHere = "x";
        static void Main(string[] args)
        {
            Parallel.For(0, 1000, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount },
            i  =>
            {
                var response = SendRequest();
                Console.WriteLine(response.Result.StatusCode);
            });
        }

        private static Task<HttpResponseMessage> SendRequest()
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                {"SlackWebHook", "https://hooks.slack.com/x"},
                {"SlackChannel", "x"},
                {"Owner", "Delibird"},
                {"TickedId", "12321"},
                {"CorrelationId", "xu123"},
                {"Prepaid", "true"}
            };

            var content = new FormUrlEncodedContent(values);

            var url = $"{yourUrlGoesHere}/reservation/reserve";
            var response = client.PostAsync(url, content);
            return response;
        }
    }
}
