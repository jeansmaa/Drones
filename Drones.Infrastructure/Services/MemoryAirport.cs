﻿using Drones.Core.Models;
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
            double weightloaded=0;
            Drone drone=PeekDrone(DroneId);
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
            List<Drone> available=new List<Drone>();
            foreach (var drone in this.Fleet)
            {
                if (AvailableWeight(drone.Id) < drone.WeightLimit)
                {
                    if (DroneBatteryLevel(drone.Id) >= 25)
                    {
                        available.Add(drone);
                    }                    
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
                            if (drone.BatteryCapacity >= 25)
                            {
                                drone.Medications.Add(med);
                            }                            
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
        private void LoadData()
        {
            for (int i = 0; i < 4; i++)
            {
                Drone drone = new Drone();
                drone.Id = i;
                drone.Model = (Model)i;
                drone.SerialNumber = "SNumber" + i;
                drone.BatteryCapacity = 39;
                drone.State = (State)i;
                drone.WeightLimit = i + 20;
                this.Fleet.Add(drone);
            }
        }
    }
}
