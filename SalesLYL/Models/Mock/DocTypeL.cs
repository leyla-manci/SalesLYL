using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesLYL.Models.Mock
{
    public class DocTypeL
    {
        public string Id { get; set; }
        public string Value { get; set; }

        public List<DocTypeL> getDocTypeList()
        {
            List<DocTypeL> PList = new List<DocTypeL>();
            foreach (DocType suit in (DocType[])Enum.GetValues(typeof(DocType)))
            {
                DocTypeL page = new DocTypeL();
                page.Id = suit.ToString();
                page.Value = suit.ToString();
                PList.Add(page);
            }
            return PList;
        }
    }
}