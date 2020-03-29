using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBikeRental.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Orders()
        {

        }

        public Orders(DateTime start, DateTime end)
        {
            StartDate = start;
            EndDate = end;
        }

    }
}
