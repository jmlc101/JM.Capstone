using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserFriendRequest
    {
        public int UserID { get; set; }
        public User User { get; set; }

        public int FriendRequestID { get; set; }
        public FriendRequest FriendRequest { get; set; }

    }
}
