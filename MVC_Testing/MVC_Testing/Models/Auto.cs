using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_Testing.Models
{
    public class Auto
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

    }
    
    public class AutoDbContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
    }
}