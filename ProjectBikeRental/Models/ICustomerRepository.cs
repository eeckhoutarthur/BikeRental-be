using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    public interface ICustomerRepository
    {
        Customer GetByEmail(string email);
        IEnumerable<Customer> GetAll();
        void Add(Customer customer);
        void SaveChanges();
    }
}
