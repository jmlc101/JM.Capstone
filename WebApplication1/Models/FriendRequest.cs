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

        public IList<UserFriendRequest> UserFriendRequests { get; set; }
    }
}
