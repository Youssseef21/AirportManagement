using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // for DataType.Currency

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency, ErrorMessage = "Invalid salary value")]
        public int Salary { get; set; }
        public override void PassengerType()
        {
            Console.WriteLine("I am a staff");
        }
    }
}
