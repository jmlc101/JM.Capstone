using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RouteReview
    {
        public int RouteID { get; set; }
        public Route Route { get; set; }

        public int ReviewID { get; set; }
        public Review Review { get; set; }

    }
}
