using Microsoft.EntityFrameworkCore;
using ProjectBikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BikeDbContext _context;
        private readonly DbSet<Orders> _orders;

        public OrderRepository(BikeDbContext context)
        {
            _context = context;
            _orders = context.Orders;
        }

        public void Add(Orders orders)
        {
            _orders.Add(orders);
        }

        public IEnumerable<Orders> GetAll()
        {
            return _orders.Include(b=>b.Bike).ToList().OrderByDescending(o => o.StartDate);
        }

        public Orders GetBy(int id)
        {
            return _orders.SingleOrDefault(o => o.OrderId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
