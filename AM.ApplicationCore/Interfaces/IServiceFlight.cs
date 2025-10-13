using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        List<DateTime> GetFlightDates(string destination);
        void ShowFlightDetails(Domain.Plane plane);
        void ShowFlightDetails2(Domain.Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        int ProgrammedFlightNumber2(DateTime startDate);
        void GetFlights(string filterType, string filterValue);
        IEnumerable<Traveller> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();
        int DurationAverage(string destination);
        IEnumerable<Flight> OrderedDurationFlights();
    }

}
