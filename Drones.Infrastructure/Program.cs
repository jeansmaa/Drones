// See https://aka.ms/new-console-template for more information
using Drones.Core.Models;

Console.WriteLine("Loading demo data!");
Drones.Infrastructure.Services.MemoryAirport airport = new Drones.Infrastructure.Services.MemoryAirport();
for (int i = 0; i < 4; i++)
{
    Drones.Core.Models.Drone drone = new Drones.Core.Models.Drone();
    drone.Id = i;
    drone.Model = (Model)i;
    drone.SerialNumber = "SNumber" + i;
    drone.BatteryCapacity = 30;
    drone.State = (State)i;
    drone.WeightLimit = i + 20;
    airport.NewDrone(drone);
}
PrintData(1);
Medication medication=new Medication();
medication.Name = "Dipirona";
medication.Id = 1;
medication.Weight = 10;
Medication medication1 = new Medication();
medication1.Name = "Metamizol";
medication1.Id = 2;
medication1.Weight = 8;
List<Medication> medications = new List<Medication>();
medications.Add(medication);
medications.Add(medication1);
airport.LoadingDrone(3, medications);
PrintData(2);
void PrintData(int jd)
{
    Console.WriteLine("*******Juego de datos"+jd+"*******");
    foreach (var item in airport.Fleet)
    {
        Console.WriteLine("****************************");
        Console.WriteLine("DroneId: " + item.Id);
        Console.WriteLine("Serial Number: " + item.SerialNumber);
        Console.WriteLine("Drone Model: " + item.Model);
        Console.WriteLine("Battery Capacity: " + item.BatteryCapacity);
        Console.WriteLine("Drone State: " + item.State);
        Console.WriteLine("Drone Weight Limit: " + item.WeightLimit);
        Console.WriteLine("Drone Weight Available: " + airport.AvailableWeight(item.Id));
        Console.WriteLine("<<<<Medications on board>>>>");
        foreach (var item1 in item.Medications)
        {
            Console.WriteLine("Medication: " + item1.Name);
        }
    }
}
Console.Read();

