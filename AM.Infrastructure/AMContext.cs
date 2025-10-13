using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AM.Infrastructure.Configuration;


namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        public DbSet<AM.ApplicationCore.Domain.Plane> Planes { get; set; }
        public DbSet<AM.ApplicationCore.Domain.Flight> Flights { get; set; }
        public DbSet<AM.ApplicationCore.Domain.Passenger> Passengers { get; set; }
        public DbSet<AM.ApplicationCore.Domain.Staff> Staffs { get; set; }
        public DbSet<AM.ApplicationCore.Domain.Traveller> Travellers { get; set; }
        public DbSet<AM.ApplicationCore.Domain.Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AirportManagmentdb;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            
            configurationBuilder.Properties<DateTime>()
                                 .HaveColumnType("date");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
        }
    }
    

}
