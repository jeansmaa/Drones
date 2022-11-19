using Drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Infrastructure.Services
{
    public class MemoryAirport
    {
        public List<Drone> Fleet { get; set; }
        public MemoryAirport()
        {
            this.Fleet = new List<Drone>();
        }

        private int BatteryCapacity(int DroneId)//ok
        {
            return PeekDrone(DroneId).BatteryCapacity;
        }
        public double AvailableWeight(int DroneId)//ok
        {
            double weightloaded=0;
            Drone drone=PeekDrone(DroneId);
            foreach (var item in drone.Medications)
            {
                weightloaded += item.Weight;
            }
            return drone.WeightLimit - weightloaded;
        }
        private Drone PeekDrone(int DroneId)//ok
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
            List<Drone> available=new List<Drone>();
            foreach (var drone in this.Fleet)
            {
                if (AvailableWeight(drone.Id) < drone.WeightLimit)
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
                if (drone.Id == DroneId)
                {
                    foreach (var med in medications)
                    {
                        if (AvailableWeight(drone.Id) >= med.Weight)
                        {
                            drone.Medications.Add(med);
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
