using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBikeRental.Models;

namespace ProjectBikeRental.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly IBikeRepository _bikeRepository;
        public BikesController(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        /// <summary>
        /// Geeft alle fietsen terug, gesorteerd op stijgende prijs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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
        /// <param name="bike">De nieuwe fiets</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Bike> CreateBike(Bike bike)
        {
            _bikeRepository.Add(bike);
            _bikeRepository.SaveChanges();
            return CreatedAtAction(nameof(bike), new {id = bike.ID},bike);
        }

        /// <summary>
        /// Past een bestaande fiets aan
        /// </summary>
        /// <param name="id">De id van de fiets die moet aangepast worden</param>
        /// <param name="bike">De aangepaste fiets</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBike(int id, Bike bike)
        {
            if (id != bike.ID)
                return NotFound(); //-> Dit zal een 404 response terugsturen

            _bikeRepository.Update(bike);
            _bikeRepository.SaveChanges();
            return NoContent(); //-> Dit zal een 204 response terugsturen
        }

        /// <summary>
        /// Verwijderd een fiets 
        /// </summary>
        /// <param name="id">De id van de fiets die verwijderd moet worden</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
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
