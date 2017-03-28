using System.Collections.Concurrent;
using WebApplication1.Reservation;

namespace WebApplication1.Services
{
    public class ReservationService
    {
        private ConcurrentDictionary<string, ReservationRequest> reservations = new ConcurrentDictionary<string, ReservationRequest>();
        public virtual void Create(ReservationRequest reservation)
        {
            reservations.TryAdd(reservation.Id.ToString(), reservation);
        }

        public virtual void Stuff()
        {
            
        }
    }
}