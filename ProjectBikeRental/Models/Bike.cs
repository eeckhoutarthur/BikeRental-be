using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    public class Bike
    {
        #region Properties
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Brand BikeBrand { get; set; }

        public Groupset BikeGroupset { get; set; }

        public Type BikeType { get; set; }

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
        #endregion
    }
}
