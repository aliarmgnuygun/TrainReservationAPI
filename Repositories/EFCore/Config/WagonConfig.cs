using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Config
{
    public class WagonConfig : IEntityTypeConfiguration<Wagon>
    {
        public void Configure(EntityTypeBuilder<Wagon> builder)
        { 
            builder.HasData(
                new Wagon
                {
                    Id = 1,
                    Name = "Vagon 1",
                    Capacity = 100,
                    OccupiedSeats = 68,
                    TrainId = 1
                },
                new Wagon
                {
                    Id = 2,
                    Name = "Vagon 2",
                    Capacity = 90,
                    OccupiedSeats = 50,
                    TrainId = 1
                },
                new Wagon
                {
                    Id = 3,
                    Name = "Vagon 3",
                    Capacity = 80,
                    OccupiedSeats = 60,
                    TrainId = 1
                }
            );
        }
    }
}
