using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            // Mark FK as optional explicitly
            builder.Property(f => f.PlaneId).IsRequired(false);

            // One-to-many Flight -> Plane 
            builder.HasOne(f => f.Plane)
                   .WithMany(p => p.Flights)
                   .HasForeignKey(f => f.PlaneId)
                   .OnDelete(DeleteBehavior.SetNull);





            // Many-to-many Flight <-> Passenger rename join table to Reservation
            builder.HasMany(f => f.Passengers)
                   .WithMany(p => p.Flights)
                   .UsingEntity<Dictionary<string, object>>(
                        "Reservation",
                        j => j.HasOne<Passenger>()
                              .WithMany()
                              .HasForeignKey("PassengerId")
                              .OnDelete(DeleteBehavior.Cascade),
                        j => j.HasOne<Flight>()
                              .WithMany()
                              .HasForeignKey("FlightId")
                              .OnDelete(DeleteBehavior.Cascade),
                        j =>
                        {
                            j.ToTable("Reservation");
                            j.HasKey("FlightId", "PassengerId");
                        });
        }
    }
}

