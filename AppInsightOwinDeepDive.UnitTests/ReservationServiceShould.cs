using NUnit.Framework;
using Shouldly;
using WebApplication1.Reservation;
using WebApplication1.Services;

namespace AppInsightOwinDeepDive.UnitTests
{
    [TestFixture]
    public class ReservationServiceShould
    {
        [Test]
        public void Retrieve_PriorityReservations()
        {
            ReservationService.Create(new ReservationRequest() { Owner = "Juanjo", Prepaid = true});
            ReservationService.Create(new ReservationRequest() { Owner = "Juanjo" });

            var priorityReservations = ReservationService.PriorityReservations();

            priorityReservations.Count.ShouldBe(1);
        }
    }
}
