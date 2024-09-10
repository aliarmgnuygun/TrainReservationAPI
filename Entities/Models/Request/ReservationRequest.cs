namespace Entities.Models.Request
{
    public class ReservationRequest
    {
        public Train Train { get; set; }
        public int NumberOfPassengers { get; set; } 
        public bool CanSplitPassengers { get; set; } 
    }
}
