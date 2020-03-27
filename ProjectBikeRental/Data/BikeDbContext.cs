using Microsoft.EntityFrameworkCore;
using ProjectBikeRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Data
{
    public class BikeDbContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }

        public BikeDbContext(DbContextOptions<BikeDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Bike>().HasKey(b => b.ID);
            builder.Entity<Bike>().Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Bike>().Property(b => b.Price).IsRequired().HasColumnType("decimal(18,2)"); ;
            builder.Entity<Bike>().Property(b => b.DiscBrakes).IsRequired();
/*
            builder.Entity<Brand>().HasMany(br => br.Bikes).WithOne(b => b.BikeBrand);*/
/*            builder.Entity<Brand>().Property(b => b.Name).IsRequired().HasMaxLength(150);*/
        }
    }
}
