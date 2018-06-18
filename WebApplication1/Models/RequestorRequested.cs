using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int ID { get; set; }

        public int RequestorID { get; set; }

        [NotMapped]
        public User Requestor { get; set; }

        public int RequestedID { get; set; }
        public User Requested { get; set; }
    }
}
