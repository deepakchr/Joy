using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdfsaLabAPI.Models
{
    public class ApiResponse
    {
        public string Status { get; set; }
        public string OrderId { get; set; }
        public string Message { get; set; }
    }
}