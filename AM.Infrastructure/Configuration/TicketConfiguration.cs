using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new {t.NumTicket, t.Passengerfk, t.Flightfk});

            builder.HasOne(t => t.Passenger)
                   .WithMany(p => p.Tickets)
                   .HasForeignKey(t => t.Passengerfk);



            builder.HasOne(t => t.Flight)
                   .WithMany(f => f.Tickets)
                   .HasForeignKey(t => t.Flightfk);
                   

        }
    }
}
