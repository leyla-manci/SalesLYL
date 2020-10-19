using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace SalesLYL.Models
{
    public class SalesHead
    {
        [Display(Name = "Invoice Num.")]
        public long docNum { get; set; }
        [Display(Name = "Invoice Type")]
        public string docType { get; set; }
        public int docChar { get; set; }
        public long customerId { get; set; }
        [Display(Name = "Customer Name")]
        public string custName1 { get; set; }
        public string custName2 { get; set; }

        [Display(Name = "Currency")]
        public string currency { get; set; }
        public string hCurrency { get; set; }

        [Display(Name = "Invoice Date")]
        public DateTime docDate { get; set; }
        public decimal exRate { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public long phone { get; set; }
        [Display(Name = "Total")]
        public decimal grandTotal { get; set; }
        public decimal discount { get; set; }
        public decimal subTotal { get; set; }
     
    }
}