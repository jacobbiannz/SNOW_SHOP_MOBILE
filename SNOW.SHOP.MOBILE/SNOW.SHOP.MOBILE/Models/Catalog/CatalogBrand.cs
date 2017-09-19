using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNOW.SHOP.MOBILE.Models.Catalog
{
    public class CatalogBrand
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        public override string ToString()
        {
            return Brand;
        }
    }
}
