using ProjectBikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Data
{
    public class BikeDateInitializer
    {
        private readonly BikeDbContext _dbContext;

        public BikeDateInitializer(BikeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void IniInitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
/*                Bike tarmac = new Bike("Tarmac",Brand.Specialized,Groupset.Shimano,BikeType.Road_Bike,true,5000m);
                Bike madone = new Bike("Madone SLR 9 Disc eTap", Brand.Trek, Groupset.Sram, BikeType.Road_Bike, true, 12600m);*/

                Bike[] bikes = new Bike[] { new Bike("Tarmac",BrandEnum.Specialized, Groupset.Shimano, BikeType.Road_Bike, true, 5000m), 
                    new Bike("Madone SLR 9 Disc eTap",BrandEnum.Trek, Groupset.Sram, BikeType.Road_Bike, true, 12600m) };

                Customer customer = new Customer("Eeckhout", "Arthur", "1234455", "arthur.eeckhout@student.hogent/be");
                /*                customer.AddOrder(new Orders(new DateTime(2020, 02, 13), new DateTime(2020, 02, 16)))*/
                ;

                Orders order = new Orders(new DateTime(2020, 02, 13), new DateTime(2020, 02, 16),bikes[0],customer);

                _dbContext.Bikes.AddRange(bikes);
/*                _dbContext.Customers.Add(customer)*/;
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
            }
        }
    }
}
