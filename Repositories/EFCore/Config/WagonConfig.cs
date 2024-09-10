using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Config
{
    public class WagonConfig : IEntityTypeConfiguration<Wagon>
    {
        public void Configure(EntityTypeBuilder<Wagon> builder)
        {
            // Wagon seed data with TrainId to establish the relationship
            builder.HasData(
                new Wagon
                {
                    Id = 1,
                    Name = "Wagon 1",
                    Capacity = 100,
                    OccupiedSeats = 68
                },
                new Wagon
                {
                    Id = 2,
                    Name = "Wagon 2",
                    Capacity = 90,
                    OccupiedSeats = 50
                },
                new Wagon
                {
                    Id = 3,
                    Name = "Wagon 1",
                    Capacity = 80,
                    OccupiedSeats = 60
                },
                new Wagon
                {
                    Id = 4,
                    Name = "Wagon 2",
                    Capacity = 75,
                    OccupiedSeats = 70
                }
            );
        }
    }
}
