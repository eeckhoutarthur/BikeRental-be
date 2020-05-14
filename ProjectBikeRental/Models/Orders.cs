using System;
using System.Collections.Generic;
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
        public Bike Bike { get; set; }
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
