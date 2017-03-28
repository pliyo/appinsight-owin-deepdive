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
            AppInsightHelper.LogMetric(() => CreateReservation(reservation), "", SaveReservationProperties(reservation));
        }

        private static void CreateReservation(ReservationRequest reservation)
        {
            _reservations.TryAdd(reservation.Id.ToString(), reservation);
        }

        private static Dictionary<string, string> SaveReservationProperties(ReservationRequest reservation)
        {
            var properties = new Dictionary<string, string>()
            {
                {  "Owner", reservation.Owner }
            };
            return properties;
        }

        public static ConcurrentBag<ReservationRequest> PriorityReservations()
        {
            foreach(var value in _reservations)
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
    }
}