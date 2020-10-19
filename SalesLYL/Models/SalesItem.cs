using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models
{
    public class SalesItem
    {
        public long docNum { get; set; }
        public string docType { get; set; }
        public long itemNum { get; set; }
        public string material { get; set; }
        public decimal quantity { get; set; }
        public string unit { get; set; }
        public string currency { get; set; }
        public decimal grandTotal { get; set; }
        public decimal discount { get; set; }
        public decimal subTotal { get; set; }
        public decimal price { get; set; }
        public string variantOptions { get; set; }

    }
}