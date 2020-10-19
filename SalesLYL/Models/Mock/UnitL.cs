using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models.Mock
{
    public class UnitL
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public List<UnitL> getUnitList()
        {
            List<UnitL> PList = new List<UnitL>();
            foreach (Unit suit in (Unit[])Enum.GetValues(typeof(Unit)))
            {
                UnitL page = new UnitL();
                page.Id = suit.ToString();
                page.Value = suit.ToString();
                PList.Add(page);
            }
            return PList;
        }
    }
}