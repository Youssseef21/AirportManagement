using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public int NumTicket { get; set; }

        public int Passengerfk { get; set; }

        public string Flightfk { get; set; } // match Flight.flightId (string)
        public float Prix { get; set; }
        public bool VIP { get; set; }
        public virtual Passenger Passenger { get; set; }
        public virtual Flight Flight { get; set; }
        public int Siege { get; set; }
        public DateTime DateAchat { get; set; }
    }
}
