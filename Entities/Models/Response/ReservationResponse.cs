
namespace Entities.Models.Response
{
    public class ReservationResponse
    {
        public bool CanBeReserved { get; set; }
        public List<SeatingDetail> SeatingDetails { get; set; }
    }
}
