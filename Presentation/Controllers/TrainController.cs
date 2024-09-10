using Entities.Models;
using Entities.Models.Request;
using Entities.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public TrainController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        // POST: api/train/reserve
        [HttpPost("reserve")]
        public async Task<IActionResult> MakeReservation([FromBody] ReservationRequest request)
        {
            // TrainId üzerinden treni çekiyoruz
            var train = await serviceManager.TrainManager.GetTrainByIdAsync(request.TrainId);
            if (train == null)
                return NotFound("Train not found.");

            int totalPassengers = request.NumberOfPassengers;

            // Kişilerin farklı vagonlara yerleştirilebileceği kontrolü
            if (request.CanSplitPassengers)
            {
                var allocation = AllocatePassengersAcrossWagons(train.Wagons, totalPassengers);
                if (allocation.CanBeReserved)
                    return Ok(allocation);
                else
                    return BadRequest("Reservation not possible.");
            }
            else
            {
                // Kişilerin aynı vagonda olması gerektiğinde
                var allocation = AllocatePassengersInSingleWagon(train.Wagons, totalPassengers);
                if (allocation.CanBeReserved)
                    return Ok(allocation);
                else
                    return BadRequest("Reservation not possible in a single wagon.");
            }
        }

        // Kişilerin aynı vagona yerleştirilmesi
        private ReservationResponse AllocatePassengersInSingleWagon(IEnumerable<Wagon> wagons, int totalPassengers)
        {
            foreach (var wagon in wagons)
            {
                int availableSeats = (int)(wagon.Capacity * 0.7) - wagon.OccupiedSeats;
                if (availableSeats >= totalPassengers)
                {
                    return new ReservationResponse
                    {
                        CanBeReserved = true,
                        SeatingDetails = new List<SeatingDetail>
                        {
                            new SeatingDetail
                            {
                                WagonName = wagon.Name,
                                PassengerCount = totalPassengers
                            }
                        }
                    };
                }
            }

            return new ReservationResponse { CanBeReserved = false };
        }

        // Kişilerin farklı vagonlara yerleştirilebilmesi
        private ReservationResponse AllocatePassengersAcrossWagons(IEnumerable<Wagon> wagons, int totalPassengers)
        {
            var seatingDetails = new List<SeatingDetail>();
            int remainingPassengers = totalPassengers;

            foreach (var wagon in wagons)
            {
                int availableSeats = (int)(wagon.Capacity * 0.7) - wagon.OccupiedSeats;

                if (availableSeats > 0)
                {
                    int allocatedPassengers = (remainingPassengers > availableSeats) ? availableSeats : remainingPassengers;
                    seatingDetails.Add(new SeatingDetail
                    {
                        WagonName = wagon.Name,
                        PassengerCount = allocatedPassengers
                    });
                    remainingPassengers -= allocatedPassengers;
                }

                if (remainingPassengers == 0)
                    break;
            }

            return new ReservationResponse
            {
                CanBeReserved = remainingPassengers == 0,
                SeatingDetails = seatingDetails
            };
        }
    }
}
