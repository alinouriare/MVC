using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
        //[BindNever]
        public string NeverUpdate { get; set; }

    }
}
