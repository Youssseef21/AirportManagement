using AM.ApplicationCore.Domain;

//Plane plane = new Plane();
//plane.Capacity = 200;
//plane.ManufactureDate = new DateTime(2020, 01, 01);
//plane.PlaneType = PlaneType.Airbus;
//Console.WriteLine(plane);

using AM.ApplicationCore.Services;

int main()
{
    ServiceFlight serviceFlight = new ServiceFlight();
    serviceFlight.Flights = TestData.listFlights;
    foreach (var item in serviceFlight.GetFlightDates("Paris"))
        Console.WriteLine(item);
    return 0;
}
main();


//using AM.ApplicationCore.Domain;

//Plane plane = new Plane
//{
//    Capacity = 200,
//    ManufactureDate = new DateTime(2020, 01, 01),
//    PlaneType = PlaneType.Airbus
//};
//Console.WriteLine(plane);

//using AM.ApplicationCore.Domain;
//Plane plane = new Plane(PlaneType.Airbus, 200, new DateTime(2020, 01, 01));
//Console.WriteLine(plane);


//using AM.ApplicationCore.Domain;
//using AM.ApplicationCore.Services;

//Passenger passenger = new Passenger
//{
//    FirstName = "John",
//    LastName = "Doe",
//    BirthDate = new DateTime(1990, 01, 01),
//    EmailAddress = "youssef@gmail.com"
//};
//passenger.PassengerType();
//Traveller traveller = new Traveller();
//traveller.PassengerType();
//Staff staff = new Staff();
//staff.PassengerType();
//Passenger passenger1 = new Passenger
//{
//    FirstName = "Jane",
//    LastName = "Doe",
//    BirthDate = new DateTime(1990, 01, 01),
//    EmailAddress = "passenger@gmail.com"
//};

//Console.WriteLine(passenger.CheckProfile("John", "Doe"));

//ServiceFlight serviceFlight = new ServiceFlight();

//serviceFlight.Flights=TestData.listFlights;

//foreach (var item in serviceFlight.GetFlightDates( "Paris"))
//       Console.WriteLine(item);
//};