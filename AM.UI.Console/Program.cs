using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using AM.ApplicationCore.Domain;
using AM.Infrastructure;

AMContext context = new AMContext();

bool exit = false;
while (!exit)
{
    Console.WriteLine();
    Console.WriteLine("=== Menu ===");
    Console.WriteLine("1. Ajouter un Avion");
    Console.WriteLine("2. Ajouter un Vol");
    Console.WriteLine("3. Ajouter un Voyageur");
    Console.WriteLine("4. Affecter des Vols à un avion");
    Console.WriteLine("5. Affecter des voyageurs à des vols");
    Console.WriteLine("6. Afficher le nombre de vols assuré par un avion");
    Console.WriteLine("7. Afficher le nombre de passagers pour chaque vol");
    Console.WriteLine("8. Quitter");
    Console.Write("Votre choix: ");

    var choice = Console.ReadLine();
    Console.WriteLine();
    switch (choice)
    {
        case "1":
            AjouterAvion();
            break;
        case "2":
            AjouterVol();
            break;
        case "3":
            AjouterVoyageur();
            break;
        case "4":
            AffecterVolsAAvion();
            break;
        case "5":
            AffecterVoyageursAVols();
            break;
        case "6":
            AfficherNombreVolsParAvion();
            break;
        case "7":
            AfficherNombrePassagersParVol();
            break;
        case "8":
            exit = true;
            Console.WriteLine("Au revoir.");
            break;
        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
}

// === Fonctions locales ===
void AjouterAvion()
{
    try
    {
        Console.WriteLine("Ajout d'un avion");
        Console.Write("Type d'avion (0=Boeing, 1=Airbus): ");
        var typeStr = Console.ReadLine();
        var planeType = Enum.Parse<PlaneType>(typeStr!, true);

        Console.Write("Capacité: ");
        var capacity = int.Parse(Console.ReadLine()!);

        Console.Write("Date de fabrication (yyyy-MM-dd): ");
        var manufactureDate = DateTime.Parse(Console.ReadLine()!);

        var plane = new Plane
        {
            PlaneType = planeType,
            Capacity = capacity,
            ManufactureDate = manufactureDate
        };

        context.Planes.Add(plane);
        context.SaveChanges();
        Console.WriteLine($"Avion ajouté avec Id: {plane.PlaneId}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur: {ex.Message}");
    }
}

void AjouterVol()
{
    try
    {
        Console.WriteLine("Ajout d'un vol");
        Console.Write("Identifiant du vol: ");
        var flightId = Console.ReadLine();

        Console.Write("Destination: ");
        var destination = Console.ReadLine();

        Console.Write("Départ: ");
        var departure = Console.ReadLine();

        Console.Write("Compagnie (Airline): ");
        var airline = Console.ReadLine();

        Console.Write("Date de vol (yyyy-MM-dd HH:mm): ");
        var flightDate = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Arrivée effective (yyyy-MM-dd HH:mm): ");
        var effectiveArrival = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Durée estimée (minutes): ");
        var estimatedDuration = int.Parse(Console.ReadLine()!);

       
        var flight = new Flight
        {
            flightId = flightId!,
            destination = destination!,
            departure = departure!,
            Airline = airline!,
            flightDate = flightDate,
            EffectiveArrival = effectiveArrival,
            EstimatedDuration = estimatedDuration,
                    };

        context.Flights.Add(flight);
        context.SaveChanges();
        Console.WriteLine("Vol ajouté.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur: {ex.Message}");
    }
}

void AjouterVoyageur()
{
    try
    {
        Console.WriteLine("Ajout d'un voyageur (Traveller)");
        Console.Write("Prénom: ");
        var firstName = Console.ReadLine();
        Console.Write("Nom: ");
        var lastName = Console.ReadLine();
        Console.Write("Numéro de passeport (7 chars): ");
        var passport = Console.ReadLine();
        Console.Write("Email: ");
        var email = Console.ReadLine();
        Console.Write("Téléphone (8 chiffres): ");
        var phone = Console.ReadLine();
        Console.Write("Date de naissance (yyyy-MM-dd): ");
        var birth = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Nationalité: ");
        var nationality = Console.ReadLine();
        Console.Write("Infos santé: ");
        var health = Console.ReadLine();

        var traveller = new Traveller
        {
            FirstName = firstName!,
            LastName = lastName!,
            PassportNumber = passport!,
            EmailAddress = email!,
            TelNumber = phone!,
            BirthDate = birth,
            Nationality = nationality ?? string.Empty,
            HealthInformation = health ?? string.Empty
        };

        context.Travellers.Add(traveller);
        context.SaveChanges();
        Console.WriteLine($"Voyageur ajouté avec Id: {traveller.PassengerId}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur: {ex.Message}");
    }
}

void AffecterVolsAAvion()
{
    try
    {
        Console.WriteLine("Affecter des vols à un avion");
        Console.Write("Id avion: ");
        var planeId = int.Parse(Console.ReadLine()!);
        var plane = context.Planes.Find(planeId);
        if (plane == null) { Console.WriteLine("Avion introuvable."); return; }

        Console.Write("Liste des flightId à affecter (séparés par des virgules): ");
        var idsInput = Console.ReadLine() ?? string.Empty;
        var ids = idsInput.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var flights = context.Flights.Where(f => ids.Contains(f.flightId)).ToList();
        foreach (var f in flights)
        {
            f.PlaneId = plane.PlaneId;
        }
        context.SaveChanges();
        Console.WriteLine($"{flights.Count} vol(s) affecté(s) à l'avion {plane.PlaneId}.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur: {ex.Message}");
    }
}

void AffecterVoyageursAVols()
{
    try
    {
        Console.WriteLine("Affecter des voyageurs à un vol");
        Console.Write("flightId: ");
        var fid = Console.ReadLine();

        var flight = context.Flights.FirstOrDefault(f => f.flightId == fid);
        if (flight == null) { Console.WriteLine("Vol introuvable."); return; }

        Console.Write("Liste des PassengerId à affecter (séparés par des virgules): ");
        var idsInput = Console.ReadLine() ?? string.Empty;
        var pidStrings = idsInput.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var pids = new HashSet<int>();
        foreach (var s in pidStrings)
        {
            pids.Add(int.Parse(s));
        }

        var passengers = context.Passengers.Where(p => pids.Contains(p.PassengerId)).ToList();

        context.Entry(flight).Collection(f => f.Passengers).Load();
        foreach (var p in passengers)
        {
            if (!flight.Passengers.Any(x => x.PassengerId == p.PassengerId))
                flight.Passengers.Add(p);
        }
        context.SaveChanges();
        Console.WriteLine($"{passengers.Count} voyageur(s) affecté(s) au vol {fid}.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur: {ex.Message}");
    }
}

void AfficherNombreVolsParAvion()
{
    try
    {
        Console.Write("Id avion: ");
        var planeId = int.Parse(Console.ReadLine()!);
        var count = context.Flights.Count(f => f.PlaneId == planeId);
        Console.WriteLine($"Nombre de vols pour l'avion {planeId}: {count}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur: {ex.Message}");
    }
}

void AfficherNombrePassagersParVol()
{
    var data = context.Flights
        .Select(f => new { f.flightId, Count = f.Passengers.Count() })
        .ToList();

    if (data.Count == 0)
    {
        Console.WriteLine("Aucun vol.");
        return;
    }

    foreach (var item in data)
    {
        Console.WriteLine($"Vol {item.flightId}: {item.Count} passager(s)");
    }
}

