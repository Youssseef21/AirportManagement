using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
       public enum PlaneType
    {
        Boeing, Airbus
    }
    public class Plane
    {
        //public Plane(PlaneType planeType, int capacity, DateTime manufactureDate)
        //{
        //    PlaneType = planeType;
        //    Capacity = capacity;
        //    ManufactureDate = manufactureDate;
        //}

        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "Plane " +  " of type " + PlaneType + " with capacity " + Capacity + " manufactured on " + ManufactureDate;
        }


    }
}
