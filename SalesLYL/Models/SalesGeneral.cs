using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models
{
    public class SalesGeneral
    {
        public SalesHead salesHead { get; set; }
        public List<SalesItem> salesItemList { get; set; }
        public bool resultInserted { get; set; }
        public bool resultUpdated { get; set; }
       
        public bool SHEmpty
        {
            get
            {
                return (salesHead == null);
            }
        }
        public bool SIEmpty
        {
            get
            {
                return (salesItemList == null);
            }
        }
      

    }
 
}