using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    public interface IOrderRepository
    {
        void Add(Orders orders);
        Orders GetBy(int id);
        IEnumerable<Orders> GetAll();
        void SaveChanges();
    }
}
