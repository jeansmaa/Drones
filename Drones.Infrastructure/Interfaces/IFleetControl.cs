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
    }
}
