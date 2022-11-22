using Drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Infrastructure.Services
{
    public class MemoryAirport
    {
        public List<Drone> Fleet { get; set; }
        public List<Medication> MedicationStock { get; set; }
        public MemoryAirport()
        {
            this.Fleet = new List<Drone>();
            this.MedicationStock = new List<Medication>();
            LoadData();
        }

        private int BatteryCapacity(int DroneId)//ok
        {
            return PeekDrone(DroneId).BatteryCapacity;
        }
        public double AvailableWeight(int DroneId)//ok
        {
            double weightloaded = 0;
            Drone drone = PeekDrone(DroneId);
            foreach (var item in drone.Medications)
            {
                weightloaded += item.Weight;
            }
            return drone.WeightLimit - weightloaded;
        }
        public Drone PeekDrone(int DroneId)//ok
        {
            Drone drone = new Drone();
            foreach (var item in this.Fleet)
            {
                if (item.Id == DroneId)
                {
                    drone = item;
                    break;
                }
            }
            return drone;
        }
        public void NewDrone(Drone drone)//ok
        {
            this.Fleet.Add(drone);
        }
        public List<Medication> CheckingLoadedMedication(int DroneId)
        {
            return PeekDrone(DroneId).Medications;
        }
        public List<Drone> CheckingAvailableDronesForLoading()
        {
            List<Drone> available = new List<Drone>();
            foreach (var drone in this.Fleet)
            {
                if (drone.WeightLimit == 0 ||
                    DroneBatteryLevel(drone.Id) < 25 ||
                    AvailableWeight(drone.Id) == 0)
                {
                    continue;
                }
                if (AvailableWeight(drone.Id) <= drone.WeightLimit)
                {
                    available.Add(drone);
                }
            }
            return available;
        }
        public int DroneBatteryLevel(int DroneId)
        {
            return BatteryCapacity(DroneId);
        }
        public void LoadingDrone(int DroneId, List<Medication> medications)
        {
            foreach (var drone in this.Fleet)
            {
                if (drone.Id == DroneId && drone.BatteryCapacity >= 25)
                {
                    foreach (var med in medications)
                    {
                        if (AvailableWeight(drone.Id) >= med.Weight)
                        {
                            drone.Medications.Add(med);
                        }
                        else
                        {
                            throw new Exception("Some medications were not loaded");
                        }
                    }
                    break;
                }
            }
        }
        private void LoadData()
        {
            for (int i = 0; i < 10; i++)
            {
                Drone drone = new Drone();
                drone.Id = i+1;
                if (i < 5)
                {
                    drone.Model = (Model)i;
                    drone.State = (State)i;
                }
                else
                {
                    drone.Model = (Model)i-5;
                    drone.State = (State)i-5;
                }
                drone.SerialNumber = "SNumber" + i+1;
                drone.BatteryCapacity = 58;
                               
                drone.WeightLimit = i + 20;                
                this.Fleet.Add(drone);
            }
        }
    }
}
