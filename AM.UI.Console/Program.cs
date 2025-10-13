using System;
using System.Linq;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

int main()
{
    ServiceFlight serviceFlight = new ServiceFlight();
    serviceFlight.Flights = TestData.listFlights;

    Console.WriteLine("=== Flight dates to Paris ===");
    foreach (var item in serviceFlight.GetFlightDates("Paris"))
        Console.WriteLine(item);

    Console.WriteLine("\n=== Destination grouped flights ===");
    serviceFlight.DestinationGroupedFlights();

    
    Console.WriteLine("\n=== Ordered by duration ===");
    foreach (var f in serviceFlight.OrderedDurationFlights())
        Console.WriteLine(f);

   
    Console.WriteLine("\n=== Duration average to Paris ===");
    Console.WriteLine(serviceFlight.DurationAverage("Paris"));

    
    var startDate = serviceFlight.Flights.Min(f => f.flightDate);
    Console.WriteLine("\n=== Programmed flights in 7 days starting " + startDate.ToString("yyyy-MM-dd") + " ===");
    Console.WriteLine(serviceFlight.ProgrammedFlightNumber(startDate));

    
    Console.WriteLine("\n=== Senior travellers of first flight ===");
    var firstFlight = serviceFlight.Flights.FirstOrDefault();
    if (firstFlight != null)
    {
        foreach (var t in serviceFlight.SeniorTravellers(firstFlight))
            Console.WriteLine($"{t.FirstName} {t.LastName} - {t.BirthDate:yyyy-MM-dd}");
    }

    return 0;
}
main();