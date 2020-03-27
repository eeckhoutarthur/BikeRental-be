using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    public class Bike
    {
        #region Properties
        public int ID { get; set; }
/*        public int BrandId { get; set; }*/
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool DiscBrakes { get; set; }
        [Required]
        public BrandEnum BikeBrand { get; set; }
        public Groupset BikeGroupset { get; set; }
        public BikeType BikeType { get; set; }

        #endregion

        #region Constructors
        public Bike()
        {
        }

        public Bike(string name, BrandEnum bikeBrand, Groupset bikeGroupset, BikeType bikeType, bool discBrakes, decimal price)
        {
            Name = name;
            BikeBrand = bikeBrand;
            BikeGroupset = bikeGroupset;
            BikeType = bikeType;
            DiscBrakes = discBrakes;
            Price = price;
        }
        #endregion
    }
}
