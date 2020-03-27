using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    //Deze klasse heb ik aangemaakt om aan de minimum requirements te voldoen. Vandaar dat ik toch nog van de enum "BrandEnum" gebruiker maak bij aanmaak van een Brand.
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Bike> Bikes { get; set; }

        public Brand(){ }

        public Brand(string name )
        {
            Name = name;
        }

    }
}
