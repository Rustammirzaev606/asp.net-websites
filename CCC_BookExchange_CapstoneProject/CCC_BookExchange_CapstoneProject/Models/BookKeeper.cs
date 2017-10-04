using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CCC_BookExchange_CapstoneProject.Models
{
    public class BookKeeper
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int ISBN10 { get; set; }
        public int ISBN13 { get; set; }
        public virtual Donator donator { get; set; }
        public virtual Recipient recipient { get; set; }
        public virtual Requestor requestor { get; set; }
        public bool Available { get; set; } = false;
    }
    public class Donator
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class Recipient
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class Requestor
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class BooksDBContext : DbContext
    {
        public DbSet<BookKeeper> book { get; set; }
        public DbSet<Donator> donator { get; set; }
        public DbSet<Recipient> recipient { get; set; }
        public DbSet<Requestor> requestor { get; set; }
    }


}