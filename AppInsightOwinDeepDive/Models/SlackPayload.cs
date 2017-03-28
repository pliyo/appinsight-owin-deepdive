﻿using Newtonsoft.Json;

namespace AppInsightOwinDeepDive.Models
{
    public class SlackPayload
    {
        public SlackPayload()
        {
            UserName = "AppInsights.Reporting";
        }

        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("username")]
        public string UserName { get; private set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}