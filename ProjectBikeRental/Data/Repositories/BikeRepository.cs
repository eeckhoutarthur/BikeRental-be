using Microsoft.EntityFrameworkCore;
using ProjectBikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Data.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly BikeDbContext _context;
        private readonly DbSet<Bike> _bikes;

        public BikeRepository(BikeDbContext context)
        {
            _context = context;
            _bikes = context.bikes;
        }

        public void Add(Bike bike)
        {
            _bikes.Add(bike);
        }

        public void Delete(Bike bike)
        {
            _bikes.Remove(bike);
        }

        public IEnumerable<Bike> GetAll()
        {
            return _bikes.ToList();
        }

        public Bike GetBy(int id)
        {
            return _bikes.SingleOrDefault(b => b.ID == id);
        }

        public IEnumerable<Bike> GetBy(Models.BikeType? type = null, Brand? brand = null, Groupset? groupset = null)
        {
            return _bikes.Where(b => b.BikeType == type && b.BikeBrand == brand && b.BikeGroupset == groupset);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Bike bike)
        {
            _context.Update(bike);
        }
    }
}
