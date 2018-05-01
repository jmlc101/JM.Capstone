using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        public int ID { get; set; }
        public string ScreenName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }
        public string HashCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }

        public IList<UserRoute> UserRoutes { get; set; }
    }
}
