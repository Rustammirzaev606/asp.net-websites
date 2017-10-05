using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace BookExchange3.Models
{
    public class Reserve
    {
        public int ID { get; set; }
        
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
        public virtual Books book { get; set; }
        public DateTime ReserveBeginDate { get; set; }
        public DateTime ReserveEndDate { get; set; }
    }
}