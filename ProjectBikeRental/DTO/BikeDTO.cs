using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ProjectBikeRental.Models;

namespace ProjectBikeRental.DTO
{
    public class BikeDTO
    {
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

    }
}
