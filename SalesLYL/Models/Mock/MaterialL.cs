using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models.Mock
{
    public class MaterialL
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public List<MaterialL> getMaterialList()
        {
            List<MaterialL> PList = new List<MaterialL>();
            foreach (Material suit in (Material[])Enum.GetValues(typeof(Material)))
            {
                MaterialL page = new MaterialL();
                page.Id = suit.ToString();
                page.Value = suit.ToString();
                PList.Add(page);
            }
            return PList;
        }
    }
}