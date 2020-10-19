using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models.Mock
{
    public class VariantL
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public List<VariantL> getVariantList()
        {
            List<VariantL> PList = new List<VariantL>();
            foreach (Variant suit in (Variant[])Enum.GetValues(typeof(Variant)))
            {
                VariantL page = new VariantL();
                page.Id = suit.ToString();
                page.Value = suit.ToString();
                PList.Add(page);
            }
            return PList;
        }
    }
}