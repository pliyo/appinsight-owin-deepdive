using System.Collections.Concurrent;
using WebApplication1.Reservation;

namespace WebApplication1.Services
{
    public static class ReservationService
    {
        private static ConcurrentDictionary<string, ReservationRequest> reservations = new ConcurrentDictionary<string, ReservationRequest>();
        private static ConcurrentBag<ReservationRequest> importantReservations = new ConcurrentBag<ReservationRequest>();
        public static void Create(ReservationRequest reservation)
        {
            reservations.TryAdd(reservation.Id.ToString(), reservation);
        }

        public static ConcurrentBag<ReservationRequest> PriorityReservations()
        {
            foreach(var value in reservations)
            {
                var request = value.Value;
                if (request.Prepaid)
                {
                    importantReservations.Add(request);
                }
            }

            return importantReservations;
        }
    }
}