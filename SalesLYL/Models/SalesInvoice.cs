using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models
{
    public class SalesInvoice
    {
        public SalesHead salesHead { get; set; }
        public List<SalesItem> salesItemList { get; set; }
    }
}