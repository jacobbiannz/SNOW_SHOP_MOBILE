using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNOW.SHOP.MOBILE.Models.Catalog
{
    public class CatalogCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return Category;
        }
    }
}
