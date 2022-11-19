using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drones.Core.Models;
using Drones.Infrastructure.Interfaces;
using Drones.Infrastructure.Services;

namespace Drones.Infrastructure.Persistence
{
    public class FleetControl : IFleetControl
    {
        public MemoryAirport airport;

        public FleetControl()
        {
            this.airport = new MemoryAirport();
        }

        public List<Drone> CheckingAvailableDronesForLoading()
        {
            try
            {
                return this.airport.CheckingAvailableDronesForLoading();
            }
            catch
            {
                throw new Exception("Internal Server Issue: Airport Flow");
            }
        }

        public List<Medication> CheckingLoadedMedication(int DroneId)
        {
            try
            {
                return this.airport.CheckingLoadedMedication(DroneId);
            }
            catch
            {
                throw new Exception("Internal Server Issue: Airport Flow");
            }
        }

        public int DroneBatteryLevel(int DroneId)
        {
            try
            {
                return this.airport.DroneBatteryLevel(DroneId);
            }
            catch
            {
                throw new Exception("Internal Server Issue: Airport Flow");
            }
        }

        public Drone GetDroneById(int DroneId)
        {
            try
            {
                return this.airport.PeekDrone(DroneId);
            }
            catch
            {
                throw new Exception("Internal Server Issue: Airport Flow");
            }
        }

        public Task LoadingDrone(int DroneId, List<Medication> medications)
        {
            try
            {
                this.airport.LoadingDrone(DroneId, medications);
                return Task.CompletedTask;
            }
            catch
            {
                throw new Exception("Internal Server Issue: Airport Flow");
            }
        }

        public Task RegisteringDrone(Drone drone)
        {
            try
            {
                this.airport.NewDrone(drone);
                return Task.CompletedTask;
            }
            catch
            {
                throw new Exception("Internal Server Issue: Airport Flow");
            }
        }
    }
}
