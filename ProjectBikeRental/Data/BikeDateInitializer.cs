using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public BikeDateInitializer(BikeDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task IniInitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Customer customer = new Customer("Eeckhout", "Arthur", "1234455", "arthur.eeckhout@student.hogent.be");
/*                customer.AddOrder(order);*/
                _dbContext.Customers.Add(customer);
                await CreateUser(customer.Email, "W@woord5");
                _dbContext.SaveChanges();

                Bike[] bikes = new Bike[] { new Bike("Tarmac",BrandEnum.Specialized, Groupset.Shimano, BikeType.Road_Bike, true, 5000m),
                    new Bike("Madone SLR 9 Disc eTap",BrandEnum.Trek, Groupset.Sram, BikeType.Road_Bike, true, 12600m),
                    new Bike("S-Works Epic Hardtail AXS",BrandEnum.Specialized, Groupset.Sram,BikeType.Mountain_Bike,true,9000m),
                    new Bike("Kanzoe Ultegra",BrandEnum.Ridley, Groupset.Shimano,BikeType.E_Bike,true,7000m)
                };
                _dbContext.Bikes.AddRange(bikes);
                _dbContext.SaveChanges();

                Orders order = new Orders(new DateTime(2020, 02, 13), new DateTime(2020, 02, 16), bikes[0], new Customer("Eeckhout", "Arthur", "1234455", "arthur.eeckhout@student.hogent.be"));
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
            }
        }
        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
