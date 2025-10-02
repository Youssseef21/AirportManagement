using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AM.Infrastructure
{
    internal class AMContext : DbContext
    {
        public DbSet<AM.ApplicationCore.Domain.Plane> Planes { get; set; }
        public DbSet<AM.ApplicationCore.Domain.Flight> Flights { get; set; }
        public DbSet<AM.ApplicationCore.Domain.Passenger> Passengers { get; set; }
        public DbSet<AM.ApplicationCore.Domain.Staff> Staffs { get; set; }
        public DbSet<AM.ApplicationCore.Domain.Traveller> Travellers { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AirportManagmentdb;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
    

}
