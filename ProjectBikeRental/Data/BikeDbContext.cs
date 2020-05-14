using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectBikeRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Data
{
    public class BikeDbContext : IdentityDbContext
    {
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public BikeDbContext(DbContextOptions<BikeDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //-> Mapping Bike
            builder.Entity<Bike>().HasKey(b => b.ID);
            builder.Entity<Bike>().Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Bike>().Property(b => b.Price).IsRequired().HasColumnType("decimal(18,2)"); ;
            builder.Entity<Bike>().Property(b => b.DiscBrakes).IsRequired();

            //-> Mapping Customer
            builder.Entity<Customer>().HasKey(c => c.CustomerId);
            builder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.GSM).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(100);

/*            builder.Entity<Customer>().HasMany(c => c.Orders).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
*/
            //-> Mapping Orders
            builder.Entity<Orders>().HasKey(o => o.OrderId);
            builder.Entity<Orders>().HasOne(o => o.Customer).WithMany().HasForeignKey( c => c.CustomerId);
            builder.Entity<Orders>().HasOne(o => o.Bike);
        }
    }
}
