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
        private readonly IServiceManager _serviceManager;

        public TrainController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // POST: api/train/reserve
        [HttpPost("reserve")]
        public async Task<IActionResult> MakeReservation([FromBody] ReservationRequest request)
        {
            if (request == null || request.Train == null || request.Train.Wagons == null || !request.Train.Wagons.Any())
                return BadRequest("Invalid reservation request data.");

            // Tren ID ile treni veritabanından alıyoruz
            var train = await _serviceManager.TrainManager.GetTrainByIdAsync(request.Train.Id);
            if (train == null)
                return NotFound("Train not found.");

            // Rezervasyon yapılacak kişi sayısını alıyoruz
            int totalPassengers = request.NumberOfPassengers;

            // Kişilerin farklı vagonlara yerleştirilebileceği kontrolü
            if (request.CanSplitPassengers)
            {
                var allocation = AllocatePassengersAcrossWagons(train.Wagons, totalPassengers);
                if (allocation.CanBeReserved)
                    return Ok(allocation);  // Başarılı rezervasyon cevabı
                else
                    return Ok(new ReservationResponse
                    {
                        CanBeReserved = false,
                        SeatingDetails = new List<SeatingDetail>() // Boş yerleşim ayrıntısı
                    });
            }
            else
            {
                // Kişilerin aynı vagonda olması gerektiğinde
                var allocation = AllocatePassengersInSingleWagon(train.Wagons, totalPassengers);
                if (allocation.CanBeReserved)
                    return Ok(allocation);  // Başarılı rezervasyon cevabı
                else
                    return Ok(new ReservationResponse
                    {
                        CanBeReserved = false,
                        SeatingDetails = new List<SeatingDetail>() // Boş yerleşim ayrıntısı
                    });
            }
        }

        // Kişilerin aynı vagona yerleştirilmesi
        private ReservationResponse AllocatePassengersInSingleWagon(IEnumerable<Wagon> wagons, int totalPassengers)
        {
            foreach (var wagon in wagons)
            {
                if (wagon == null)
                    continue;

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
                if (wagon == null)
                    continue;

                int availableSeats = (int)(wagon.Capacity * 0.7) - wagon.OccupiedSeats;

                if (availableSeats > 0)
                {
                    int allocatedPassengers = Math.Min(remainingPassengers, availableSeats);

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
    