using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GSM { get; set; }
        public string Email { get; set; }

        public ICollection<Orders> Orders { get; protected set; }


        public Customer()
        {
            Orders = new List<Orders>();
        }

        public Customer(string name, string firstName,string gsm, string email) : this()
        {
            LastName = name;
            FirstName = firstName;
            GSM = gsm;
            Email = email;
        }

        public void AddOrder(Orders order)
        {
            Orders.Add(order);
        }
    }
}
