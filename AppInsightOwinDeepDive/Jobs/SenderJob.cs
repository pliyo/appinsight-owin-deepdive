using System.Linq;
using Quartz;
using AppInsightOwinDeepDive.Helpers;
using AppInsightOwinDeepDive.Models;
using AppInsightOwinDeepDive.Services;

namespace AppInsightOwinDeepDive.Jobs
{
    public class SenderJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            AppInsightHelper.LogMetric(SendNotificationsForPriorityReservations, "SenderJob Running");
        }

        private void SendNotificationsForPriorityReservations()
        {
            var priorityReservations = ReservationService.PriorityReservations();
            ReservationService.CleanUpPriorityReservations();

            var slackClient = new SlackClient();

            var payload = CreatePayloadFromReservationInformation(CommunicationService.GetSlackChannel(),
                                                                  priorityReservations.Count);

            slackClient.SendMessage(payload, CommunicationService.GetSlackWebHook());
        }

        private SlackPayload CreatePayloadFromReservationInformation(string slackChannel, int totalReservations)
        {
            var payload = new SlackPayload()
            {
                Channel = slackChannel,
                Text = $"{totalReservations} prepaid reservations done in the last 5 minutes"
            };
            return payload;
        }
    }
}