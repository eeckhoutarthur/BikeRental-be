using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    public interface ICustomerRepository
    {
        Customer GetByEmail(string email);
        void Add(Customer customer);
        void SaveChanges();
    }
}
