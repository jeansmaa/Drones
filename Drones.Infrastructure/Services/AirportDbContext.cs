using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drones.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace Drones.Infrastructure.Services
{
    public class AirportDbContext:DbContext
    {       
        public AirportDbContext(DbContextOptions<AirportDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Drone> Drones { get; set; }
    }
    
}
