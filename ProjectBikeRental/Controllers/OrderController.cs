using System;
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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBikeRepository _bikerepo;

        public OrderController(IOrderRepository orderRepository, IBikeRepository bikerepo)
        {
            _orderRepository = orderRepository;
            _bikerepo = bikerepo;
        }

        /// <summary>
        /// Geeft de bestelling met het meegegeven id terug
        /// </summary>
        /// <param name="id">De email van de klant</param>
        /// <returns>De fiets</returns>*/
        [HttpGet("{id}")]
        public ActionResult<Orders> GetOrder(int id)
        {
            Orders order = _orderRepository.GetBy(id);
            if (order == null)
                return NotFound();
            return order;
        }

        /// <summary>
        /// Geeft alle bestellingen terug. De fiets die eerst moet verhuurd worden komt boven in de lijst te staan.
        /// </summary>
        /// <returns>De fiets</returns>*/
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        [AllowAnonymous]
        public IEnumerable<Orders> GetAll()
        {
            return _orderRepository.GetAll().OrderBy(o => o.StartDate);
        }

        /// <summary>
        /// Voegt een nieuwe bestelling toe
        /// </summary>
        /// <remarks>Het id dient niet ingevuld te worden, dit gebeurt automatisch. De waarde mag dus op 0 blijven staan.</remarks>
        /// <returns></returns>*/
        [HttpPost]
        public ActionResult<Orders> CreateOrder(Orders order)
        {
            //-> Dagen met 1 verhogen omdat fe telkens een dag te weinig geeft
            _orderRepository.Add(new Orders(order.StartDate.Date.AddDays(1), order.EndDate.Date.AddDays(1), _bikerepo.GetBy(order.Bike.ID), order.customerEmail));
            _orderRepository.SaveChanges();
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }
    }
}
