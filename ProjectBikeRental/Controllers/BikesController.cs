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
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly IBikeRepository _bikeRepository;
        public BikesController(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        [HttpGet]
        public IEnumerable<Bike> GetBikes()
        {
            return _bikeRepository.GetAll().OrderByDescending(b => b.Price);
        }

        [HttpGet("{id}")]
        public ActionResult<Bike> Get(int id)
        {
            Bike bike = _bikeRepository.GetBy(id);
            if (bike == null)
                return NotFound();
            return bike;
        }

        // POST: api/Bikes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Bikes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
