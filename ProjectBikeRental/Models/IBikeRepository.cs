using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    public interface IBikeRepository
    {
        Bike GetBy(int id);
        IEnumerable<Bike> GetAll();
        void Add(Bike bike);
        void Delete(Bike bike);
        void Update(Bike bike);
        void SaveChanges();
    }
}
