using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public List<DateTime> GetFlightDates(string destination)
        {
            return Flights
                .Where(f => f.destination == destination)
                .Select(f => f.flightDate)
                .ToList();
        }

        public List<DateTime> GetFlightDates2(string destination)
        {
            var query =
                from f in Flights
                where f.destination == destination
                select f.flightDate;

            return query.ToList();
        }
        public void ShowFlightDetails(Plane plane)
        {
            var query =
                from f in Flights
                where f.Plane == plane
                select new { f.flightDate, f.destination };

            foreach (var item in query)
            {
                Console.WriteLine(item.flightDate + " -> " + item.destination);
            }
        }
        public void ShowFlightDetails2(Plane plane)
        {
            var query = Flights
                .Where(f => f.Plane == plane)
                .Select(f => new { f.flightDate, f.destination });

            foreach (var item in query)
            {
                Console.WriteLine(item.flightDate + " -> " + item.destination);
            }
        }










      
        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            if (flight?.Passengers == null)
                return Enumerable.Empty<Traveller>();

            return flight.Passengers
                         .OfType<Traveller>()
                         .OrderBy(t => t.BirthDate)
                         .Take(3);
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var grouped = Flights
                .GroupBy(f => f.destination)
                .OrderBy(g => g.Key);

            foreach (var group in grouped)
            {
                Console.WriteLine($"Destination {group.Key}");
                foreach (var flight in group.OrderBy(f => f.flightDate))
                {
                    Console.WriteLine($"Décollage : {flight.flightDate:dd/MM/yyyy HH : mm}");
                }
            }

            return grouped;
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var query =
                from f in Flights
                orderby f.EstimatedDuration descending, f.flightDate ascending
                select f;
            return query;
        }

        public int DurationAverage(string destination)
        {
            var query =
                from f in Flights
                where f.destination == destination
                select f.EstimatedDuration;
            return (int)query.Average();
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var endDate = startDate.AddDays(7);
            return Flights.Count(f => f.flightDate >= startDate && f.flightDate < endDate);
        }
       










        public int ProgrammedFlightNumber2(DateTime startDate)
        {
            var endDate = startDate.AddDays(7);

            var query =
                from f in Flights
                where f.flightDate >= startDate && f.flightDate < endDate
                select f;

            return query.Count();
        }

        public int DurationAverage2(string destination)
        {
            return (int)Flights
                .Where(f => f.destination == destination)
                .Average(f => f.EstimatedDuration);
        }
        public IEnumerable<Flight> OrderedDurationFlights2()
        {
            return Flights
                .OrderByDescending(f => f.EstimatedDuration)
                .ThenBy(f => f.flightDate);
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch(filterType)
            {
                case "destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.destination == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.departure == filterValue)
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid filter type");
                    break;
            }
        }
      

    }
}
