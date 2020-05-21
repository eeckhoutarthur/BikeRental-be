using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public Bike Bike { get; set; }
        [Required]
        public string customerEmail { get; set; }

        public Orders(){}

        public Orders(DateTime start, DateTime end,Bike bike, string customer)
        {
            StartDate = start;
            EndDate = end;
            Bike = bike;
            customerEmail = customer;
        }

    }
}
