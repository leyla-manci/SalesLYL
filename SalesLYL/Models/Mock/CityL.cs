using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models.Mock
{
    public class CityL
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public List<CityL> getCityList()
        {
            List<CityL> PList = new List<CityL>();
            /*
            CityL page = new CityL();
            page.Id = null;
            page.Value = "Select City".ToString();
            PList.Add(page);*/
            foreach (City suit in (City[])Enum.GetValues(typeof(City)))
            {
                CityL page2 = new CityL();
                page2.Id = suit.ToString();
                page2.Value = suit.ToString();
                PList.Add(page2);
            }
            return PList;
        }
    }

}