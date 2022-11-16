using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Drones.Core.Services
{
    public class MedicationCodeAllowed
    {
        public bool Allowed(string code)
        {
            return Regex.IsMatch(code, @"^[A-Z0-9_]+$");
        }
    }
}
