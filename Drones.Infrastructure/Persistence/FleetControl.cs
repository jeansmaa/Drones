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
            throw new NotImplementedException();
        }

        public List<Medication> CheckingLoadedMedication(int DroneId)
        {
            throw new NotImplementedException();
        }

        public int DroneBatteryLevel(int DroneId)
        {
            throw new NotImplementedException();
        }

        public Task LoadingDrone(int DroneId, List<Medication> medications)
        {
            throw new NotImplementedException();
        }

        public Task RegisteringDrone(Drone drone)
        {

            //throw new NotImplementedException();
        }
    }
}
