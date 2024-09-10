using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Config
{
    public class TrainConfig : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            // Train seed data
            builder.HasData(
                new Train
                {
                    Id = 1,
                    Name = "Başkent Ekspres"
                }
            );
        }
    }
}
