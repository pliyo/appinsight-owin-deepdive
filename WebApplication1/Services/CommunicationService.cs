using System;
using System.Linq;

namespace AppInsightOwinDeepDive.Services
{
    public static class CommunicationService
    {
        public static string SlackWebHook()
        {
            if(ReservationService.PriorityReservations().Any())
                return ReservationService.PriorityReservations().First().SlackWebHook;
            return string.Empty;
        }

        public static string SlackChannel()
        {
            if (ReservationService.PriorityReservations().Any())
                return ReservationService.PriorityReservations().First().SlackChannel;
            return string.Empty;
        }
    }
}