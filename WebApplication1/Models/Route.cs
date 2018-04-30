using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Route
    {
        public string RouteName { get; set; }
        public string Origin { get; set; }
        public string Waypoints { get; set; }
        public string Destination { get; set; }
        public IList<string> Reviews { get; set; }
    }
}
