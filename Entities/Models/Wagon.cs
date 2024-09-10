
namespace Entities.Models
{
    public class Wagon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int OccupiedSeats { get; set; }
        // Foreign key to relate Wagon to Train
        public int TrainId { get; set; }

        // Navigation property to represent the relationship with Train
        public Train Train { get; set; }

    }
}
