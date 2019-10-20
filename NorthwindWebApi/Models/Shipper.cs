using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindWebApi.Models
{
    public class Shipper
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}