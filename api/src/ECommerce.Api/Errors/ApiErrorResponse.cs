using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Errors
{
    public class ApiErrorResponse
    {
        public int Status{get; set;}
        public string message {get; set;}=null;
        public string? Details { get; set; }
    }
}