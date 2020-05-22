using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBikeRental.DTO;
using ProjectBikeRental.Models;

namespace ProjectBikeRental.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //-> Zorgt ervoor dat je moet aangemeld zijn om de endpoints te gebruiken
    public class BikesController : ControllerBase
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly ICustomerRepository _customerRepository;
        public BikesController(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        /// <summary>
        /// Geeft alle fietsen terug, gesorteerd op stijgende prijs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Bike> GetBikes()
        {
            return _bikeRepository.GetAll().OrderBy(b => b.Price);
        }

        /// <summary>
        /// Geeft de fiets met het meegegeven id terug
        /// </summary>
        /// <param name="id">De id van de fiets</param>
        /// <returns>De fiets</returns>
        [HttpGet("{id}")]
        public ActionResult<Bike> Get(int id)
        {
            Bike bike = _bikeRepository.GetBy(id);
            if (bike == null)
                return NotFound();
            return bike;
        }

        /// <summary>
        /// Voegt een nieuwe fiets toe
        /// </summary>
        /// <remarks>Het id dient niet ingevuld te worden, dit gebeurt automatisch. De waarde mag dus op 0 blijven staan.</remarks>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult<Bike> CreateBike(BikeDTO bike)
        {
            Bike newBike = new Bike(bike.Name,bike.BikeBrand,bike.BikeGroupset,bike.BikeType,bike.DiscBrakes,bike.Price);
            _bikeRepository.Add(newBike);
            _bikeRepository.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = newBike.ID }, bike);
        }

        /// <summary>
        /// Verwijderd een fiets 
        /// </summary>
        /// <param name="id">De id van de fiets die verwijderd moet worden</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteBike(int id)
        {
            Bike bike = _bikeRepository.GetBy(id);
            if (bike == null)
                return NotFound();
            _bikeRepository.Delete(bike);
            _bikeRepository.SaveChanges();
            return NoContent();
        }
    }
}
