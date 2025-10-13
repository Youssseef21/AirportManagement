using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configuration
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            
            builder
                .HasDiscriminator<int>("IsTraveller")
                .HasValue<Passenger>(0)
                .HasValue<Traveller>(1)
                .HasValue<Staff>(2);
        }
    }
}
