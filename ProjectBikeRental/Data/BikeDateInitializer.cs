using Microsoft.AspNetCore.Identity;
using ProjectBikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                Customer customer2 = new Customer("Mooij","Dylan","67897337", "dylan.mooij@student.hogent.be");
                _dbContext.Customers.AddRange(new Customer[] { customer, customer2 });

                //-> Admin
                await CreateUser(customer.Email, "W@woord5",true);
                //-> Customer
                await CreateUser(customer2.Email, "W@woord6",false);

                _dbContext.SaveChanges();

                Bike[] bikes = new Bike[] { new Bike("Tarmac",BrandEnum.Specialized, Groupset.Shimano, BikeType.Road_Bike, true, 20m),
                    new Bike("Madone SLR 9 Disc eTap",BrandEnum.Trek, Groupset.Sram, BikeType.Road_Bike, true, 25m),
                    new Bike("S-Works Epic Hardtail AXS",BrandEnum.Specialized, Groupset.Sram,BikeType.Mountain_Bike,true,30m),
                    new Bike("Kanzoe Ultegra",BrandEnum.Ridley, Groupset.Shimano,BikeType.E_Bike,true,22m)
                };
                _dbContext.Bikes.AddRange(bikes);
                _dbContext.SaveChanges();

                Orders order = new Orders(new DateTime(2020, 02, 13), new DateTime(2020, 02, 16), bikes[0], customer.Email);
                Orders order2 = new Orders(new DateTime(2020, 02, 14), new DateTime(2020, 02, 16), bikes[1], customer2.Email);
                Orders order3 = new Orders(new DateTime(2020, 02, 14), new DateTime(2020, 02, 16), bikes[3], customer2.Email);
                _dbContext.Orders.AddRange(new Orders[] { order, order2,order3 });
                _dbContext.SaveChanges();
            }
        }
        private async Task CreateUser(string email, string password, bool admin)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim("Rol", admin ? "admin" : "user"));
        }
    }
}
