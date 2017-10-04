using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone1._2.Models
{
    public class Reserve
    {
        public int ID { get; set; }
        public DateTime ReserveBeginDate { get; set; } = DateTime.Now;
        public DateTime ReserveEndDate { get; set; } = DateTime.Now.AddDays(3);
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual  books book { get; set; }

    }
}