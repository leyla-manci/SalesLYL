using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models.Mock
{
    public class CountryL
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public List<CountryL> getCountryList()
        {
            List<CountryL> PList = new List<CountryL>();
            foreach (Country suit in (Country[])Enum.GetValues(typeof(Country)))
            {
                CountryL page = new CountryL();
                page.Id = suit.ToString();
                page.Value = suit.ToString();
                PList.Add(page);
            }
            return PList;
        }
    }
}