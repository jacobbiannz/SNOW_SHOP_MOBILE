using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNOW.SHOP.MOBILE.Models.Catalog
{
    public class CatalogRoot
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<CatalogProduct> Data { get; set; }
    }
}
