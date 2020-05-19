﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        ///// <summary>
        ///// Geeft de klant met het meegegeven id terug
        ///// </summary>
        ///// <param name="email">De email van de klant</param>
        ///// <returns>De fiets</returns>
        //[HttpGet("{email}")]
        //public ActionResult<Customer> GetCustomer(string email)
        //{
        //    Customer customer = _customerRepository.GetByEmail(email);
        //    if (email == null)
        //        return NotFound();
        //    return customer;
        //}



        /// <summary>
        /// Voegt een nieuwe fiets toe
        /// </summary>
        /// <remarks>Het id dient niet ingevuld te worden, dit gebeurt automatisch. De waarde mag dus op 0 blijven staan.</remarks>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult<Bike> CreateBike(Bike bike)
        {
            _bikeRepository.Add(bike);
            _bikeRepository.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = bike.ID }, bike);
        }

        /// <summary>
        /// Past een bestaande fiets aan
        /// </summary>
        /// <param name="id">De id van de fiets die moet aangepast worden. <br /> Bij het invullen van een lege id zal er een 404 foutmelding verschijnen</param>
        /// <remarks>Bij het bewerken van de gegevens geef je het vedlje "id" de id van de fiets die bewerkt moet worden.</remarks>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminOnly")]
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
