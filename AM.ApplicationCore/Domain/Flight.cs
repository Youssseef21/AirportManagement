using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string destination { get; set; }
        public DateTime flightDate { get; set; }
        public string flightId { get; set; }
        public string departure { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public virtual Plane Plane { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }

        public override string ToString()
        {
                return "Flight " + flightId + " from " + departure + " to " + destination + " on " + flightDate;
        }








    }
}
