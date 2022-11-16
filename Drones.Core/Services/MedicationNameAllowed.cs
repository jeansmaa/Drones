using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Drones.Core.Services
{
    public class MedicationNameAllowed
    {
        public bool Allowed(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z0-9_-]+$");
        }
    }
}
