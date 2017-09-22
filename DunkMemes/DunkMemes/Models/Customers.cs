using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace DunkMemes.Models
{
    public class Customers
    {        
        public int ID { get; set; }
        [Display(Name = "First Name"), Required, StringLength(10, MinimumLength = 3)]
        public string FIrstName { get; set; }
        [Display(Name = "Last Name"), Required, StringLength(10, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Range(18, 95)]
        public int Age { get; set; }
    }

    public class CustomersDbContext : DbContext
    {
        public DbSet<Customers> Custies { get; set; }

    }

}