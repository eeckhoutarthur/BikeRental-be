using ProjectBikeRental.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace BikeRentalTest.Data
{
    public class DummyDbContext
    {
        public Orders order { get; }
        public Bike bike { get; }
        public Bike bike2 { get; }
        public Customer customer { get; }
        public List<Bike> alleBikes { get; }

        public DummyDbContext()
        {
            bike = new Bike("Tarmac", BrandEnum.Specialized, Groupset.Shimano, BikeType.Road_Bike, true, 20m);
            bike2 = new Bike("Venge", BrandEnum.Specialized, Groupset.Shimano, BikeType.Road_Bike, true, 20m);
            customer = new Customer("Eeckhout", "Arthur", "1234455", "arthur.eeckhout@student.hogent.be");
            order = new Orders(new DateTime(2020, 02, 13), new DateTime(2020, 02, 16), bike, customer.Email);

            alleBikes = new List<Bike>()
            {
                bike,bike2
            };
        }

    }
}
