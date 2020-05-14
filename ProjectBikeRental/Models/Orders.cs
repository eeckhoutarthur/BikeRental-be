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
        //-> FK
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public Bike Bike { get; set; }
        [Required]
        public Customer Customer { get; set; }

        public Orders(){}

        public Orders(DateTime start, DateTime end,Bike bike, Customer customer)
        {
            StartDate = start;
            EndDate = end;
            Bike = bike;
            Customer = customer;
        }

    }
}
