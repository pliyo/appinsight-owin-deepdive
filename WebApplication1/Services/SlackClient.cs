using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SlackClient
    {
        public void SendMessage(SlackPayload payload, string token)
        {
            var uri = new Uri(token);
            string payloadJson = JsonConvert.SerializeObject(payload);

            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;

                client.UploadValues(uri, "POST", data);
            }
        }
    }
}