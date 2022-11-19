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
        public MemoryAirport memoryAirport;

        public FleetControl()
        {
            this.memoryAirport = new MemoryAirport();
        }
        public Task RegisteringDrone(Drone drone)
        {
            throw new NotImplementedException();
        }
    }
}
