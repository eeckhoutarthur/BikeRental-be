using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    public class Bike
    {
        #region Properties
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Brand BikeBrand { get; set; }

        [Required]
        public Groupset BikeGroupset { get; set; }

        [Required]
        public Type BikeType { get; set; }

        [Required]
        public bool DiscBrakes { get; set; }
        #endregion

        #region Constructors
        public Bike()
        {

        }

        public Bike(string name, Brand bikeBrand, Groupset bikeGroupset, Type bikeType, bool discBrakes, decimal price)
        {
            Name = name;
            BikeBrand = bikeBrand;
            BikeGroupset = bikeGroupset;
            BikeType = bikeType;
            DiscBrakes = discBrakes;
            Price = price;
        }

        private class RequireedAttribute : Attribute
        {
        }
        #endregion
    }
}
