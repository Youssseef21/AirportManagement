using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // added for data annotations
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Date invalide")]
        public DateTime BirthDate { get; set; }

        [MaxLength(25, ErrorMessage = "max taille 25")]
        [MinLength(3, ErrorMessage = "min taille 3")]
        public string FirstName { get; set; }
        public string LastName { get; set; }



        [StringLength(7)]
        public string PassportNumber { get; set; }

        [EmailAddress(ErrorMessage = "Adresse email invalide")]
        public string EmailAddress { get; set; }

        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Le numéro de téléphone doit contenir exactement 8 chiffres")] // validation 8 digits
        public string TelNumber { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection <Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return "Passenger " + FirstName + " " + LastName + " with passport number " + PassportNumber;
        }

        public bool CheckProfile(string firstName, string lastName)
        {
            return firstName == FirstName && lastName == LastName;
        }
        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return firstName == FirstName && lastName == LastName && email == EmailAddress;
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

    }

}
