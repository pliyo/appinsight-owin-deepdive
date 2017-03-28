using System;

namespace WebApplication1.Reservation
{
    public class ReservationRequest
    {
        public ReservationRequest()
        {
            Id = Guid.NewGuid();
            RequestDate = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public DateTime RequestDate { get; private set; }

        public string Owner { get; set; }

        public int TicketId { get; set; }

        public bool Prepaid { get; set; }

        public string CorrelationId { get; set; }
        public string SlackWebHook { get; set; }
        public string SlackChannel { get; set; }

    }
}