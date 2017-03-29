using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AppInsightOwinDeepDive.Helpers;
using AppInsightOwinDeepDive.Reservation;

namespace AppInsightOwinDeepDive.Services
{
    public static class ReservationService
    {
        private static ConcurrentDictionary<string, ReservationRequest> _reservations = new ConcurrentDictionary<string, ReservationRequest>();
        private static ConcurrentBag<ReservationRequest> _importantReservations = new ConcurrentBag<ReservationRequest>();
        public static void Create(ReservationRequest reservation)
        {
            AppInsightHelper.LogMetric(() => CreateReservation(reservation), "ReservationAdded", SaveReservationProperties(reservation));
        }

        private static void CreateReservation(ReservationRequest reservation)
        {
            SetCommunicationNeeds(reservation);
            _reservations.TryAdd(reservation.Id.ToString(), reservation);
        }

        public static ConcurrentBag<ReservationRequest> PriorityReservations()
        {
            foreach (var value in _reservations)
            {
                var reservation = new ReservationRequest();
                _reservations.TryRemove(value.Key, out reservation);

                if (reservation.Prepaid)
                {
                    _importantReservations.Add(reservation);
                }
            }

            return _importantReservations;
        }

        public static void CleanUpPriorityReservations()
        {
            _importantReservations = new ConcurrentBag<ReservationRequest>();
        }

        private static Dictionary<string, string> SaveReservationProperties(ReservationRequest reservation)
        {
            var properties = new Dictionary<string, string>()
            {
                { "Owner", reservation.Owner },
                { "Prepaid", reservation.Prepaid.ToString() },
                { "RequestDate", reservation.RequestDate.ToString() },
                { "TicketId", reservation.TicketId.ToString() }
            };
            return properties;
        }

        private static void SetCommunicationNeeds(ReservationRequest reservation)
        {
            if (!string.IsNullOrEmpty(reservation.SlackChannel))
                CommunicationService.SetSlackChannel(reservation.SlackChannel);
            if (!string.IsNullOrEmpty(reservation.SlackWebHook))
                CommunicationService.SetWebHook(reservation.SlackWebHook);
        }
    }
}