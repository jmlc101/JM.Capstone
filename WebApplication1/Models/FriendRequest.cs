using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class FriendRequest
    {
        public int ID { get; set; }

        public int RequestingUserID { get; set; }
        public string RequestingUserScreenName { get; set; }
        public int RequestedUserID { get; set; }
        public string RequestedUserScreenName { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
