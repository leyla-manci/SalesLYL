using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models
{
     class Materialdb
    {
        public long materialId { get; set; }
        public string materialName { get; set; }
        public string longText { get; set; }
        public int isVariant { get; set; }
        public int size { get; set; }
        public int color { get; set; }
        public string unit { get; set; }
        public string pUnit { get; set; }
        public decimal pUpricenit { get; set; }
        public string currency { get; set; }
        public decimal stockquantity { get; set; }
     
    }
}