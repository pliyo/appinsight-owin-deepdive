using NUnit.Framework;
using AppInsightOwinDeepDive.Models;
using AppInsightOwinDeepDive.Services;

namespace AppInsightOwinDeepDive.IntegrationTests
{
    [TestFixture]
    public class SlackClientShould
    {
        [Test]
        public void PostMessage()
        {
            string urlWithAccessToken = ""; // Use your slack webhook here : D

            SlackClient client = new SlackClient();

            SlackPayload payload = new SlackPayload()
            {
                Channel = "avengers",
                Text = "Here we go!",
            };

            client.SendMessage(payload, urlWithAccessToken);
        }
    }
}
