using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserRoute
    {
        public int UserID { get; set; }
        public User User { get; set; }

        public int RouteID { get; set; }
        public Route Route { get; set; }
    }
}
