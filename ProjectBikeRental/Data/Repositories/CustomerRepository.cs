using Microsoft.EntityFrameworkCore;
using ProjectBikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BikeDbContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(BikeDbContext context)
        {
            _context = context;
            _customers = _context.Customers;
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer GetByEmail(string email)
        {
            return _customers.FirstOrDefault(c => c.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
