using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string TelNumber { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "Passenger " + FirstName + " " + LastName + " with passport number " + PassportNumber;
        }

        public bool CheckProfile(string firstName, string lastName)
        {
            return firstName == FirstName && lastName == LastName;
        }
        public  bool CheckProfile(string firstName, string lastName, string email)
        {
            return firstName == FirstName && lastName == LastName && email == EmailAddress;
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }



    }
}
