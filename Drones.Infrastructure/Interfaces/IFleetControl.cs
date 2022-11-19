using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drones.Core.Models;

namespace Drones.Infrastructure.Interfaces
{
    public interface IFleetControl
    {
        public Task RegisteringDrone(Drone drone);
        public Task LoadingDrone(int DroneId, List<Medication> medications);
        public int DroneBatteryLevel(int DroneId);
        public List<Drone> CheckingAvailableDronesForLoading();
        public List<Medication> CheckingLoadedMedication(int DroneId);
    }
}
