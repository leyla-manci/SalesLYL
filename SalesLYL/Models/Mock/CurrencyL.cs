using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models.Mock
{
    public class CurrencyL
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public List<CurrencyL> getCurrencyList()
        {
            List<CurrencyL> PList = new List<CurrencyL>();
            foreach (Currency suit in (Currency[])Enum.GetValues(typeof(Currency)))
            {
                CurrencyL page = new CurrencyL();
                page.Id = suit.ToString();
                page.Value = suit.ToString();
                PList.Add(page);
            }
            return PList;
        }
    }
}