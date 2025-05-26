using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using booking_ticket.Model;

namespace booking_ticket.Controller
{
    public class userController
    {
        private UserManajemen userManajemen = new UserManajemen();

        public bool Login(User user)
        {
            return userManajemen.CekLogin(user);
        }
    }
}
