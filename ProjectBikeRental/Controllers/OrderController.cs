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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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
        /// Geeft alle bestellingen terug. De nieuwste bestelling komt als eerste te staan.
        /// </summary>
        /// <returns>De fiets</returns>*/
        [HttpGet]
        public IEnumerable<Orders> GetAll()
        {
            return _orderRepository.GetAll();
        }

        /// <summary>
        /// Voegt een nieuwe bestelling toe
        /// </summary>
        /// <remarks>Het id dient niet ingevuld te worden, dit gebeurt automatisch. De waarde mag dus op 0 blijven staan.</remarks>
        /// <returns></returns>*/
        [HttpPost]
        public ActionResult<Orders> CreateOrder(Orders order)
        {
            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
            return CreatedAtAction(nameof(order), new { id = order.OrderId }, order);
        }


    }
}
