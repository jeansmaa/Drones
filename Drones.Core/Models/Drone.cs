using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Core.Models
{
    public enum Model{ Lightweight, Middleweight, Cruiserweight, Heavyweight }
    public enum State { IDLE, LOADING, LOADED, DELIVERING, DELIVERED, RETURNING }
    public class Drone
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public Model Model { get; set; }
        public double WeightLimit { get; set; }
        public int BatteryCapacity { get; set; }
        public State State { get; set; }
        public List<Medication> Medications { get; set; }
        public Drone()
        {
            this.Medications = new List<Medication>();
        }
    }
}
