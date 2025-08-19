using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdfsaLabAPI.Models
{
    public class Users
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string UserPass { get; set; }

        public string UserRole { get; set; }
    }
}