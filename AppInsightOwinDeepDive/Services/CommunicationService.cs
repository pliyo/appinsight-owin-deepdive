using System;
using System.Linq;

namespace AppInsightOwinDeepDive.Services
{
    public static class CommunicationService
    {
        private static string _slackWebHook;
        private static string _slackChannel;

        public static void SetWebHook(string webHook)
        {
            _slackWebHook = webHook;
        }

        public static void SetSlackChannel(string slackChannel)
        {
            _slackChannel = slackChannel;
        }

        public static string GetSlackWebHook()
        {
            return _slackWebHook;
        }

        public static string GetSlackChannel()
        {
            return _slackChannel;
        }
    }
}