using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWithAngularJS.Models
{
    public class ProductData
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? Availability { get; set; }
    }
}