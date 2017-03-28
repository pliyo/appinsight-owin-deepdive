using Quartz;
using WebApplication1.Models;
using WebApplication1.Reservation;
using WebApplication1.Services;

namespace WebApplication1.Jobs
{
    public class SenderJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var priorityReservations = ReservationService.PriorityReservations();
            var slackClient = new SlackClient();

            foreach (var reservation in priorityReservations)
            {
                if (string.IsNullOrEmpty(reservation.SlackWebHook)) continue;

                var payload = CreatePayloadFromRequest(reservation);
                slackClient.SendMessage(payload, reservation.SlackWebHook);
            }
        }

        private SlackPayload CreatePayloadFromRequest(ReservationRequest reservation)
        {
            var payload = new SlackPayload()
            {
                Channel = reservation.SlackChannel,
                Text = $"{reservation.Owner} has made a reservation with {reservation.TicketId}"
            };
            return payload;
        }
    }
}