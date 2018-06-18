using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RequestorRequested
    {
        public RequestorRequested()
        {
            Requestor = new User();
            Requested = new User();
        }

        public int RequestorID { get; set; }
        public User Requestor { get; set; }

        public int RequestedID { get; set; }
        public User Requested { get; set; }

    }
}
